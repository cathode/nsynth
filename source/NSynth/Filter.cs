/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
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
    /// Represents the base class used for all filters in the graph.
    /// </summary>
    public abstract class Filter : IDisposable, IFrameSource
    {
        #region Fields
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
        private readonly Dictionary<ulong, Frame> bufferedFrames;

        /// <summary>
        /// Holds the indices of frames that have been requested for rendering.
        /// </summary>
        private readonly Queue<ulong> requestedFrames;

        private readonly FilterInputSlotCollection inputs;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Filter"/> class.
        /// </summary>
        protected Filter()
        {
            this.bufferedFrames = new Dictionary<ulong, Frame>();
            this.requestedFrames = new Queue<ulong>();
            this.inputs = new FilterInputSlotCollection(this);
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
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="Clip"/> that represents the characteristics current filter's output.
        /// </summary>
        [Obsolete]
        public Clip Clip
        {
            get
            {
                return null;
            }
            protected set
            {

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

        public virtual ulong FrameCount
        {
            get
            {
                return 0;
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
        }
        /// <summary>
        /// Requests that a single frame should be rendered.
        /// </summary>
        /// <param name="frameIndex">The index of the frame to render.</param>
        public void RequestFrame(ulong frameIndex)
        {
            //if (!this.requestedFrames.Contains(frameIndex))
            //    this.requestedFrames.Enqueue(frameIndex);

            // TODO: Ensure that request queue is being processed by the worker thread.

            // HACK: Perform blocking render.

            var frame = new Frame(this);
            this.Render(frame, frameIndex);

            this.bufferedFrames.Add(frameIndex, frame);
            
        }

        public Frame GetFrame(ulong index)
        {
            if (this.bufferedFrames.ContainsKey(index))
                return this.bufferedFrames[index];
            else
                this.RequestFrame(index);

            return this.bufferedFrames[index];
        }

        protected virtual bool Render(Frame output, ulong index)
        {
            return false;
        }
        #endregion

        
    }
}
