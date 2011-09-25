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
    [ContractClass(typeof(ContractsForIBitmap))]
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
        /// Gets or sets the color value of the pixel at the specified coordinates.
        /// </summary>
        /// <param name="y">The row of the pixel to get or set.</param>
        /// <param name="x">The column of the pixel to get or set.</param>
        /// <returns>The color value of the pixel at the specified coordinates.</returns>
        IColor this[int x, int y]
        {
            get;
            set;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Fills the bitmap with the specified color.
        /// </summary>
        /// <param name="color">The color to fill with.</param>
        void Fill(IColor color);
        #endregion
    }

    [ContractClassFor(typeof(IBitmap))]
    internal abstract class ContractsForIBitmap : IBitmap
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

                return default(IColor);
            }
            set
            {
                Contract.Requires(x >= 0);
                Contract.Requires(x < this.Width);
                Contract.Requires(y >= 0);
                Contract.Requires(y < this.Height);
            }
        }

        void IBitmap.Fill(IColor color)
        {
            Contract.Requires(color != null);
        }
    }
}
