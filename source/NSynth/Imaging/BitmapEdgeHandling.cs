/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Imaging
{
    /// <summary>
    /// Enumerates supported methods of dealing with off-bitmap pixel coordinates.
    /// </summary>
    public enum BitmapEdgeHandling
    {
        /// <summary>
        /// Indicates that out-of-bounds pixel coordinates are treated as a pixel with all channels at 0.
        /// </summary>
        Zeroed,

        /// <summary>
        /// Indicates that out-of-bounds pixel coordinates are treated as the nearest in-bounds pixel.
        /// </summary>
        NearestPixel,

        /// <summary>
        /// Indicates that out-of-bounds pixel coordinates are treated as a mirror across the closest edge.
        /// </summary>
        MirrorAcrossEdge,

        /// <summary>
        /// Indicates that out-of-bounds pixel coordinates are treated as a wrap across to the opposite of the closest edge.
        /// </summary>
        WrapAcrossBitmap,
    }
}
