/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace NSynth
{
    /// <summary>
    /// Represents basic functionality used by types that encode multimedia content to a bitstream.
    /// </summary>
    public abstract class MediaEncoder : IDisposable
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="MediaEncoder.Bitstream"/> property.
        /// </summary>
        private Stream bitstream;

        /// <summary>
        /// Backing field for the <see cref="MediaEncoder.IsDisposed"/> property.
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// Backing field for the <see cref="MediaEncoder.IsOpen"/> property.
        /// </summary>
        private bool isOpen;
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaEncoder"/> class.
        /// </summary>
        protected MediaEncoder()
        {
            this.bitstream = null;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MediaEncoder"/> class.
        /// </summary>
        ~MediaEncoder()
        {
            this.Dispose(false);
        }
        #endregion
        #region Events
        public event AsyncCompletedEventHandler EncodeCompleted;
        public event ProgressChangedEventHandler ProgressChanged;
        public event EventHandler Opening;
        public event EventHandler Closing;
        public event EventHandler Suspending;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the underlying <see cref="Stream"/> that encoded frames are written to.
        /// </summary>
        public Stream Bitstream
        {
            get
            {
                return this.bitstream;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the state of the encoder can be persisted to allow an encoding operation to be resumed at a later time.
        /// </summary>
        public virtual bool CanSuspend
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the <see cref="Codec"/> for the current <see cref="MediaEncoder"/>.
        /// </summary>
        public abstract Codec Codec
        {
            get;
        }

        public bool IsBusy
        {
            get;
            set;
        }
        /// <summary>
        /// Gets a value indicating whether the current <see cref="MediaEncoder"/> is disposed.
        /// Attempting to call methods of a disposed object will immediately result in an <see cref="ObjectDisposedException"/> being thrown.
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
        /// Gets a value indicating whether the current <see cref="MediaEncoder"/> is open.
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return this.isOpen;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Cancels a pending asynchronous operation.
        /// </summary>
        /// <param name="userState"></param>
        public void CancelAsync(object userState)
        {
        }

        /// <summary>
        /// Encodes a specified range of frames obtained from the specified frame source.
        /// </summary>
        /// <param name="frameSource"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        public void Encode(IFrameSource frameSource, long start, long count)
        {
            Contract.Requires(frameSource != null);

            var end = start + count;
            for (long i = start; i < end; ++i)
                this.EncodeFrame(frameSource.GetFrame(i));
        }

        /// <summary>
        /// Asynchronously encodes a specified range of frames obtained from the specified frame source.
        /// </summary>
        /// <param name="frameSource"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <param name="userState"></param>
        public void EncodeAsync(IFrameSource frameSource, long start, long count, object userState)
        {

        }

        public abstract void EncodeFrame(Frame frame);

        public void Open(Stream bitstream)
        {
            if (this.IsOpen)
                return;

            this.OnOpening(EventArgs.Empty);

            this.isOpen = true;
        }

        /// <summary>
        /// Closes the current <see cref="MediaEncoder"/>, and releases all resources held by it.
        /// </summary>
        public void Close()
        {
            this.OnClosing(EventArgs.Empty);

            this.Dispose();
        }

        /// <summary>
        /// Releases all resources held by the <see cref="MediaEncoder"/>.
        /// </summary>
        public void Dispose()
        {

            this.Dispose(true);
            GC.SuppressFinalize(this);

            this.isDisposed = true;
        }

        public virtual void Suspend()
        {
            Contract.Requires<NotSupportedException>(this.CanSuspend);

            this.OnSuspend(EventArgs.Empty);
        }

        /// <summary>
        /// Disposes the current <see cref="MediaEncoder"/>.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (this.Bitstream != null)
                    this.Bitstream.Dispose();
        }

        /// <summary>
        /// Raises the <see cref="MediaEncoder.Opening"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnOpening(EventArgs e)
        {
            if (this.Opening != null)
                this.Opening(this, e);
        }

        /// <summary>
        /// Raises the <see cref="MediaEncoder.Closing"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnClosing(EventArgs e)
        {
            if (this.Closing != null)
                this.Closing(this, e);
        }

        /// <summary>
        /// Raises the <see cref="MediaEncoder.Suspend"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnSuspend(EventArgs e)
        {
            if (this.Suspending != null)
                this.Suspending(this, e);
        }
        #endregion
    }
}