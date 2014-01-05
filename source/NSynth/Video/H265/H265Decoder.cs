/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2014 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NSynth.Video.H265
{
    /// <summary>
    /// Implements a decoder for H.265 HEVC (High Efficiency Video Coding) bitstreams.
    /// </summary>
    public class H265Decoder : VideoDecoder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="H265Decoder"/> class.
        /// </summary>
        public H265Decoder()
        {

        }

        public override Codec Codec
        {
            get { throw new NotImplementedException(); }
        }
    }
}
