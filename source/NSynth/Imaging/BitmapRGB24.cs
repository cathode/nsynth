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
    /// Represents a two-dimensional grid of 24-bit RGB color values.
    /// </summary>
    public sealed class BitmapRGB24 : Bitmap<ColorRGB24>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB24"/> class.
        /// </summary>
        /// <param name="size">The dimensions (in pixels) of the new bitmap.</param>
        public BitmapRGB24(Size size)
            : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB24"/> class.
        /// </summary>
        /// <param name="size">The dimensions (in pixels) of the new bitmap.</param>
        /// <param name="pixels">The pixel data to initialize the new bitmap with.</param>
        public BitmapRGB24(Size size, ColorRGB24[] pixels)
            : base(size, pixels)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB24"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        public BitmapRGB24(int width, int height)
            : base(width, height)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB24"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        /// <param name="pixels">The pixel data to initialize the new bitmap with.</param>
        public BitmapRGB24(int width, int height, ColorRGB24[] pixels)
            : base(width, height, pixels)
        {
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets a <see cref="ColorFormat"/> that describes how color information is stored in the bitmap.
        /// </summary>
        public override ColorFormat Format
        {
            get
            {
                return ColorFormat.RGB24;
            }
        }
        #endregion
        #region Methods
        public override void Blend(Bitmap<ColorRGB24> bitmap, Point location, Size size, BlendMode mode, Bitmap<ColorRGB24> mask)
        {
            int xMax = Math.Min(size.Width, this.Width);
            int yMax = Math.Min(size.Height, this.Height);
            int xStart = Math.Min(Math.Min(location.X, this.Width), 0);
            int yStart = Math.Max(Math.Min(location.Y, this.Height), 0);

            var pix = this.Pixels;
            
            // Assume blend mode normal w/ mask
            for (int y = yStart, v=0; y < yMax; y++, v++)
            {
                for (int x = xStart, u=0; x < xMax; x++, u++)
                {
                    this[y, x] = this[y, x].LinearInterpolate(bitmap[v, u], mask[v, u].Red / 255.0, mask[v, u].Green / 255.0, mask[v, u].Blue / 255.0);
                }
            }

        }
        protected override ColorRGB24 GetTColor(IColor color)
        {
            return new ColorRGB24((byte)(color.Red * 255), (byte)(color.Green * 255), (byte)(color.Blue * 255));
        }
        #endregion


    }
}
