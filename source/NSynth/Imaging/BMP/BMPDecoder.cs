/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Imaging.BMP
{
    public sealed class BMPDecoder : ImageDecoder
    {

        public override Codec Codec
        {
            get
            {
                return Codecs.BMP;
            }
        }
    }
}
