/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a two-dimensional grid of 128-bit RGB color values.
    /// </summary>
    public class BitmapRGB : Bitmap<ColorRGB>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB"/> class.
        /// </summary>
        /// <param name="size">The dimensions (in pixels) of the new bitmap.</param>
        public BitmapRGB(Size size)
            : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB"/> class.
        /// </summary>
        /// <param name="size">The dimensions (in pixels) of the new bitmap.</param>
        /// <param name="pixels">The pixel data to initialize the new bitmap with.</param>
        public BitmapRGB(Size size, ColorRGB[] pixels)
            : base(size, pixels)
        {
            //Contract.Requires<ArgumentNullException>(pixels != null, "pixels");
            //Contract.Requires<ArgumentException>(pixels.Length == size.Elements, EX.BitmapPixelArraySizeMismatch);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        public BitmapRGB(int width, int height)
            : base(width, height)
        {
            //Contract.Requires<ArgumentOutOfRangeException>(width >= 0, EX.BitmapWidthTooSmall);
            //Contract.Requires<ArgumentOutOfRangeException>(height >= 0, EX.BitmapHeightTooSmall);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        /// <param name="pixels">The pixel data to initialize the new bitmap with.</param>
        public BitmapRGB(int width, int height, ColorRGB[] pixels)
            : base(width, height, pixels)
        {
            //Contract.Requires<ArgumentOutOfRangeException>(width >= 0, EX.BitmapWidthTooSmall);
            //Contract.Requires<ArgumentOutOfRangeException>(height >= 0, EX.BitmapHeightTooSmall);
            //Contract.Requires<ArgumentNullException>(pixels != null, "pixels");
            //Contract.Requires<ArgumentException>(pixels.Length == width * height, EX.BitmapPixelArraySizeMismatch);
        }
        #endregion
        #region Methods
        protected override ColorRGB GetTColor(IColor color)
        {
            //Contract.Requires(color != null);

            return new ColorRGB(color);
        }
        #endregion
    }
}
