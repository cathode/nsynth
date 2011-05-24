/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

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
            if (pixels == null)
                throw EX.Create(EXCode.ArgumentNull, "pixels");
            if (pixels.Length != size.Elements)
                throw EX.Create(EXCode.BitmapPixelArraySizeMismatch, size.Elements, pixels.Length);

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
            if (width < 0)
                throw EX.Create(EXCode.BitmapWidthTooSmall, "width >= 0", width);
            if (height < 0)
                throw EX.Create(EXCode.BitmapHeightTooSmall, "height >= 0", height);

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
            if (width < 0)
                throw EX.Create(EXCode.BitmapWidthTooSmall, "width >= 0", width);
            if (height < 0)
                throw EX.Create(EXCode.BitmapHeightTooSmall, "height >= 0", height);
            if (pixels == null)
                throw EX.Create(EXCode.ArgumentNull, "pixels");
            if (pixels.Length != width * height)
                throw EX.Create(EXCode.BitmapPixelArraySizeMismatch, size.Elements, pixels.Length);

            this.size = new Size(width, height);
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
        public TColor this[int row, int col]
        {
            get
            {
                return this.pixels[(row * this.Width) + col];
            }
            set
            {
                this.pixels[(row * this.Width) + col] = value;
            }
        }
        

        /// <summary>
        /// Gets or sets the pixel at the specified row and column intersection.
        /// </summary>
        /// <param name="row">The row of the pixel to get or set.</param>
        /// <param name="col">The column of the pixel to get or set.</param>
        /// <returns>The pixel at the specified coordinates.</returns>
        IColor IBitmap.this[int row, int col]
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

        protected abstract TColor GetTColor(IColor color);
        #endregion
    }
}
