/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
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
    /// Represents supported methods of image downsampling.
    /// </summary>
    public enum DownsampleMode
    {
        /// <summary>
        /// Horizontal 4:4:4 mode. Conventional format with no downsampling.
        /// </summary>
        H444,

        /// <summary>
        /// Horizontal 4:4:2 mode. Y and U components are sampled for each pixel, V component is sampled every two pixels.
        /// </summary>
        H442,

        /// <summary>
        /// Horizontal 4:2:2 mode. Y component is sampled for each pixel with U and V components sampled every two pixels.
        /// </summary>
        H422,

        /// <summary>
        /// Horizontal 4:2:0 mode. 
        /// </summary>
        H420,
        H411,
        V444,
        V442,
        V422,
        V420,
        V411,
    }
}
