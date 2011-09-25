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
            Contract.Requires(pixels != null);
            Contract.Requires(pixels.Length == size.Elements);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapRGB32"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        public BitmapRGB32(int width, int height)
            : base(width, height)
        {
            Contract.Requires(width >= 0);
            Contract.Requires(height >= 0);
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
            Contract.Requires(width >= 0);
            Contract.Requires(height >= 0);
            Contract.Requires(pixels != null);
            Contract.Requires(pixels.Length == width * height);
        }

        public BitmapRGB32(IBitmap source)
            : base(source)
        {
            Contract.Requires(source != null);
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
                return ColorFormat.RGB32;
            }
        }
        #endregion
        #region Methods

        public override void Combine(Bitmap<ColorRGB32> bitmap, Point location, Size size, CombineMode mode, Bitmap<ColorRGB32> mask)
        {
            int xMax = Math.Min(Math.Min(size.Width + location.X, this.Width), (mask == null) ? bitmap.Width + location.X : Math.Min(bitmap.Width + location.X, mask.Width + location.X));
            int yMax = Math.Min(Math.Min(size.Height + location.Y, this.Height), (mask == null) ? bitmap.Height + location.Y : Math.Min(bitmap.Height + location.Y, mask.Height + location.Y));
            int xStart = Math.Max(Math.Min(location.X, this.Width), 0);
            int yStart = Math.Max(Math.Min(location.Y, this.Height), 0);

            var pix = this.Pixels;

            if (mask != null)
            {
                for (int y = yStart, v = 0; y < yMax; y++, v++)
                {
                    for (int x = xStart, u = 0; x < xMax; x++, u++)
                    {
                        var mx = (v < mask.Height || u < mask.Width) ? mask[v, u] : new ColorRGB32(0, 0, 0, 255);
                        var f = ((mx.Red + mx.Blue + mx.Green) / 3 / 255f) * (mx.Alpha / 255f);
                        var tx = this[y, x];
                        var bx = bitmap[v,u];
                        this[y, x] = (bx * f) + (tx * (1.0 - f));
                    }
                }
            }
            else
            {
                for (int y = yStart, v = 0; y < yMax; y++, v++)
                {
                    for (int x = xStart, u = 0; x < xMax; x++, u++)
                    {
                        var bx = bitmap[v, u];
                        var t = (bx.Alpha / 255f);
                        this[y, x] = (bx * t) + (this[y, x] * (1f - t));
                    }
                }
            }
        }

        public void Fill(ColorRGB32 color, Bitmap<ColorRGB32> mask)
        {
            Contract.Requires(mask != null);
            Contract.Requires(this.Size == mask.Size);

            for (int y = 0; y < this.Height; y++)
                for (int x = 0; x < this.Width; x++)
                {
                    var px = this[y, x];
                    var mx = mask[y, x];
                    var a = (((mx.Red + mx.Blue + mx.Green) / 3) * (mx.Alpha / 255f)) / 255f;
                    this[y, x] = (color * a) + (px * (1.0 - a));
                }
        }

        protected override ColorRGB32 GetTColor(IColor color)
        {
            return new ColorRGB32(color.Red, color.Green, color.Blue, color.Alpha);
        }
        #endregion
    }
}
