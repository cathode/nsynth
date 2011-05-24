/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;

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
        private readonly Stream bitstream;

        /// <summary>
        /// Backing field for the <see cref="MediaEncoder.IsDisposed"/> property.
        /// </summary>
        private bool isDisposed;
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
        /// Finalizes an instance of the <see cref="MediaEncoder"/> class.
        /// </summary>
        ~MediaEncoder()
        {
            this.Dispose(false);
        }
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
        /// Gets a value indicating whether the state of the encoder can be persisted to allow an active encoding session to be resumed at a later time.
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
        }
        #endregion
        #region Methods
        public abstract void EncodeFrame(Frame frame);

        public virtual IAsyncResult BeginEncodeFrame(Frame frame, AsyncCallback callback, object state)
        {
            EncodeFrameAsyncHelper action = this.EncodeFrame;
            return action.BeginInvoke(frame, callback, state);
        }

        public virtual void EndEncodeFrame(IAsyncResult result)
        {
            EncodeFrameAsyncHelper action = this.EncodeFrame;
            action.EndInvoke(result);
        }
        public abstract bool Open();
        public abstract bool Close();

        /// <summary>
        /// Releases all resources held by the <see cref="MediaEncoder"/>.
        /// </summary>
        public void Dispose()
        {
            if (!this.IsDisposed)
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
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
        #endregion
        #region Types
        public delegate void EncodeFrameAsyncHelper(Frame frame);
        public delegate bool CloseAsyncHelper();
        #endregion
    }
}