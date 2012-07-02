/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a more complex bitmap whose image data resides in multiple layers.
    /// </summary>
    public class Image : IEnumerable<Layer>
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Image.Format"/> property.
        /// </summary>
        private readonly ColorFormat format;

        /// <summary>
        /// Holds the layers that comprise the image.
        /// </summary>
        private readonly List<Layer> layers;

        /// <summary>
        /// Backing field for the <see cref="Image.Size"/> property.
        /// </summary>
        private Size size;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="size">The dimensions of the new image.</param>
        /// <param name="format">The color format that the image will use.</param>
        public Image(Size size, ColorFormat format)
        {
            Contract.Requires(format != null);

            this.format = format;
            this.size = size;
            this.layers = new List<Layer>();
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the background layer. This is always the lowest-level layer and is typically a raster layer.
        /// </summary>
        public Layer Background
        {
            get
            {
                if (this.layers.Count > 0)
                    return this.layers[0];
                else
                    return null;
            }
        }

        /// <summary>
        /// Gets the <see cref="ColorFormat"/> of the currnet <see cref="Image"/>.
        /// </summary>
        public ColorFormat Format
        {
            get
            {
                return this.format;
            }
        }

        /// <summary>
        /// Gets the height in pixels of the current <see cref="Image"/>.
        /// </summary>
        public int Height
        {
            get
            {
                return this.size.Height;
            }
        }

        /// <summary>
        /// Gets the size in pixels of the current <see cref="Image"/>.
        /// </summary>
        public Size Size
        {
            get
            {
                return this.size;
            }
        }

        /// <summary>
        /// Gets the width in pixels of the current <see cref="Image"/>.
        /// </summary>
        public int Width
        {
            get
            {
                return this.size.Width;
            }
        }
        #endregion
        #region Methods

        public IBitmap Flatten()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Creates a new <see cref="Layer"/> in the current <see cref="Image"/>.
        /// </summary>
        /// <returns>The new <see cref="Layer"/> that was created.</returns>
        public Layer NewLayer()
        {
            var layer = new Layer(this);

            this.layers.Add(layer);

            return layer;
        }
        #endregion
        public IEnumerator<Layer> GetEnumerator()
        {
            foreach (var layer in this.layers)
                yield return layer;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
