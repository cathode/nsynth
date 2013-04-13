/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;
using System.Text;

namespace NSynth.Imaging.TGA
{
    public enum TGAImageDescriptor : byte
    {
        BottomLeft = 0,
        BottomRight = 1 << 4,
        TopLeft = 1 << 5,
        TopRight = 1 << 5 | 1 << 4,
    }
}
