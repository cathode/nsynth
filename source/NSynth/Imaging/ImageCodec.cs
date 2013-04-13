/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Imaging
{
    /// <summary>
    /// Provides shared functionality for codecs that handle bitstreams containing 2D raster image data.
    /// </summary>
    public abstract class ImageCodec : Codec
    {
        #region Properties
        /// <summary>
        /// Gets a <see cref="Size"/> that represents the largest pixel dimensions
        /// of an image that is is supported by the current codec.
        /// </summary>
        public virtual Size MaximumSize
        {
            get
            {
                return new Size(0, 0); // unbounded by default.
            }
        }
        public abstract bool SupportsLayers
        {
            get;
        }
        #endregion
        #region Methods
        public virtual Image CreateImage(Size size)
        {
            return this.CreateImage(size.Width, size.Height);
        }
        public abstract Image CreateImage(int width, int height);
        #endregion
    }
}
