/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Runtime.InteropServices;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents dimensions as width and height. This type is immutable.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
    public struct Size
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Size.Height"/> property.
        /// </summary>
        [FieldOffset(0x04)]
        private readonly int height;

        /// <summary>
        /// Backing field for the <see cref="Size.Width"/> property.
        /// </summary>
        [FieldOffset(0x00)]
        private readonly int width;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> struct.
        /// </summary>
        /// <param name="width">The width value.</param>
        /// <param name="height">The height value.</param>
        public Size(int width, int height)
        {
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
                return this.height;
            }
        }

        /// <summary>
        /// Gets the width value.
        /// </summary>
        public int Width
        {
            get
            {
                return this.width;
            }
        }

        public int Elements
        {
            get
            {
                return this.width * this.height;
            }
        }
        #endregion
    }
}
