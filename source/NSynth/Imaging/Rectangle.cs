/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a rectangular area.
    /// </summary>
    public class Rectangle : IEnumerable<Point>
    {
        #region Fields
        /// <summary>
        /// Holds a <see cref="Rectangle"/> that represents an empty area.
        /// </summary>
        public static readonly Rectangle Empty = new Rectangle();

        /// <summary>
        /// Backing field for the <see cref="Rectangle.Left"/> property.
        /// </summary>
        private int left;

        /// <summary>
        /// Backing field for the <see cref="Rectangle.Top"/> property.
        /// </summary>
        private int top;

        /// <summary>
        /// Backing field for the <see cref="Rectangle.Bottom"/> property.
        /// </summary>
        private int bottom;

        /// <summary>
        /// Backing field for the <see cref="Rectangle.Right"/> property.
        /// </summary>
        private int right;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        public Rectangle()
        {
            this.left = 0;
            this.top = 0;
            this.right = 0;
            this.bottom = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="size">A <see cref="Size"/> that defines the width and height of the rectangle.</param>
        public Rectangle(Size size)
        {
            this.left = 0;
            this.top = 0;
            this.right = size.Width;
            this.bottom = size.Height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="location">A <see cref="Point"/> that defines the upper-left corner of the rectangle.</param>
        /// <param name="size">A <see cref="Size"/> that defines the width and height of the rectangle.</param>
        public Rectangle(Point location, Size size)
        {
            this.left = location.X;
            this.top = location.Y;
            this.right = location.X + size.Width;
            this.bottom = location.Y + size.Height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="left">The position of the left edge.</param>
        /// <param name="top">The position of the top edge.</param>
        /// <param name="right">The position of the right edge.</param>
        /// <param name="bottom">The position of the bottom edge.</param>
        public Rectangle(int left, int top, int right, int bottom)
        {
            Contract.Requires(left <= right);
            Contract.Requires(top <= bottom);

            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="a">A <see cref="Point"/> that defines the upper-left corner of the rectangle.</param>
        /// <param name="b">A <see cref="Point"/> that defines the lower-right corner of the rectangle.</param>
        public Rectangle(Point a, Point b)
        {
            Contract.Requires(a.X <= b.X);
            Contract.Requires(a.Y <= b.Y);

            this.left = a.X;
            this.top = a.Y;
            this.right = b.X;
            this.bottom = b.Y;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the position of the bottom edge of the <see cref="Rectangle"/>.
        /// </summary>
        public int Bottom
        {
            get
            {
                return this.bottom;
            }
            set
            {
                Contract.Requires(value >= this.Top);

                this.bottom = value;
            }
        }

        /// <summary>
        /// Gets or sets the position of the left edge of the <see cref="Rectangle"/>.
        /// </summary>
        public int Left
        {
            get
            {
                return this.left;
            }
            set
            {
                Contract.Requires(value <= this.Right);

                this.left = value;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Point"/> that defines the upper-left corner of the <see cref="Rectangle"/>.
        /// </summary>
        public Point A
        {
            get
            {
                return new Point(this.left, this.top);
            }
            set
            {
                Contract.Requires(value.X <= this.Right);
                Contract.Requires(value.Y <= this.Bottom);

                this.left = value.X;
                this.top = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="Point"/> that defines the lower-right corner of the <see cref="Rectangle"/>.
        /// </summary>
        public Point B
        {
            get
            {
                return new Point(this.right, this.bottom);
            }
            set
            {
                Contract.Requires(value.X >= this.Left);
                Contract.Requires(value.Y >= this.Top);

                this.right = value.X;
                this.bottom = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets the position of the right edge of the <see cref="Rectangle"/>.
        /// </summary>
        public int Right
        {
            get
            {
                return this.right;
            }
            set
            {
                Contract.Requires(value >= this.Left);

                this.right = value;
            }
        }

        /// <summary>
        /// Gets the size of the current <see cref="Rectangle"/>.
        /// </summary>
        [Pure]
        public Size Size
        {
            get
            {
                return new Size(this.Right - this.Left, this.Bottom - this.Top);
            }
        }

        /// <summary>
        /// Gets or sets the position of the top edge of the current <see cref="Rectangle"/>.
        /// </summary>
        public int Top
        {
            get
            {
                return this.top;
            }
            set
            {
                Contract.Requires(value <= this.Bottom);

                this.top = value;
            }
        }

        /// <summary>
        /// Gets the width of the rectangle.
        /// </summary>
        public int Width
        {
            get
            {
                return this.right - this.left;
            }
        }

        /// <summary>
        /// Gets the height of the rectangle.
        /// </summary>
        public int Height
        {
            get
            {
                return this.bottom - this.top;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Compares the current <see cref="Rectangle"/> instance with another object and determines if they have the same value.
        /// </summary>
        /// <param name="obj">An object to compare with.</param>
        /// <returns>true if the current instance represents the same value as the specified instance; otherwise, false.</returns>
        [Pure]
        public override bool Equals(object obj)
        {
            return this == (obj as Rectangle);
        }

        /// <summary>
        /// Compares the current <see cref="Rectangle"/> instance with another and determines if they have the same value.
        /// </summary>
        /// <param name="other">The other instance to compare to.</param>
        /// <returns>true if the current instance represents the same value as the specified instance; otherwise, false.</returns>
        [Pure]
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
        [Pure]
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
        /// <returns>A 32-bit integer that is the hash code for this instance.</returns>
        [Pure]
        public override int GetHashCode()
        {
            unchecked
            {
                int result = this.A.GetHashCode();
                result = 67 + result + this.Size.GetHashCode();

                return result;
            }
        }

        /// <summary>
        /// Determines if the <see cref="Rectangle"/> contains the specified <see cref="Point"/>.
        /// </summary>
        /// <param name="p">The point to test for.</param>
        /// <returns>true if the specified <see cref="Point"/> is located within the current <see cref="Rectangle"/>; otherwise, false.</returns>
        [Pure]
        public bool Contains(Point p)
        {
            return (p.X >= this.Left) && (p.X <= this.Right) && (p.Y >= this.Top) && (p.Y <= this.Bottom);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="System.Collections.Generic.IEnumerator&lt;T&gt;"/> that can be used to iterate through the collection.</returns>
        [Pure]
        public IEnumerator<Point> GetEnumerator()
        {
            int x1 = this.Left;
            int x2 = this.Right;
            int y1 = this.Top;
            int y2 = this.Bottom;
            for (int y = y1; y <= y2; y++)
                for (int x = x1; x <= x2; x++)
                    yield return new Point(x, y);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="System.Collections.IEnumerator"/> that can be used to iterate through the collection.</returns>
        [Pure]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Contains invariant contracts for this type.
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.left <= this.right);
            Contract.Invariant(this.top <= this.bottom);
            Contract.Invariant(this.Width >= 0);
            Contract.Invariant(this.Height >= 0);
        }
        #endregion
        #region Operators
        /// <summary>
        /// Determines if two <see cref="Rectangle"/> instances represent the same value.
        /// </summary>
        /// <param name="left">The left-hand operand to compare.</param>
        /// <param name="right">The right-hand operand to compare.</param>
        /// <returns>true if both instances represent the same value; otherwise, false.</returns>
        [Pure]
        public static bool operator ==(Rectangle left, Rectangle right)
        {
            return Rectangle.Equals(left, right);
        }

        /// <summary>
        /// Determines if two <see cref="Rectangle"/> instances represent different values.
        /// </summary>
        /// <param name="left">The left-hand operand to compare.</param>
        /// <param name="right">The right-hand operand to compare.</param>
        /// <returns>true if both instances represent different values; otherwise, false.</returns>
        [Pure]
        public static bool operator !=(Rectangle left, Rectangle right)
        {
            return !Rectangle.Equals(left, right);
        }
        #endregion
    }
}
