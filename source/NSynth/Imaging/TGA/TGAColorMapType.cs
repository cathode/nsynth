/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved. */
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
