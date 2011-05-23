/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;
using System.Text;

namespace NSynth.Imaging.TGA
{
    public enum TGAImageDescriptor : byte
    {
        BottomLeft8BitsAttribute = 7,
        BottomLeft16BitsAttribute = 15,
        BottomRight8BitsAttribute = 7 | 1 << 4,
        BottomRight16BitsAttribute = 15 | 1 << 4,
        TopLeft8BitsAttribute = 7 | 1 << 5,
        TopLeft16BitsAttribute = 15 | 1 << 5,
        TopRight8BitsAttribute = 7 | 1 << 4 | 1 << 5,
        TopRight16BitsAttribute = 15 | 1 << 4 | 1 << 5,
    }
}
