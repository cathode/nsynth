/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Imaging.TIFF
{
    /// <summary>
    /// Represents the way pixels are interpreted in a TIFF image.
    /// </summary>
    public enum TIFFPhotometricInterpretation
    {
        /// <summary>
        /// For bilevel and grayscale images; indicates that a value of 0 represents white.
        /// </summary>
        WhiteIsZero = 0,

        /// <summary>
        /// For bilevel and grayscale images; indicates that a value of 0 represents black.
        /// </summary>
        BlackIsZero = 1,

        /// <summary>
        /// Indicates a color value is represented by red, green, and blue values.
        /// </summary>
        RGB = 2,

        /// <summary>
        /// Indicates that each color represents an index in a color palette lookup table of RGB color values.
        /// </summary>
        Palette = 3,

        /// <summary>
        /// Indicates that the image is used to define a transparency mask.
        /// </summary>
        TransparencyMask = 4,
    }
}
