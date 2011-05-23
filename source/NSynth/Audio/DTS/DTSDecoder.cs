/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NSynth.Audio.DTS
{
    /// <summary>
    /// Provides DTS Coherent Acoustics bitstream decoding to audio frames.
    /// </summary>
    public sealed class DTSDecoder : AudioDecoder
    {
        #region Constructors
        public DTSDecoder(Stream bitstream)
        {

        }
        #endregion
        #region Properties
        public override Codec Codec
        {
            get
            {
                return new DTSCodec();
            }
        }
        #endregion
        #region Methods
        public override bool Initialize()
        {
            throw new NotImplementedException();
        }

        public override Frame Decode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Syncs the decoder to the bitstream.
        /// </summary>
        private void Sync()
        {

        }
        #endregion
    }
}
