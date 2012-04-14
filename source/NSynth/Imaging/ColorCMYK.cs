/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a color using 4 color components; cyan, magenta, yellow, and key (black).
    /// </summary>
    [Serializable]
    public struct ColorCMYK : IColor
    {
        #region Fields

        /// <summary>
        /// Backing field for the <see cref="ColorCMYK.C"/> property.
        /// </summary>
        private float c;

        /// <summary>
        /// Backing field for the <see cref="ColorCMYK.M"/> property.
        /// </summary>
        private float m;

        /// <summary>
        /// Backing field for the <see cref="ColorCMYK.Y"/> property.
        /// </summary>
        private float y;

        /// <summary>
        /// Backing field for the <see cref="ColorCMYK.K"/> property.
        /// </summary>
        private float k;

        /// <summary>
        /// Backing field for the <see cref="ColorCMYK.Alpha"/> property.
        /// </summary>
        private float alpha;

        #endregion
        #region Properties

        /// <value>
        /// Gets or sets the alpha (transparency) value of the current <see cref="ColorCMYK"/>.
        /// </value>
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
        /// Gets or sets the cyan component of the current <see cref="ColorCMYK"/>.
        /// </summary>
        public float C
        {
            get
            {
                return this.c;
            }
            set
            {
                this.c = value;
            }
        }

        /// <summary>
        /// Gets or sets the magenta component of the current <see cref="ColorCMYK"/>.
        /// </summary>
        public float M
        {
            get
            {
                return this.m;
            }
            set
            {
                this.m = value;
            }
        }

        /// <summary>
        /// Gets or sets the yellow component of the current <see cref="ColorCMYK"/>.
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
        /// Gets or sets the key (black) component of the current <see cref="ColorCMYK"/>.
        /// </summary>
        public float K
        {
            get
            {
                return this.k;
            }
            set
            {
                this.k = value;
            }
        }
        #endregion

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
    }
}