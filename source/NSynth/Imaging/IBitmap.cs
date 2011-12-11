/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.Contracts;

namespace NSynth.Imaging
{
    /// <summary>
    /// Defines the members that bitmap types must implement.
    /// </summary>
    [ContractClass(typeof(_IBitmapContracts))]
    public interface IBitmap
    {
        #region Properties
        /// <summary>
        /// Gets the height (in pixels) of the bitmap.
        /// </summary>
        int Height
        {
            get;
        }

        /// <summary>
        /// Gets the width (in pixels) of the bitmap.
        /// </summary>
        int Width
        {
            get;
        }

        /// <summary>
        /// Gets a <see cref="ColorFormat"/> that describes how color information is stored in the bitmap.
        /// </summary>
        ColorFormat Format
        {
            get;
        }
        #endregion
        #region Indexers
        /// <summary>
        /// Gets or sets the pixel at the specified coordinates.
        /// </summary>
        /// <param name="x">The X-coordinate (column) of the pixel to get or set.</param>
        /// <param name="y">The Y-coordinate (row) of the pixel to get or set.</param>
        /// <returns>The pixel at the specified coordinates.</returns>
        IColor this[int x, int y]
        {
            get;
            set;
        }
        #endregion
    }
    [ContractClassFor(typeof(IBitmap))]
    internal abstract class _IBitmapContracts : IBitmap
    {
        public int Height
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return default(int);
            }
        }

        public int Width
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return default(int);
            }
        }

        ColorFormat IBitmap.Format
        {
            get
            {
                Contract.Ensures(Contract.Result<ColorFormat>() != null);
                return default(ColorFormat);
            }
        }

        IColor IBitmap.this[int x, int y]
        {
            get
            {
                Contract.Requires(x >= 0);
                Contract.Requires(x < this.Width);
                Contract.Requires(y >= 0);
                Contract.Requires(y < this.Height);
                Contract.Ensures(Contract.Result<IColor>() != null);

                return default(IColor);
            }
            set
            {
                Contract.Requires(x >= 0);
                Contract.Requires(x < this.Width);
                Contract.Requires(y >= 0);
                Contract.Requires(y < this.Height);
                Contract.Requires(value != null);
            }
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Width >= 0);
            Contract.Invariant(this.Height >= 0);
        }
    }
}
