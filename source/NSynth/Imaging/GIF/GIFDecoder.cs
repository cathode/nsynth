/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Imaging.GIF
{
    public sealed class GIFDecoder : ImageSourceFilter
    {
        public override Codec Codec
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
