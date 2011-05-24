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

namespace NSynth.Imaging.TGA
{
    /// <summary>
    /// Indicates the order which pixel data is transferred from the bitstream to the screen.
    /// </summary>
    public enum TGAPixelOrder
    {
        /// <summary>
        /// Indicates that the first pixel is the bottom-left corner of the bitmap.
        /// </summary>
        BottomLeft  = 0x00, // bit5 == 0, bit4 == 0

        /// <summary>
        /// Indicates that the first pixel is the bottom-right corner of the image.
        /// </summary>
        BottomRight = 0x10, // bit5 == 0, bit4 == 1

        /// <summary>
        /// Indicates that the first pixel is the top-left corner of the image.
        /// </summary>
        TopLeft     = 0x20, // bit5 == 1, bit4 == 0,

        /// <summary>
        /// Indicates that the first pixel is the top-right corner of the image.
        /// </summary>
        TopRight    = 0x30, // bit5 == 1, bit4 == 1,
    }
}
