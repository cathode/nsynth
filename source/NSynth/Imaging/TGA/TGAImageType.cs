/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Imaging.TGA
{
    /// <summary>
    /// Enumerates supported types of TGA images.
    /// </summary>
    public enum TGAImageType : byte
    {
        /// <summary>
        /// Indicates the stream contains no image data.
        /// </summary>
        NoImageData = 0,

        /// <summary>
        /// Indicates the stream contains uncompressed, color-mapped image data.
        /// </summary>
        UncompressedColorMapped = 1,

        /// <summary>
        /// Indicates the stream contains uncompressed, true-color image data.
        /// </summary>
        UncompressedTrueColor = 2,

        /// <summary>
        /// Indicates the stream contains uncompressed, black-and-white image data.
        /// </summary>
        UncompressedBlackAndWhite = 3,

        /// <summary>
        /// Indicates the stream contains color-mapped image data, which is compressed using run-length encoding.
        /// </summary>
        RunLengthEncodedColorMapped = 9,

        /// <summary>
        /// Indicates the stream contains true-color image data, which is compressed using run-length encoding.
        /// </summary>
        RunLengthEncodedTrueColor = 10,

        /// <summary>
        /// Indicates the stream contains black-and-white image data, which is compresssed using run-length encoding.
        /// </summary>
        RunLengthEncodedBlackAndWhite = 11,
    }
}
