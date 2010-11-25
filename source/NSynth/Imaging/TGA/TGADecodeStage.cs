/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging.TGA
{
    public enum TGADecodeStage
    {
        None = 0,
        Initialized = 0,
        HeaderDecoded = 1,
        FooterDecoded = 2,
        BitmapDecoded = 3,
        Done = 4,
        Failed = 5,
    }
}
