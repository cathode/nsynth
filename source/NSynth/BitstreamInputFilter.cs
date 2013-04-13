/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NSynth
{
    /// <summary>
    /// Represents an input filter that produces frames by decoding from a bitstream source.
    /// </summary>
    public abstract class BitstreamInputFilter : SourceFilter
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="BitstreamInputFilter.BaseStream"/> property.
        /// </summary>
        private Stream bitstream;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaDecoder"/> class.
        /// </summary>
        protected BitstreamInputFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaDecoder"/> class.
        /// </summary>
        /// <param name="bitstream">The <see cref="Stream"/> to decode frames from.</param>
        protected BitstreamInputFilter(Stream bitstream)
        {
            this.bitstream = bitstream;
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
        /// Gets the <see cref="Codec"/> of the current <see cref="BitstreamInputFilter"/>.
        /// </summary>
        public abstract Codec Codec
        {
            get;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Releases resources held by the current instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                if (this.Bitstream != null)
                    this.Bitstream.Dispose();
        }
        #endregion
    }
}
