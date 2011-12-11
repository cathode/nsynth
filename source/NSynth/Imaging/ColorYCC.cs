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
    /// Represents a color in the Y'Cb'Cr color space.
    /// </summary>
    public struct ColorYCC : IColor
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="ColorYCC.Y"/> property.
        /// </summary>
        private float y;

        /// <summary>
        /// Backing field for the <see cref="ColorYCC.Cb"/> property.
        /// </summary>
        private float cb;

        /// <summary>
        /// Backing field for the <see cref="ColorYCC.Cr"/> property.
        /// </summary>
        private float cr;

        /// <summary>
        /// Backing field for the <see cref="ColorYCC.Alpha"/> value.
        /// </summary>
        private float alpha;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorYCC"/> struct.
        /// </summary>
        /// <param name="y">The value of the luma component of the new instance.</param>
        /// <param name="cb">The value of the blue-difference component of the new instance.</param>
        /// <param name="cr">The value of the red-difference component of the new instance.</param>
        public ColorYCC(int y, int cb, int cr)
        {
            this.y = y;
            this.cb = cb;
            this.cr = cr;
            this.alpha = int.MaxValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorYCC"/> struct.
        /// </summary>
        /// <param name="y">The value of the luma component of the new instance.</param>
        /// <param name="cb">The value of the blue-difference component of the new instance.</param>
        /// <param name="cr">The value of the red-difference component of the new instance.</param>
        /// <param name="alpha">The value of the alpha (opacity) component of the new instance.</param>
        public ColorYCC(int y, int cb, int cr, int alpha)
        {
            this.y = y;
            this.cb = cb;
            this.cr = cr;
            this.alpha = alpha;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the alpha (opacity) of the current <see cref="ColorYCC"/>.
        /// </summary>
        public float Alpha
        {
            get
            {
                return this.alpha;
            }
            set
            {
                this.alpha = value;
            }
        }

        /// <summary>
        /// Gets or sets the luma component of the current <see cref="ColorYCC"/>.
        /// </summary>
        public float Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        /// <summary>
        /// Gets or sets the blue-difference component of the current <see cref="ColorYCC"/>.
        /// </summary>
        public float Cb
        {
            get
            {
                return this.cb;
            }
            set
            {
                this.cb = value;
            }
        }

        /// <summary>
        /// Gets or sets the red-difference component of the current <see cref="ColorYCC"/>.
        /// </summary>
        public float Cr
        {
            get
            {
                return this.cr;
            }
            set
            {
                this.cr = value;
            }
        }

        float IColor.Red
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

        float IColor.Green
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

        float IColor.Blue
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
        #endregion
    }
}
