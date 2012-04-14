/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
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
        /// <param name="bitstream">The <see cref="Stream"/> which encoded frames will be written to.</param>
        protected MediaEncoder(Stream bitstream)
        {
            this.bitstream = bitstream;
        }

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
            set
            {
                if (this.IsOpen)
                    this.Close();
                this.bitstream = value;

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
        public void Encode(IFrameSource frameSource, ulong start, ulong count)
        {
            Contract.Requires(frameSource != null);

            var end = start + count;
            for (ulong i = start; i < end; ++i)
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

        public abstract bool Open();
        public abstract bool Close();

        /// <summary>
        /// Releases all resources held by the <see cref="MediaEncoder"/>.
        /// </summary>
        public void Dispose()
        {

            this.Dispose(true);
            GC.SuppressFinalize(this);

            this.isDisposed = true;
        }

        public virtual object Suspend()
        {
            if (this.CanSuspend)
                throw EX.Create(EXCode.EncoderFeatureNotImplemented, "Suspend");
            else
                throw new NotSupportedException();
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

        protected virtual void OnOpening(EventArgs e)
        {

        }

        protected virtual void OnClosing(EventArgs e)
        {

        }
        #endregion
    }
}