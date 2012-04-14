/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Filters.Internal.Video
{
    /// <summary>
    /// Enumerates supported image resizing algorithms for the <see cref="Resize"/> filter.
    /// </summary>
    public enum ResizeMethod
    {
        /// <summary>
        /// Indicates nearest-neighbor resize method. Very fast, poor quality.
        /// </summary>
        NearestNeighbor = 0x0,

        /// <summary>
        /// Indicates bilinear resize method. Provides good speed.
        /// </summary>
        Bilinear,

        /// <summary>
        /// Indicates trilinear resize method. Provides decent speed.
        /// </summary>
        Trilinear,

        /// <summary>
        /// Indicates bicubic resize method. Better quality than bilinear or trilinear.
        /// </summary>
        Bicubic,
    }
}
