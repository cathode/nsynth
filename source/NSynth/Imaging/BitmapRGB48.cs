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
    /// Represents a two-dimensional grid of 48-bit RGB color values.
    /// </summary>
    public sealed class BitmapRGB48 : Bitmap<ColorRGB48>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB48"/> class.
        /// </summary>
        /// <param name="size">The dimensions (in pixels) of the new bitmap.</param>
        public BitmapRGB48(Size size)
            : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB48"/> class.
        /// </summary>
        /// <param name="size">The dimensions (in pixels) of the new bitmap.</param>
        /// <param name="pixels">The pixel data to initialize the new bitmap with.</param>
        public BitmapRGB48(Size size, ColorRGB48[] pixels)
            : base(size, pixels)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB48"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        public BitmapRGB48(int width, int height)
            : base(width, height)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB48"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        /// <param name="pixels">The pixel data to initialize the new bitmap with.</param>
        public BitmapRGB48(int width, int height, ColorRGB48[] pixels)
            : base(width, height, pixels)
        {
        }
        #endregion
        #region Properties
        public override ColorFormat Format
        {
            get
            {
                return ColorFormat.RGB48;
            }
        }
        #endregion
        #region Methods
        protected override ColorRGB48 GetTColor(IColor color)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
