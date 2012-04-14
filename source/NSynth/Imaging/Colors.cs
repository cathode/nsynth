/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;

using System.Text;

namespace NSynth.Imaging
{
    /// <summary>
    /// Provides commonly used color values.
    /// </summary>
    public static class Colors
    {
        #region Properties
        /// <summary>
        /// Gets an <see cref="IColor"/> representing black.
        /// </summary>
        public static IColor Black
        {
            get
            {
                return new ColorRGB(0.0f, 0.0f, 0.0f, 1.0f);
            }
        }

        /// <summary>
        /// Gets an <see cref="IColor"/> representing white.
        /// </summary>
        public static IColor White
        {
            get
            {
                return new ColorRGB(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
        #endregion
    }
}
