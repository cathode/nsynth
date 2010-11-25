/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Runtime.InteropServices;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a point in a bitmap.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
    public struct Point
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Point.X"/> property.
        /// </summary>
        [FieldOffset(0x00)]
        private int x;

        /// <summary>
        /// Backing field for the <see cref="Point.Y"/> property.
        /// </summary>
        [FieldOffset(0x04)]
        private int y;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the x-coordinate of the point.
        /// </summary>
        public int X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// Gets the y-coordinate of the point.
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }
        }
        #endregion
    }
}
