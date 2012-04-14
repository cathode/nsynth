/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;

namespace NSynth.Audio.WAV
{
    /// <summary>
    /// Provides a bitstream decoder that decodes audio samples from a Microsoft WAVE format bitstream.
    /// </summary>
    public sealed class WAVDecoder : AudioDecoder
    {
        #region Fields
        //private WAVBitstreamHeader header;
        #endregion
        #region Constructors
        public WAVDecoder()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WAVDecoder"/> class.
        /// </summary>
        /// <param name="bitstream">The <see cref="Stream"/> to decode from.</param>
        public WAVDecoder(Stream bitstream)
            : base(bitstream)
        {
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the <see cref="Codec"/> of the current <see cref="MediaDecoder"/>.
        /// </summary>
        public override Codec Codec
        {
            get
            {
                return new WAVCodec();
            }
        }
        #endregion
        #region Methods
        public override bool Initialize()
        {
            if (this.Bitstream.Length < 44)
                throw new NotImplementedException();

            //this.header = new WAVBitstreamHeader();
            DataBuffer buffer = new DataBuffer(12);
            throw new NotImplementedException();
        }

        public override Frame Decode()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
