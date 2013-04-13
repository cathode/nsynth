/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Audio.Vorbis
{
    /// <summary>
    /// Provides a decoder implementation for the Vorbis audio codec.
    /// </summary>
    public sealed class VorbisDecoder : AudioDecoder
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="VorbisDecoder"/> class.
        /// </summary>
        public VorbisDecoder()
        {

        }

        public override bool Initialize()
        {
            throw new NotImplementedException();
        }

        public override Codec Codec
        {
            get
            {
                return Codecs.Vorbis;
            }
        }
    }
}
