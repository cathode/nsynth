/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;
using System.Diagnostics.Contracts;
using System.Collections.Generic;

namespace NSynth
{
    /// <summary>
    /// Provides a base type and shared functionality for classes that decode multimedia frames from a bitstream.
    /// </summary>
    public abstract class MediaDecoder : IDisposable
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="MediaDecoder.BaseStream"/> property.
        /// </summary>
        private Stream bitstream;

        /// <summary>
        /// Backing field for the <see cref="MediaDecoder.IsInitialized"/> property.
        /// </summary>
        private bool isOpen;

        /// <summary>
        /// Backing field for the <see cref="MediaDecoder.FramePosition"/> property.
        /// </summary>
        private long framePosition;

        /// <summary>
        /// Backing field for the <see cref="MediaDecoder.IsDisposed"/> property.
        /// </summary>
        private bool isDisposed;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaDecoder"/> class.
        /// </summary>
        protected MediaDecoder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaDecoder"/> class.
        /// </summary>
        /// <param name="bitstream">The <see cref="Stream"/> to decode frames from.</param>
        protected MediaDecoder(Stream bitstream)
        {
            this.bitstream = bitstream;
        }

        /// <summary>
        /// Finalizes.
        /// </summary>
        ~MediaDecoder()
        {
            this.Dispose(false);
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="Stream"/> that multimedia data is decoded from.
        /// </summary>
        public Stream Bitstream
        {
            get
            {
                return this.bitstream;
            }
            set
            {
                this.bitstream = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="MediaDecoder"/> is ready to decode frames.
        /// </summary>
        public bool IsInitialized
        {
            get
            {
                return this.isOpen;
            }
            protected set
            {
                this.isOpen = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="Codec"/> which describes the decoder.
        /// </summary>
        public abstract Codec Codec
        {
            get;
        }

        /// <summary>
        /// Gets the zero-based index where the next frame will be decoded from.
        /// </summary>
        public long FramePosition
        {
            get
            {
                return this.framePosition;
            }
            protected set
            {
                this.framePosition = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of frames that have been decoded by the current <see cref="MediaDecoder"/>.
        /// </summary>
        public long DecodedFrameCount
        {
            get;
            protected set;
        }

        public bool IsDisposed
        {
            get
            {
                return this.isDisposed;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Performs any actions that are required before frames can be decoded, such as reading headers and footers, data or checksum verification, etc.
        /// </summary>
        /// <returns>true if no problems were encountered; otherwise, false.</returns>
        public virtual bool Initialize()
        {
            return true;
        }

        /// <summary>
        /// Decodes the next frame from the bitstream.
        /// </summary>
        /// <returns>The decoded frame.</returns>
        [Obsolete]
        public virtual Frame Decode()
        {
            throw new NotImplementedException();
        }


        public virtual void Decode(Frame output)
        {
            if (!this.IsInitialized)
                if (!this.Initialize())
                    throw new NotImplementedException();

            this.DoDecode(output);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);

            this.isDisposed = true;
        }

        protected virtual void DoDecode(Frame output)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (this.Bitstream != null)
                    this.Bitstream.Dispose();
        }
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.FramePosition >= 0);
        }
        #endregion
    }
}
