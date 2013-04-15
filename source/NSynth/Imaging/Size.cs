/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Runtime.InteropServices;
using System.Diagnostics.Contracts;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents dimensions as width and height.
    /// </summary>
    public struct Size
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Size.Width"/> property.
        /// </summary>
        private int width;
        /// <summary>
        /// Backing field for the <see cref="Size.Height"/> property.
        /// </summary>
        private int height;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> struct.
        /// </summary>
        /// <param name="width">The width value.</param>
        /// <param name="height">The height value.</param>
        public Size(int width, int height)
        {
            Contract.Requires(width >= 0);
            Contract.Requires(height >= 0);
            //Contract.Ensures(this.Width == width);
            //Contract.Ensures(this.Height == height);
                
            this.height = height;
            this.width = width;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the height value.
        /// </summary>
        public int Height
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);

                return this.height;
            }
            set
            {
                Contract.Requires(value >= 0);

                this.height = value;
            }
        }

        /// <summary>
        /// Gets the width value.
        /// </summary>
        public int Width
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);

                return this.width;
            }
            set
            {
                Contract.Requires(value >= 0);

                this.width = value;
            }
        }

        /// <summary>
        /// Gets the number of elements that would be represented if a two dimensional grid was created using the current <see cref="Size"/>.
        /// </summary>
        public int Elements
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return this.width * this.height;
            }
        }
        #endregion
        #region Methods
        [Pure]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        [Pure]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.height >= 0);
            Contract.Invariant(this.width >= 0);
            Contract.Invariant(this.Elements == this.width * this.height);
        }
        #endregion
        #region Operators
        public static bool operator ==(Size left, Size right)
        {
            return (left.Width == right.Width) && (left.Height == right.Height);
        }
        public static bool operator !=(Size left, Size right)
        {
            return (left.Width != right.Width) || (left.Height != right.Height);
        }
        #endregion
    }
}
