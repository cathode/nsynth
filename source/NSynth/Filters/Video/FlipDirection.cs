/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;

using System.Text;

namespace NSynth.Filters.Video
{
    [Flags]
    public enum FlipDirection
    {
        None = 0x0,
        Horizontal = 0x1,
        Vertical = 0x2,
    }
}
