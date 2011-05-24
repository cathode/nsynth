/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Runtime.InteropServices;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a color using three color channels (Red, Green, Blue), using 48 bits of color information per pixel (16 bits per channel).
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct ColorRGB48 : IColor
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="ColorRGB48.Blue"/> property.
        /// </summary>
        [FieldOffset(0x4)]
        private ushort blue;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB48.Green"/> property.
        /// </summary>
        [FieldOffset(0x2)]
        private ushort green;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB48.Red"/> property.
        /// </summary>
        [FieldOffset(0x0)]
        private ushort red;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB48"/> struct.
        /// </summary>
        /// <param name="red">The value of the red color component.</param>
        /// <param name="green">The value of the green color component.</param>
        /// <param name="blue">The value of the blue color component.</param>
        public ColorRGB48(byte red, byte green, byte blue)
        {
            this.red = (ushort)((red << 8) | red);
            this.green = (ushort)((green << 8) | green);
            this.blue = (ushort)((blue << 8) | blue);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB48"/> struct.
        /// </summary>
        /// <param name="red">The value of the red color component.</param>
        /// <param name="green">The value of the green color component.</param>
        /// <param name="blue">The value of the blue color component.</param>
        public ColorRGB48(ushort red, ushort green, ushort blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB48"/> struct.
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public ColorRGB48(double red, double green, double blue)
        {
            this.red = (ushort)(ushort.MaxValue * Math.Max(Math.Min(red, 1.0), 0.0));
            this.green = (ushort)(ushort.MaxValue * Math.Max(Math.Min(green, 1.0), 0.0));
            this.blue = (ushort)(ushort.MaxValue * Math.Max(Math.Min(blue, 1.0), 0.0));
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the blue component of the current <see cref="ColorRGB48"/>.
        /// </summary>
        public ushort Blue
        {
            get
            {
                return this.blue;
            }
            set
            {
                this.blue = value;
            }
        }

        /// <summary>
        /// Gets or sets the green component of the current <see cref="ColorRGB48"/>.
        /// </summary>
        public ushort Green
        {
            get
            {
                return this.green;
            }
            set
            {
                this.green = value;
            }
        }

        /// <summary>
        /// Gets or sets the red component of the current <see cref="ColorRGB48"/>.
        /// </summary>
        public ushort Red
        {
            get
            {
                return this.red;
            }
            set
            {
                this.red = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="PixelFormat"/> that describes how pixel data is stored by the current <see cref="IColor"/> implementation.
        /// </summary>
        public PixelFormat Format
        {
            get
            {
                return PixelFormat.RGB48;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Indicates whether this <see cref="ColorRGB48"/> and a specified <see cref="ColorRGB48"/> instance represent the same color value.
        /// </summary>
        /// <param name="other">A <see cref="ColorRGB48"/> instance to compare to the current instance.</param>
        /// <returns>true if both instances represent the same color value; otherwise false.</returns>
        public bool Equals(ColorRGB48 other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts the current <see cref="ColorRGB48"/> to an equivalent 128-bit RGBA color.
        /// </summary>
        /// <returns>A new <see cref="ColorRGB"/> that is the equivalent color of the current <see cref="ColorRGB48"/>.</returns>
        public ColorRGB ToRGB()
        {
            return new ColorRGB((int)(this.Red << 16), (int)(this.Green << 16), (int)(this.Blue << 16), int.MaxValue);
        }
        #endregion
        #region Operators
        /// <summary>
        /// Implicitly converts a lower-precision color value to a higher-precision format.
        /// </summary>
        /// <param name="color">A <see cref="ColorRGB24"/> instance to convert.</param>
        /// <returns>A new <see cref="ColorRGB48"/> that is the higher-precision format conversion result.</returns>
        public static implicit operator ColorRGB48(ColorRGB24 color)
        {
            return new ColorRGB48(color.Red, color.Green, color.Blue);
        }

        /// <summary>
        /// Indicates if the two <see cref="ColorRGB48"/> instances represent the same color value.
        /// </summary>
        /// <param name="left">The <see cref="ColorRGB48"/> instance to compare which appears on the left side of the operator.</param>
        /// <param name="right">The <see cref="ColorRGB48"/> instance to compare which appears on the right side of the operator.</param>
        /// <returns>true if <paramref name="left"/> represents the same color value as <paramref name="right"/>; otherwise false.</returns>
        public static bool operator ==(ColorRGB48 left, ColorRGB48 right)
        {
            return left.Red == right.Red
                && left.Green == right.Green
                && left.Blue == right.Blue;
        }

        /// <summary>
        /// Indicates if two <see cref="ColorRGB48"/> instances do not represent the same color value.
        /// </summary>
        /// <param name="left">The <see cref="ColorRGB48"/> instance to compare which appears on the left side of the operator.</param>
        /// <param name="right">The <see cref="ColorRGB48"/> instance to compare which appears on the right side of the operator.</param>
        /// <returns>true if <paramref name="left"/> represents a different color value than <paramref name="right"/>; otherwise false.</returns>
        public static bool operator !=(ColorRGB48 left, ColorRGB48 right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines if one <see cref="ColorRGB48"/> instance represents a lighter color value than the other instance.
        /// </summary>
        /// <remarks>
        /// The term "lighter" refers to a color that is closer to white.
        /// </remarks>
        /// <param name="left">The <see cref="ColorRGB48"/> instance to compare which appears on the left side of the operator.</param>
        /// <param name="right">The <see cref="ColorRGB48"/> instance to compare which appears on the right side of the operator.</param>
        /// <returns>true if <paramref name="left"/> is lighter than <paramref name="right"/>; otherwise false.</returns>
        public static bool operator >(ColorRGB48 left, ColorRGB48 right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines if one <see cref="ColorRGB48"/> instance represents a darker color value than the other instance.
        /// </summary>
        /// <remarks>
        /// The term "darker" refers to a color that is closer to black.
        /// </remarks>
        /// <param name="left">The <see cref="ColorRGB48"/> instance to compare which appears on the left side of the operator.</param>
        /// <param name="right">The <see cref="ColorRGB48"/> instance to compare which appears on the right side of the operator.</param>
        /// <returns>true if <paramref name="left"/> is darker than <paramref name="right"/>; otherwise false.</returns>
        public static bool operator <(ColorRGB48 left, ColorRGB48 right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds two 48-bit RGB color values together.
        /// </summary>
        /// <param name="left">The first color value to add.</param>
        /// <param name="right">The second color value to add.</param>
        /// <returns>A new <see cref="ColorRGB48"/> instance that is the result of the addition.</returns>
        public static ColorRGB48 operator +(ColorRGB48 left, ColorRGB48 right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subtracts one color value from another.
        /// </summary>
        /// <param name="left">The color value to be subtracted from.</param>
        /// <param name="right">The color value to subtract.</param>
        /// <returns>A new <see cref="ColorRGB48"/> instance that is the result of the subtraction.</returns>
        public static ColorRGB48 operator -(ColorRGB48 left, ColorRGB48 right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplies a color by a scalar value.
        /// </summary>
        /// <param name="color">A <see cref="ColorRGB48"/> that contains the color value to be multiplied.</param>
        /// <param name="scalar">A scalar value to multiply the color by.</param>
        /// <returns>A new <see cref="ColorRGB48"/> instance that contains the result of the multiplication.</returns>
        public static ColorRGB48 operator *(ColorRGB48 color, double scalar)
        {
            throw new NotImplementedException();
        }

        public static explicit operator ColorRGB48(ColorRGB96 color)
        {
            throw new NotImplementedException();
        }
        #endregion

        float IColor.Red
        {
            get
            {
                return this.red / 65535.0f;
            }
            set
            {
                this.red = (byte)(value * ushort.MaxValue);
            }
        }

        float IColor.Green
        {
            get
            {
                return this.green / 65535.0f;
            }
            set
            {
                this.green = (byte)(value * ushort.MaxValue);
            }
        }

        float IColor.Blue
        {
            get
            {
                return this.blue / 65535.0f;
            }
            set
            {
                this.blue = (byte)(value * ushort.MaxValue);
            }
        }

        float IColor.Alpha
        {
            get
            {
                return 1.0f;
            }
            set
            {
                throw new NotSupportedException("The ColorRGB48 type does not support an alpha (opacity) channel.");
            }
        }
    }
}
