/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth
{
    [Flags]
    public enum FrameCoding
    {
        None    = 0x00,
        Intra   = 0x01,
        Inter   = 0x02,
        Both    = Intra | Inter,
    }
}
