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
        private readonly Size size;

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
            this.size = size;
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

            this.size = size;
            this.pixels = pixels;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bitmap&lt;TColor&gt;"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        protected Bitmap(int width, int height)
        {
            Contract.Requires(width > 0);
            Contract.Requires(height > 0);

            this.size = new Size(width, height);
            this.pixels = new TColor[this.size.Elements];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bitmap&lt;TColor&gt;"/> class.
        /// </summary>
        /// <param name="width">The width (in pixels) of the new bitmap.</param>
        /// <param name="height">The height (in pixels) of the new bitmap.</param>
        /// <param name="pixels">An array of T values representing the pixel data for the bitmap.</param>
        protected Bitmap(int width, int height, TColor[] pixels)
        {
            Contract.Requires(width > 0);
            Contract.Requires(height > 0);
            Contract.Requires(pixels != null);
            Contract.Requires(pixels.Length == width * height);

            this.size = new Size(width, height);
            this.pixels = pixels;
        }

        public Bitmap(IBitmap source)
        {
            System.Diagnostics.Contracts.Contract.Requires(source != null);

            this.size = new Size(source.Width, source.Height);
            this.pixels = new TColor[this.size.Elements];
            int i = 0;
            for (int y = 0; y < source.Height; y++)
                for (int x = 0; x < source.Width; x++)
                    this.pixels[i++] = this.GetTColor(source[x, y]);
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
                return this.size.Height;
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
                return this.size.Width;
            }
        }
        public Size Size
        {
            get
            {
                return this.size;
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
        /// Gets or sets the pixel at the specified row and column intersection.
        /// </summary>
        /// <param name="row">The row of the pixel to get or set.</param>
        /// <param name="col">The column of the pixel to get or set.</param>
        /// <returns>The pixel at the specified coordinates.</returns>
        [ContractRuntimeIgnored]
        public TColor this[int row, int col]
        {
            get
            {
                Contract.Requires(row >= 0);
                Contract.Requires(col >= 0);
                Contract.Requires(row < this.Height);
                Contract.Requires(col < this.Width);

                return this.pixels[(row * this.Width) + col];
            }
            set
            {
                Contract.Requires(row >= 0);
                Contract.Requires(col >= 0);
                this.pixels[(row * this.Width) + col] = value;
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

            this.Combine(bitmap, new Point(0, 0), bitmap.size, CombineMode.Normal, mask);
        }

        public virtual void Combine(Bitmap<TColor> bitmap, Point location, Size size, CombineMode mode, Bitmap<TColor> mask)
        {
            Contract.Requires(bitmap != null);

            throw new NotImplementedException();
        }

        protected abstract TColor GetTColor(IColor color);

        [ContractInvariantMethod]
        private void __ContractInvariants()
        {
            Contract.Invariant(this.Pixels.Length == this.Size.Elements);
            Contract.Invariant(this.Width * this.Height == this.Size.Elements);
            Contract.Invariant(this.Width == this.Size.Width);
            Contract.Invariant(this.Height == this.Size.Height);
        }
        #endregion
        
    }
}
