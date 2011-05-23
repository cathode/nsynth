/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Runtime.InteropServices;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a rectangular area.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
    public struct Rectangle
    {
        #region Fields
        /// <summary>
        /// Holds a <see cref="Rectangle"/> that represents an empty area.
        /// </summary>
        public static readonly Rectangle Empty = new Rectangle();

        /// <summary>
        /// Backing field for the <see cref="Location"/> property.
        /// </summary>
        [FieldOffset(0x00)]
        private readonly Point location;

        /// <summary>
        /// Backing field for the <see cref="Size"/> property.
        /// </summary>
        [FieldOffset(0x08)]
        private readonly Size size;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> struct.
        /// </summary>
        /// <param name="size"></param>
        public Rectangle(Size size)
        {
            this.location = new Point();
            this.size = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> struct.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="size"></param>
        public Rectangle(Point location, Size size)
        {
            this.location = location;
            this.size = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> struct.
        /// </summary>
        /// <param name="left">The x-position of the left edge.</param>
        /// <param name="top">The y-position of the top edge.</param>
        /// <param name="right">The x-position of the right edge.</param>
        /// <param name="bottom">The y-position of the bottom edge.</param>
        public Rectangle(int left, int top, int right, int bottom)
        {
            this.location = new Point(left, top);
            this.size = new Size(right - left, top - bottom);
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the position of the bottom edge of the current <see cref="Rectangle"/>.
        /// </summary>
        public int Bottom
        {
            get
            {
                return this.Location.Y + (int)this.Size.Height;
            }
        }

        /// <summary>
        /// Gets the position of the left edge of the current <see cref="Rectangle"/>.
        /// </summary>
        public int Left
        {
            get
            {
                return this.Location.X;
            }
        }

        /// <summary>
        /// Gets the location of the current <see cref="Rectangle"/>, which is always the upper-left corner.
        /// </summary>
        public Point Location
        {
            get
            {
                return this.location;
            }
        }

        /// <summary>
        /// Gets the position of the right edge of the current <see cref="Rectangle"/>.
        /// </summary>
        public int Right
        {
            get
            {
                return this.Location.X + (int)this.Size.Width;
            }
        }

        /// <summary>
        /// Gets the size of the current <see cref="Rectangle"/>.
        /// </summary>
        public Size Size
        {
            get
            {
                return this.size;
            }
        }

        /// <summary>
        /// Gets the position of the top edge of the current <see cref="Rectangle"/>.
        /// </summary>
        public int Top
        {
            get
            {
                return this.Location.Y;
            }
        }
        #endregion
        #region Methods

        /// <summary>
        /// Compares the current <see cref="Rectangle"/> instance with another object and determines if they have the same value.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!object.ReferenceEquals(obj, null) && obj is Rectangle)
                return Rectangle.Equals(this, (Rectangle)obj);
            else
                return false;
        }

        /// <summary>
        /// Compares the current <see cref="Rectangle"/> instance with another and determines if they have the same value.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Rectangle other)
        {
            return Rectangle.Equals(this, other);
        }

        /// <summary>
        /// Compares two <see cref="Rectangle"/> instances and determines if they have the same value.
        /// </summary>
        /// <param name="r1">The first <see cref="Rectangle"/> to compare.</param>
        /// <param name="r2">The second <see cref="Rectangle"/> to compare.</param>
        /// <returns>true if both rectangles have the same value, otherwise false.</returns>
        public static bool Equals(Rectangle r1, Rectangle r2)
        {
            if (object.ReferenceEquals(r1, r2))
                return true;
            else
                return r1.Left == r2.Left && r1.Top == r2.Top && r1.Right == r2.Right && r1.Bottom == r2.Bottom;
        }

        /// <summary>
        /// Calculates a hash code for the current <see cref="Rectangle"/>.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = this.Location.GetHashCode();
                result = 67 + result + this.Size.GetHashCode();

                return result;
            }
        }
        #endregion
        #region Operators
        public static bool operator ==(Rectangle rectangle1, Rectangle rectangle2)
        {
            return Rectangle.Equals(rectangle1, rectangle2);
        }
        public static bool operator !=(Rectangle rectangle1, Rectangle rectangle2)
        {
            return !Rectangle.Equals(rectangle1, rectangle2);
        }
        #endregion
    }
}
