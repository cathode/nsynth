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
        /// <summary>
        /// Indicates no color channels.
        /// </summary>
        None = 0x0000,

        /// <summary>
        /// Indicates the alpha (transparency) channel.
        /// </summary>
        Alpha = 0x0001,

        /// <summary>
        /// Red channel, part of RGB/RGBA color.
        /// </summary>
        Red = 0x0002,
        
        /// <summary>
        /// Green channel, part of RGB/RGBA color.
        /// </summary>
        Green = 0x0004,

        /// <summary>
        /// Blue channel, part of RGB/RGBA color.
        /// </summary>
        Blue = 0x0008,

        /// <summary>
        /// Luma channel, part of YCbCr color.
        /// </summary>
        Luma = 0x0010,

        /// <summary>
        /// Blue-difference chroma channel, part of YCbCr color.
        /// </summary>
        ChromaBlueDelta = 0x0020,

        /// <summary>
        /// Red-difference chroma channel, part of YCbCr color.
        /// </summary>
        ChromaRedDelta = 0x0040,

        /// <summary>
        /// Cyan channel, part of CMYK color.
        /// </summary>
        Cyan = 0x0080,

        /// <summary>
        /// Magenta channel, part of CMYK color.
        /// </summary>
        Magenta = 0x0100,

        /// <summary>
        /// Yellow channel, part of CMYK color.
        /// </summary>
        Yellow = 0x0200,

        /// <summary>
        /// Black (Key) channel, part of CMYK color.
        /// </summary>
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
