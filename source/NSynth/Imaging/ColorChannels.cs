/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging
{
    /// <summary>
    /// Enumerates supported color channels.
    /// </summary>
    [Flags]
    public enum ColorChannels
    {
        None = 0x0000,

        Alpha = 0x0001,

        Red = 0x0002,
        Green = 0x0004,
        Blue = 0x0008,

        Luma = 0x0010,
        ChromaBlueDelta = 0x0020,
        ChromaRedDelta = 0x0040,

        Cyan = 0x0080,
        Magenta = 0x0100,
        Yellow = 0x0200,
        Black = 0x0400,

        L = 0x0800,
        A = 0x1000,
        B = 0x2000,

        Unused = 0x4000,

        RGB = Red | Green | Blue,
        RGBA = RGB | Alpha,
        CMYK = Cyan | Magenta | Yellow | Black,
        CMYKA = CMYK | Alpha,
        YCC = Luma | ChromaBlueDelta | ChromaRedDelta,
        YCCA = YCC | Alpha,
    }
}
