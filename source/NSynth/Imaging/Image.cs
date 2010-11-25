/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved. */

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a bitmap with associated metadata.
    /// </summary>
    public abstract class Image
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Image.Bitmap"/> property.
        /// </summary>
        private IBitmap bitmap;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="IBitmap"/> that contains the actual pixel data of the current <see cref="Image"/>.
        /// </summary>
        /// <remarks>
        /// In cases where the image contains more than one layer, this is the first layer, background layer, primary layer, etc.
        /// </remarks>
        public IBitmap Bitmap
        {
            get
            {
                return this.bitmap;
            }
            set
            {
                this.bitmap = value;
            }
        }

        /// <summary>
        /// Gets the width in pixels of the current <see cref="Image"/>.
        /// </summary>
        public int Width
        {
            get
            {
                return (this.Bitmap != null) ? this.Bitmap.Width : 0;
            }
        }

        /// <summary>
        /// Gets the height in pixels of the current <see cref="Image"/>.
        /// </summary>
        public int Height
        {
            get
            {
                return (this.Bitmap != null) ? this.Bitmap.Height : 0;
            }
        }

        #endregion
    }
}
