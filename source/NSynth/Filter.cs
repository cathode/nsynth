/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NSynth;
using System.Diagnostics.Contracts;

namespace NSynth
{
    /// <summary>
    /// Represents the base class used for all filters in the graph. This class is thread safe.
    /// Inherited classes should be thread safe as well.
    /// </summary>
    public abstract class Filter : IDisposable, IFrameSource
    {
        #region Fields
        protected readonly Mutex Mutex = new Mutex();

        /// <summary>
        /// Backing field for the <see cref="Filter.IsDisposed"/> property.
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// Backing field for the <see cref="Filter.IsInitialized"/> property.
        /// </summary>
        private bool isInitialized;

        /// <summary>
        /// Backing field for the <see cref="Filter.Tag"/> property.
        /// </summary>
        private string tag;

        /// <summary>
        /// Holds frames buffered for output.
        /// </summary>
        private readonly Dictionary<long, Frame> bufferedFrames;

        /// <summary>
        /// Holds the indices of frames that have been requested for rendering.
        /// </summary>
        private readonly Queue<long> requestedFrames;

        private readonly FilterInputSlotCollection inputs;

        private readonly List<FilterInputSlot> consumers;

        /// <summary>
        /// Backing field for the <see cref="Filter.Clip"/> property.
        /// </summary>
        private Clip clip;
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
        public bool IsInitialized
        {
            get
            {
                return this.isInitialized;
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
        public bool Initialize()
        {
            var e = new FilterInitializationEventArgs();

            this.OnInitializing(e);

            if (e.Succeeded)
                this.isInitialized = true;

            return this.IsInitialized;
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
        protected virtual void OnInitializing(FilterInitializationEventArgs e)
        {
            if (this.Initializing != null)
                this.Initializing(this, e);

            if (this.inputs.Default != null && this.inputs.Default.Source != null)
                this.Clip = this.inputs.Default.Source.Clip;
            else
                this.Clip = new Clip();
        }

        /// <summary>
        /// Requests that a single frame should be rendered.
        /// </summary>
        /// <param name="frameIndex">The index of the frame to render.</param>
        public void RequestFrame(long frameIndex)
        {
            //if (!this.requestedFrames.Contains(frameIndex))
            //    this.requestedFrames.Enqueue(frameIndex);

            // TODO: Ensure that request queue is being processed by the worker thread.

            // HACK: Perform blocking render.

            var frame = new Frame(this.Clip);
            this.Render(frame, frameIndex);

            this.bufferedFrames.Add(frameIndex, frame);
        }

        public Frame GetFrame(long index)
        {
            if (this.bufferedFrames.ContainsKey(index))
                return this.bufferedFrames[index];
            else
                this.RequestFrame(index);

            return this.bufferedFrames[index];
        }

        /// <summary>
        /// Determines if a frame is in scope, e.g. if any of it's consumers are currently processing a frame that requires the specified frame index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected bool IsFrameInScope(long index)
        {
            foreach (var consumer in this.consumers)
            {

            }

            return false;
        }

        protected virtual bool Render(Frame output, long index)
        {
            return false;
        }

        /// <summary>
        /// Determines if the current filter depends on the specified filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public bool DependsOn(Filter filter)
        {
            foreach (var input in this.inputs.Where(f => f.Source != null))
                if (input.Source == filter || input.Source.DependsOn(filter))
                    return true;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consumer"></param>
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

        internal Frame GetPooledFrame()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
