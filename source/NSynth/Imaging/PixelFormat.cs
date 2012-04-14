/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents supported formats for pixel data.
    /// </summary>
    public enum PixelFormat
    {
        /// <summary>
        /// Indicates an unknown pixel format.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Indicates 128-bit RGB color, includes 32-bit alpha channel. This is the default pixel format.
        /// </summary>
        RGB128,

        /// <summary>
        /// Indicates 24-bit RGB color.
        /// </summary>
        RGB24,

        /// <summary>
        /// Indicates 32-bit RGB color, includes 8-bit alpha channel.
        /// </summary>
        RGB32,

        /// <summary>
        /// Indicates 48-bit RGB color.
        /// </summary>
        RGB48,

        /// <summary>
        /// Indicates 64-bit RGB color, includes 16-bit alpha channel.
        /// </summary>
        RGB64,

        /// <summary>
        /// Indicates 96-bit RGB color.
        /// </summary>
        RGB96,

        /// <summary>
        /// Indicates 128-bit Y'CbCr color, includes alpha channel.
        /// </summary>
        YCC128,

        /// <summary>
        /// Indicates 160-bit CMYK color, includes alpha channel.
        /// </summary>
        CMYK160,

        /// <summary>
        /// Indicates 128-bit L*A*B color, includes alpha channel.
        /// </summary>
        LAB128,
    }
}
