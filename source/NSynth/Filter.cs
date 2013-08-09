/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NSynth;
using System.Diagnostics.Contracts;
using NSynth.Imaging;

namespace NSynth
{
    /// <summary>
    /// Represents the base class used for all filters in the graph. This class is thread safe.
    /// Inherited classes should be thread safe as well.
    /// </summary>
    public abstract class Filter : IDisposable
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        protected readonly Mutex Mutex = new Mutex();

        /// <summary>
        /// Thread-safety helper.
        /// </summary>
        private readonly object sync = new object();

        /// <summary>
        /// Holds frames buffered for output.
        /// </summary>
        private readonly Dictionary<long, Frame> bufferedFrames;

        /// <summary>
        /// Backing field for the <see cref="Filter.Clip"/> property.
        /// </summary>
        private Clip clip;

        /// <summary>
        /// Contains references to each <see cref="FilterInputSlot"/> which belong to other filters that
        /// use the current filter as an input to one or more of their slots.
        /// </summary>
        private readonly List<FilterInputSlot> consumers;

        private readonly FilterInputSlotCollection inputs;

        /// <summary>
        /// Backing field for the <see cref="Filter.IsDisposed"/> property.
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// Backing field for the <see cref="Filter.IsClipInitialized"/> property.
        /// </summary>
        private bool isClipInitialized;

        /// <summary>
        /// Backing field for the <see cref="Filter.Tag"/> property.
        /// </summary>
        private string tag;

        /// <summary>
        /// Holds the indices of frames that have been requested for rendering.
        /// </summary>
        private readonly Queue<long> requestedFrames;

        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Filter"/> class.
        /// </summary>
        protected Filter()
        {
            this.bufferedFrames = new Dictionary<long, Frame>();
            this.requestedFrames = new Queue<long>();
            this.inputs = new FilterInputSlotCollection(this);
            this.consumers = new List<FilterInputSlot>();

            this.Inputs.AddSlot("source");
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Filter"/> class.
        /// </summary>
        ~Filter()
        {
            this.Dispose(false);
        }
        #endregion
        #region Events
        /// <summary>
        /// Raised when the filter performs it's initialization step.
        /// </summary>
        public event EventHandler<FilterInitializationEventArgs> Initializing;

        /// <summary>
        /// Raised when the filter completes the rendering of a frame.
        /// </summary>
        public event EventHandler<FrameRenderEventArgs> FrameRendered;

        #endregion
        #region Properties
        public FilterInputSlot Source
        {
            get
            {
                return this.Inputs["source"];
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the current <see cref="Filter"/> is disposed.
        /// </summary>
        public bool IsDisposed
        {
            get
            {
                return this.isDisposed;
            }
            protected set
            {
                this.isDisposed = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="Filter"/> is initialized.
        /// </summary>
        public bool IsClipInitialized
        {
            get
            {
                return this.isClipInitialized;
            }
        }

        /// <summary>
        /// Gets or sets a string that is meaningful to the user which identifies the current <see cref="Filter"/>.
        /// </summary>
        // [FilterParameter("Tag", Description = "TagParameterDescription", Kind = FilterParameterKind.String)]
        public string Tag
        {
            get
            {
                return this.tag;
            }
            set
            {
                this.tag = value;
            }
        }

        /// <summary>
        /// Gets a collection of inputs to the current filter.
        /// </summary>
        public FilterInputSlotCollection Inputs
        {
            get
            {
                return this.inputs;
            }
        }

        public virtual long FrameCount
        {
            get
            {
                return -1;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Clip"/> that describes the frames processed by the current <see cref="Filter"/>.
        /// </summary>
        public Clip Clip
        {
            get
            {
                if (this.clip == null)
                    this.InitializeClip();

                return this.clip;
            }
            set
            {
                this.clip = value;
            }
        }

        /// <summary>
        /// Gets a collection of frame indexes that have been requested by upstream filters and have not yet been rendered.
        /// </summary>
        public IEnumerable<long> OutstandingFrames
        {
            get
            {
                yield return 0;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Disposes the current <see cref="Filter"/>, releasing managed and unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
            this.isDisposed = true;
        }

        /// <summary>
        /// Readies the filter for use.
        /// </summary>
        /// <returns>true if everything went okay; otherwise false.</returns>
        public bool InitializeClip()
        {
            Contract.Ensures(this.IsClipInitialized == true);

            var e = new FilterInitializationEventArgs();

            this.OnClipInitializing(e);

            if (e.Succeeded)
                this.isClipInitialized = true;

            return this.IsClipInitialized;
        }

        /// <summary>
        /// Disposes the current <see cref="Filter"/>, releasing unmanaged resources and optionally managed resources.
        /// </summary>
        /// <param name="disposing">Indicates whether to release managed resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.IsDisposed)
            {
                if (disposing)
                {
                    this.Mutex.Dispose();
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="Filter.Initializing"/> event.
        /// </summary>
        /// <param name="e">Event data associated with the event.</param>
        protected virtual void OnClipInitializing(FilterInitializationEventArgs e)
        {
            if (this.Initializing != null)
                this.Initializing(this, e);

            if (this.inputs.Default != null && this.inputs.Default.Filter != null)
                this.Clip = this.inputs.Default.Filter.Clip;
            else
                this.Clip = new Clip();
        }

        /// <summary>
        /// Gets the <see cref="Frame"/> from this filter with the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Frame GetFrame(long index)
        {

            Contract.Ensures(Contract.Result<Frame>() != null);

            var context = new FilterProcessingContext(this, index);

            foreach (var slot in this.inputs.Where(i => i.Filter != null))
                foreach (var offset in this.GetInputFramesRequired(slot, index))
                    context.SetFrame(slot.Name, offset, slot.Filter.GetFrame(index + offset));

            var outputFrame = this.Clip.IssueFrame();

            this.DoProcessing(context, outputFrame);

            return outputFrame;
        }

        /// <summary>
        /// Begins an asynchronous request for a frame from the current filter.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public IAsyncResult BeginGetFrame(AsyncCallback callback, long index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ends an asynchronous request for a frame from the current filter.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public Frame EndGetFrame(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Determines if a frame is in scope, e.g. if any of it's consumers are currently processing a frame that requires the specified frame index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [Pure]
        protected bool IsFrameInScope(long index)
        {
            foreach (var consumer in this.consumers)
            {

            }

            return false;
        }

        /// <summary>
        /// When overridden in a derived class, performs the appropriate processing work and writes the results to
        /// the <paramref name="outputFrame"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="outputFrame"></param>
        protected virtual void DoProcessing(FilterProcessingContext context, Frame outputFrame)
        {
            // Do nothing.
        }

        /// <summary>
        /// Determines if the current filter depends on the specified filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Pure]
        public bool DependsOn(Filter filter)
        {
            if (filter != null)
                foreach (var input in this.inputs.Where(f => f.Filter != null).Select(f => f.Filter))
                    if (input != null)
                        if (input == filter || input.DependsOn(filter))
                            return true;

            return false;
        }

        /// <summary>
        /// For a given input slot on the current filter, determines which frame indices are required from that slot
        /// for the current filter to render the specified frame index.
        /// </summary>
        /// <remarks>
        /// The default behavior is to go by the FramesBefore and FramesAfter values that have been assigned to the slot.
        /// </remarks>
        /// <param name="slot"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public IEnumerable<int> GetInputFramesRequired(string slot, long index)
        {
            Contract.Requires(!string.IsNullOrEmpty(slot));
            Contract.Requires(index >= 0);

            if (!this.inputs.Any(s => s.Name == slot))
                throw new NotImplementedException();
            var sl = this.inputs[slot];
            Contract.Assume(sl.Owner == this);
            return this.GetInputFramesRequired(sl, index);
        }

        /// <summary>
        /// For a given input slot on the current filter, determines which frame indices are required from that slot
        /// for the current filter to render the specified frame index.
        /// </summary>
        /// <remarks>
        /// The default behavior is to go by the FramesBefore and FramesAfter values that have been assigned to the slot.
        /// </remarks>
        /// <param name="slot"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual IEnumerable<int> GetInputFramesRequired(FilterInputSlot slot, long index)
        {
            Contract.Requires(slot != null);
            Contract.Requires(slot.Owner == this);
            Contract.Requires(index >= 0);

            if (!slot.IsBound)
                yield break;

            // default behavior should be acceptable for almost all filter implementations.
            int start = Math.Max(0 - slot.FramesBefore, 0);
            int end = slot.FramesAfter;
            // TODO: Fix end so we don't overflow the clip.

            for (int i = start; i <= end; ++i)
                yield return i;
        }

        /// <summary>
        /// Calculates the depth of the current filter.
        /// </summary>
        /// <returns></returns>
        public int GetFilterDepth()
        {
            return this.inputs.Where(s => s.Filter != null).Select(s => s.Filter.GetFilterDepth()).Max();
        }

        internal void BindConsumer(FilterInputSlot consumer)
        {
            Contract.Requires(consumer != null);

            this.Mutex.WaitOne();

            try
            {
                if (this.consumers.Contains(consumer))
                    return;

                this.consumers.Add(consumer);
            }
            finally
            {
                this.Mutex.ReleaseMutex();
            }
        }

        internal void UnbindConsumer(FilterInputSlot consumer)
        {
            Contract.Requires(consumer != null);

            this.consumers.Remove(consumer);
        }

        /// <summary>
        /// Defines invariant code contracts for the <see cref="Filter"/> class.
        /// </summary>
        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(this.clip != null);
            Contract.Invariant(this.consumers != null);
            Contract.Invariant(this.requestedFrames != null);
            Contract.Invariant(this.inputs != null);
            Contract.Invariant(this.inputs.Owner == this);
            Contract.Invariant(this.Mutex != null);
        }
        #endregion

    }

    public class FilterProcessAsyncResult : AsyncResult<Frame>
    {
        /// <summary>
        /// Index of the frame currently being processed.
        /// </summary>
        public long Index
        {
            get;
            set;
        }

        public FilterProcessingContext Context
        {
            get;
            set;
        }

        public FilterProcessAsyncResult(long index, FilterProcessingContext inputs, AsyncCallback callback, object state, object owner, string operationId)
            : base(callback, state, owner, operationId)
        {
            this.Index = index;
            this.Context = inputs;
        }

        protected override void Process()
        {

            base.Process();
        }
    }
}
