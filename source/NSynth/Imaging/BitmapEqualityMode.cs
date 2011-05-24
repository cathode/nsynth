/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;

namespace NSynth.Imaging
{
    /// <summary>
    /// Enumerates various methods of comparing bitmap data.
    /// </summary>
    [Flags]
    public enum BitmapEqualityMode
    {
        /// <summary>
        /// Indicates that each pixel value from the first bitmap is compared directly with the corresponding pixel
        /// value from the second bitmap. This mode always yields accurate results.
        /// </summary>
        Direct = 0,

        /// <summary>
        /// Indicates that the pixels in zero or more rows are omitted from the comparison.
        /// </summary>
        RowSkip,

        /// <summary>
        /// Indicates that the pixels in zero or more columns are omitted from the comparison.
        /// </summary>
        ColumnSkip,

        /// <summary>
        /// Indicates that when using equality comparison modes that omit comparisions, the comparison procedure repeats
        /// until all previously omitted comparisons have been done.
        /// </summary>
        Iterative,
    }
}
