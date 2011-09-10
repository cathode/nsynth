/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Imaging.PNG
{
    public sealed class PNGDecoder : ImageDecoder
    {
        public override Codec Codec
        {
            get
            {
                return Codecs.PNG;
            }
        }

        public override Frame Decode()
        {
            throw new NotImplementedException();
        }
    }
}
