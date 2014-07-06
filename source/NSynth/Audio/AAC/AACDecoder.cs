/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Audio.AAC
{
    /// <summary>
    /// Provides a decoder implementation for the MPEG-4 Advanced Audio Coding (AAC) codec.
    /// </summary>
    public sealed class AACDecoder : AudioDecoder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AACDecoder"/> class.
        /// </summary>
        public AACDecoder()
        {

        }

        public override Codec Codec
        {
            get
            {
                return Codecs.AAC;
            }
        }
    }
}
