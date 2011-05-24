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
    /// Represents a two-dimensional grid of 64-bit RGB color values.
    /// </summary>
    public sealed class BitmapRGB64 : Bitmap<ColorRGB64>
    {
         #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB64"/> class.
        /// </summary>
        /// <param name="size">The dimensions (in pixels) of the new bitmap.</param>
        public BitmapRGB64(Size size)
            : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB64"/> class.
        /// </summary>
        /// <param name="size">The dimensions (in pixels) of the new bitmap.</param>
        /// <param name="pixels">The pixel data to initialize the new bitmap with.</param>
        public BitmapRGB64(Size size, ColorRGB64[] pixels)
            : base(size, pixels)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB64"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        public BitmapRGB64(int width, int height)
            : base(width, height)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB64"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        /// <param name="pixels">The pixel data to initialize the new bitmap with.</param>
        public BitmapRGB64(int width, int height, ColorRGB64[] pixels)
            : base(width, height, pixels)
        {
            //Contract.Requires<ArgumentOutOfRangeException>(width >= 0, EX.BitmapWidthTooSmall);
            //Contract.Requires<ArgumentOutOfRangeException>(height >= 0, EX.BitmapHeightTooSmall);
            //Contract.Requires<ArgumentNullException>(pixels != null, "pixels");
            //Contract.Requires<ArgumentException>(pixels.Length == width * height, EX.BitmapPixelArraySizeMismatch);
        }
        #endregion

        protected override ColorRGB64 GetTColor(IColor color)
        {
            throw new NotImplementedException();
        }
    }
}
