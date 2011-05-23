/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a two-dimensional grid of 32-bit RGB color values.
    /// </summary>
    public sealed class BitmapRGB32 : Bitmap<ColorRGB32>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB32"/> class.
        /// </summary>
        /// <param name="size">The dimensions (in pixels) of the new bitmap.</param>
        public BitmapRGB32(Size size)
            : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB32"/> class.
        /// </summary>
        /// <param name="size">The dimensions (in pixels) of the new bitmap.</param>
        /// <param name="pixels">The pixel data to initialize the new bitmap with.</param>
        public BitmapRGB32(Size size, ColorRGB32[] pixels)
            : base(size, pixels)
        {
            //Contract.Requires<ArgumentNullException>(pixels != null, "pixels");
            //Contract.Requires<ArgumentException>(pixels.Length == size.Elements, EX.BitmapPixelArraySizeMismatch);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB32"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        public BitmapRGB32(int width, int height)
            : base(width, height)
        {
            //Contract.Requires<ArgumentOutOfRangeException>(width >= 0, EX.BitmapWidthTooSmall);
            //Contract.Requires<ArgumentOutOfRangeException>(height >= 0, EX.BitmapHeightTooSmall);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB32"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        /// <param name="pixels">The pixel data to initialize the new bitmap with.</param>
        public BitmapRGB32(int width, int height, ColorRGB32[] pixels)
            : base(width, height, pixels)
        {
            //Contract.Requires<ArgumentOutOfRangeException>(width >= 0, EX.BitmapWidthTooSmall);
            //Contract.Requires<ArgumentOutOfRangeException>(height >= 0, EX.BitmapHeightTooSmall);
            //Contract.Requires<ArgumentNullException>(pixels != null, "pixels");
            //Contract.Requires<ArgumentException>(pixels.Length == width * height, EX.BitmapPixelArraySizeMismatch);
        }
        #endregion

        protected override ColorRGB32 GetTColor(IColor color)
        {
            throw new NotImplementedException();
        }
    }
}
