/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Diagnostics.Contracts;
using System;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a generic bitmap.
    /// </summary>
    /// <typeparam name="TColor">The type of the color used to represent pixel values.</typeparam>
    public abstract class Bitmap<TColor> : IBitmap where TColor : IColor
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Bitmap&lt;TColor&gt;.Size"/> property.
        /// </summary>
        private readonly int width;

        private readonly int height;

        /// <summary>
        /// Holds the pixel data for the bitmap.
        /// </summary>
        private readonly TColor[] pixels;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Bitmap&lt;TColor&gt;"/> class.
        /// </summary>
        /// <param name="size">The dimensions (in pixels) of the new bitmap.</param>
        protected Bitmap(Size size)
        {
            this.width = size.Width;
            this.height = size.Height;
            this.pixels = new TColor[size.Elements];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bitmap&lt;TColor&gt;"/> class.
        /// </summary>
        /// <param name="size">The dimensions (in pixels) of the new bitmap.</param>
        /// <param name="pixels">The pixel data to initialize the new bitmap with.</param>
        protected Bitmap(Size size, TColor[] pixels)
        {
            Contract.Requires(pixels != null);
            Contract.Requires(pixels.Length == size.Elements);

            this.width = size.Width;
            this.height = size.Height;
            this.pixels = pixels;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bitmap&lt;TColor&gt;"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        protected Bitmap(int width, int height)
        {
            Contract.Requires(width >= 0);
            Contract.Requires(height >= 0);

            this.width = width;
            this.height = height;
            this.pixels = new TColor[width * height];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bitmap&lt;TColor&gt;"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        /// <param name="pixels">An array of T values representing the pixel data for the bitmap.</param>
        protected Bitmap(int width, int height, TColor[] pixels)
        {
            Contract.Requires(width >= 0);
            Contract.Requires(height >= 0);
            Contract.Requires(pixels != null);
            Contract.Requires(pixels.Length == width * height);

            this.width = width;
            this.height = height;
            this.pixels = pixels;
        }

        #endregion
        #region Properties
        /// <summary>
        /// Gets the height (in pixels) of the bitmap.
        /// </summary>
        public int Height
        {
            get
            {
                return this.height;
            }
        }

        /// <summary>
        /// Gets the array containing the pixel data for the bitmap.
        /// </summary>
        public TColor[] Pixels
        {
            get
            {
                return this.pixels;
            }
        }

        /// <summary>
        /// Gets the width (in pixels) of the bitmap.
        /// </summary>
        public int Width
        {
            get
            {
                return this.width;
            }
        }

        /// <summary>
        /// Gets the size of the bitmap in pixels.
        /// </summary>
        public Size Size
        {
            get
            {
                Contract.Ensures(Contract.Result<Size>().Width == this.Width);
                Contract.Ensures(Contract.Result<Size>().Height == this.Height);

                return new Size(this.Width, this.Height);
            }
        }

        /// <summary>
        /// Gets a <see cref="ColorFormat"/> that describes how color information is stored in the bitmap.
        /// </summary>
        public abstract ColorFormat Format
        {
            get;
        }
        #endregion
        #region Indexers
        /// <summary>
        /// Gets or sets the pixel at the specified coordinates.
        /// </summary>
        /// <param name="x">The X-coordinate (column) of the pixel to get or set.</param>
        /// <param name="y">The Y-coordinate (row) of the pixel to get or set.</param>
        /// <returns>The pixel at the specified coordinates.</returns>
        public TColor this[int x, int y]
        {
            get
            {
                Contract.Requires(y >= 0);
                Contract.Requires(x >= 0);
                Contract.Requires(y < this.Height);
                Contract.Requires(x < this.Width);

                return this.pixels[(y * this.Width) + x];
            }
            set
            {
                Contract.Requires(y >= 0);
                Contract.Requires(x >= 0);
                this.pixels[(y * this.Width) + x] = value;
            }
        }
        

        /// <summary>
        /// Gets or sets the pixel at the specified row and column intersection.
        /// </summary>
        /// <param name="row">The row of the pixel to get or set.</param>
        /// <param name="col">The column of the pixel to get or set.</param>
        /// <returns>The pixel at the specified coordinates.</returns>
        IColor IBitmap.this[int col, int row]
        {
            get
            {
                return this.pixels[(row * this.Width) + col];
            }
            set
            {
                this.pixels[(row * this.Width) + col] = this.GetTColor(value);
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Fills the entire bitmap with the specified color.
        /// </summary>
        /// <param name="color">The color to fill with.</param>
        public void Fill(TColor color)
        {
            var px = this.pixels;
            for (int i = 0; i < px.Length; i++)
                px[i] = color;
        }

        /// <summary>
        /// Fills the entire bitmap with the specified color.
        /// </summary>
        /// <param name="color">The color to fill with.</param>
        public void Fill(IColor color)
        {
            this.Fill(this.GetTColor(color));
        }

        /// <summary>
        /// Blends the specified bitmap with the current bitmap.
        /// </summary>
        /// <param name="bitmap"></param>
        public void Combine(Bitmap<TColor> bitmap)
        {
            Contract.Requires(bitmap != null);

            this.Combine(bitmap, new Point(0, 0), bitmap.Size, CombineMode.Normal, null);
        }

        /// <summary>
        /// Blends the specified bitmap with the current bitmap.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="location"></param>
        public void Combine(Bitmap<TColor> bitmap, Point location)
        {
            Contract.Requires(bitmap != null);

            this.Combine(bitmap, location, bitmap.Size, CombineMode.Normal, null);
        }

        public void Combine(Bitmap<TColor> bitmap, Point location, Bitmap<TColor> mask)
        {
            Contract.Requires(bitmap != null);

            this.Combine(bitmap, location, bitmap.Size, CombineMode.Normal, mask);
        }

        public void Combine(Bitmap<TColor> bitmap, Bitmap<TColor> mask)
        {
            Contract.Requires(bitmap != null);

            this.Combine(bitmap, new Point(0, 0), bitmap.Size, CombineMode.Normal, mask);
        }

        public virtual void Combine(Bitmap<TColor> bitmap, Point location, Size size, CombineMode mode, Bitmap<TColor> mask)
        {
            Contract.Requires(bitmap != null);

            throw new NotImplementedException();
        }

        protected abstract TColor GetTColor(IColor color);

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            //Contract.Invariant(this.Size.Width == this.Width);
            //Contract.Invariant(this.Size.Height == this.Height);
        }
        #endregion
        
    }
}
