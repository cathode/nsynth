/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Imaging.TGA
{
    /// <summary>
    /// Represents an image with metadata specific to the Truevision TARGA (TGA) format.
    /// </summary>
    public sealed class TGAImage : Image
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="UseRunLengthEncoding"/> property.
        /// </summary>
        private bool useRunLengthEncoding = true;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TGAImage"/> class.
        /// </summary>
        public TGAImage()
            : base(0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TGAImage"/> class.
        /// </summary>
        /// <param name="bitmap">The bitmap of the new image.</param>
        public TGAImage(IBitmap bitmap)
            : base(0, 0)
        {
            this.Bitmap = bitmap;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether to use run-length encoding compression when encoding, or whether RLE compression was used on the bitstream that was decoded.
        /// </summary>
        public bool UseRunLengthEncoding
        {
            get
            {
                return this.useRunLengthEncoding;
            }
            set
            {
                this.useRunLengthEncoding = value;
            }
        }
        #endregion
    }
}
