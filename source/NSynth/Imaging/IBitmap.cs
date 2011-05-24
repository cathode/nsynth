/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;
using System.Text;

namespace NSynth.Imaging
{
    /// <summary>
    /// Defines the members that bitmap types must implement.
    /// </summary>
    public interface IBitmap
    {
        #region Properties
        /// <summary>
        /// Gets the height (in pixels) of the bitmap.
        /// </summary>
        int Height
        {
            get;
        }

        /// <summary>
        /// Gets the width (in pixels) of the bitmap.
        /// </summary>
        int Width
        {
            get;
        }

        /// <summary>
        /// Gets the <see cref="ColorFormat"/> that describes the format of color information used by the bitmap.
        /// </summary>
        ColorFormat Format
        {
            get;
        }
        #endregion
        #region Indexers
        /// <summary>
        /// Gets or sets the color value of the pixel at the specified coordinates.
        /// </summary>
        /// <param name="row">The row of the pixel to get or set.</param>
        /// <param name="col">The column of the pixel to get or set.</param>
        /// <returns>The color value of the pixel at the specified coordinates.</returns>
        IColor this[int row, int col]
        {
            get;
            set;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Fills the bitmap with the specified color.
        /// </summary>
        /// <param name="color">The color to fill with.</param>
        void Fill(IColor color);
        #endregion
    }
}
