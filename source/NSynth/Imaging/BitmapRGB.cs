/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Diagnostics.Contracts;

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
            Contract.Requires(pixels != null);
            Contract.Requires(pixels.Length == size.Elements);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        public BitmapRGB(int width, int height)
            : base(width, height)
        {
            Contract.Requires(width >= 0);
            Contract.Requires(height >= 0);
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
            Contract.Requires(width >= 0);
            Contract.Requires(height >= 0);
            Contract.Requires(pixels != null);
            Contract.Requires(pixels.Length == (width * height));
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the <see cref="ColorFormat"/> of the bitmap.
        /// </summary>
        public override ColorFormat Format
        {
            get
            {
                return ColorFormat.RGB;
            }
        }
        #endregion
        #region Methods

        protected override ColorRGB GetTColor(IColor color)
        {
            return new ColorRGB(color);
        }
        #endregion
    }
}
