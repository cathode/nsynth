/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using NSynth;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NSynth
{
    /// <summary>
    /// Represents the base class used for all filters in the graph.
    /// </summary>
    public abstract class Filter : IDisposable
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Filter.Clip"/> property.
        /// </summary>
        private Clip clip;

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
        /// Backing field for the <see cref="Filter.Rank"/> property.
        /// </summary>
        private int rank;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Filter"/> class.
        /// </summary>
        protected Filter()
        {
            this.clip = new Clip();
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
        public Clip Clip
        {
            get
            {
                return this.clip;
            }
            protected set
            {
                this.clip = value ?? new Clip();
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
        /// Gets the rank of the current filter within the filter graph that it belongs to.
        /// </summary>
        public int Rank
        {
            get
            {
                return this.rank;
            }
            internal set
            {
                this.rank = value;
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
        #endregion
        #region Methods
        public virtual IAsyncResult BeginRender(long frameIndex, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }
        public virtual IAsyncResult BeginRender(long frameIndex, long count, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }
        public virtual Frame EndRender(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
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
        /// Renders the frame with the specified index.
        /// </summary>
        /// <param name="frameIndex">The zero-based index of the frame to render. This index is relative to the current filter.</param>
        public virtual Frame Render(long frameIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renders the range of frames defined by the starting index and frame count.
        /// </summary>
        /// <param name="startIndex">The zero-based index of the first frame in the range to be rendered. This index is relative to the current filter.</param>
        /// <param name="count">The number of frames to render.</param>
        public virtual Frame[] Render(long startIndex, long count)
        {
            var frames = new Frame[count];

            for (long i = 0, n = startIndex; i < count; i++, n++)
                frames[i] = this.Render(n);

            return frames;
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
        #endregion
    }
}
