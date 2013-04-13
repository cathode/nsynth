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
    /// <summary>
    /// Indicates the type of color-map (if any) included with a TGA image.
    /// </summary>
    public enum TGAColorMapType : byte
    {
        /// <summary>
        /// Indicates no color-map data is included with the image.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Indicates that a color-map is included with the image.
        /// </summary>
        ColorMapped = 0x1,
    }
}
