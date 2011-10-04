/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents visual data that can be described by a grid of pixels.
    /// </summary>
    public class Image : IBitmap, IEnumerable<Layer>
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Image.Bitmap"/> property.
        /// </summary>
        private IBitmap bitmap;
        private readonly List<Layer> layers = new List<Layer>();
        private Size size;
        #endregion
        #region Constructors
        public Image(Size size)
        {
            this.size = size;
        }
        public Image(int width, int height)
        {
            Contract.Requires(width >= 0);
            Contract.Requires(height >= 0);

            this.size = new Size(width, height);
        }
        #endregion
        #region Properties

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

        public IEnumerator<Layer> GetEnumerator()
        {
            foreach (var layer in this.layers)
                yield return layer;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        public ColorFormat Format
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IColor this[int x, int y]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Fill(IColor color)
        {
            throw new NotImplementedException();
        }
    }
}
