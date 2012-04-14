/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Runtime.InteropServices;
using System.Diagnostics.Contracts;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a color using three color channels (Red, Green, Blue), using 24 bits of color information per pixel (8 bits per channel).
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 3)]
    public struct ColorRGB24 : IColor
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="ColorRGB24.Blue"/> property.
        /// </summary>
        [FieldOffset(0x0)]
        private byte blue;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB24.Green"/> property.
        /// </summary>
        [FieldOffset(0x1)]
        private byte green;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB24.Red"/> property.
        /// </summary>
        [FieldOffset(0x2)]
        private byte red;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB24"/> struct.
        /// </summary>
        /// <param name="red">The value of the red color component.</param>
        /// <param name="green">The value of the green color component.</param>
        /// <param name="blue">The value of the blue color component.</param>
        public ColorRGB24(byte red, byte green, byte blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the value of the blue color component of the current <see cref="ColorRGB24"/>.
        /// </summary>
        public byte Blue
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
        /// Gets or sets the value of the green color component of the current <see cref="ColorRGB24"/>.
        /// </summary>
        public byte Green
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
        /// Gets or sets the value of the red color component of the current <see cref="ColorRGB24"/>.
        /// </summary>
        public byte Red
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

        float IColor.Red
        {
            get
            {
                return this.red / 255.0f;
            }
            set
            {
                this.red = (byte)(value * 255);
            }
        }

        float IColor.Green
        {
            get
            {
                return this.green / 255.0f;
            }
            set
            {
                this.green = (byte)(value * 255);
            }
        }

        float IColor.Blue
        {
            get
            {
                return this.blue / 255.0f;
            }
            set
            {
                this.blue = (byte)(value * 255);
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
                throw new NotSupportedException("The ColorRGB24 type does not support an alpha (opacity) channel.");
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
            if (obj is ColorRGB24)
                return this == (ColorRGB24)obj;
            return false;
        }

        /// <summary>
        /// Indicates whether this <see cref="ColorRGB24"/> and a specified <see cref="ColorRGB24"/> instance represent the same color value.
        /// </summary>
        /// <param name="other">A <see cref="ColorRGB24"/> instance to compare to the current instance.</param>
        /// <returns>true if both instances represent the same color value; otherwise false.</returns>
        public bool Equals(ColorRGB24 other)
        {
            return this == other;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Calculates the linear interpolation between the current color and the specified color.
        /// </summary>
        /// <param name="other">The other <see cref="ColorRGB24"/> to interpolate against.</param>
        /// <param name="t">The interpolation factor, 0.0 to 1.0.</param>
        /// <returns>A new <see cref="ColorRGB24"/> that is the result of the interpolation.</returns>
        public ColorRGB24 LinearInterpolate(ColorRGB24 other, float t)
        {
            Contract.Requires(t <= 1.0f);
            Contract.Requires(0.0f <= t);
            return this.LinearInterpolate(other, t, t, t);
        }
        /// <summary>
        /// Calculates the linear interpolation between the current color and the specified color.
        /// </summary>
        /// <param name="other">The <see cref="ColorRGB24"/> to interpolate against.</param>
        /// <param name="tr">The interpolation factor for the red channel, 0.0 to 1.0.</param>
        /// <param name="tg">The interpolation factor for the green channel, 0.0 to 1.0.</param>
        /// <param name="tb">The interpolation factor for the blue channel, 0.0 to 1.0.</param>
        /// <returns>A new <see cref="ColorRGB24"/> that is the result of the interpolation.</returns>
        public ColorRGB24 LinearInterpolate(ColorRGB24 other, float tr, float tg, float tb)
        {
            Contract.Requires(tr <= 1.0f);
            Contract.Requires(0.0f <= tr);
            Contract.Requires(tg <= 1.0f);
            Contract.Requires(0.0f <= tg);
            Contract.Requires(tb <= 1.0f);
            Contract.Requires(0.0f <= tb);

            return new ColorRGB24(
                (byte)((this.red * tr) + (other.red * (1.0f - tr))),
                (byte)((this.green * tg) + (other.green * (1.0f - tg))),
                (byte)((this.blue * tb) + (other.blue * (1.0f - tb))));
        }
        #endregion
        #region Operators
        /// <summary>
        /// Indicates if the two <see cref="ColorRGB24"/> instances represent the same color value.
        /// </summary>
        /// <param name="left">The left-hand operand.</param>
        /// <param name="right">The right-hand operand.</param>
        /// <returns>true if <paramref name="left"/> represents the same color value as <paramref name="right"/>; otherwise false.</returns>
        public static bool operator ==(ColorRGB24 left, ColorRGB24 right)
        {
            return left.Red == right.Red && left.Green == right.Green && left.Blue == right.Blue;
        }

        /// <summary>
        /// Indicates if two <see cref="ColorRGB24"/> instances do not represent the same color value.
        /// </summary>
        /// <param name="left">The left-hand operand.</param>
        /// <param name="right">The right-hand operand.</param>
        /// <returns>true if <paramref name="left"/> represents a different color value than <paramref name="right"/>; otherwise false.</returns>
        public static bool operator !=(ColorRGB24 left, ColorRGB24 right)
        {
            return left.Red != right.Red || left.Green != right.Green || left.Blue != right.Blue;
        }

        /// <summary>
        /// Adds two color values together.
        /// </summary>
        /// <param name="left">The first color value to add.</param>
        /// <param name="right">The second color value to add.</param>
        /// <returns>A new <see cref="ColorRGB24"/> instance that is the result of the addition.</returns>
        public static ColorRGB24 operator +(ColorRGB24 left, ColorRGB24 right)
        {
            return new ColorRGB24(
                (byte)(left.Red + right.Red),
                (byte)(left.Green + right.Green),
                (byte)(left.Blue + right.Blue));
        }

        /// <summary>
        /// Subtracts one color value from another.
        /// </summary>
        /// <param name="left">The color value to be subtracted from.</param>
        /// <param name="right">The color value to subtract.</param>
        /// <returns>A new <see cref="ColorRGB24"/> instance that is the result of the subtraction.</returns>
        public static ColorRGB24 operator -(ColorRGB24 left, ColorRGB24 right)
        {
            return new ColorRGB24(
                (byte)(left.Red - right.Red),
                (byte)(left.Green - right.Green),
                (byte)(left.Blue - right.Blue));
        }

        /// <summary>
        /// Multiplies a color by a scalar value.
        /// </summary>
        /// <param name="color">A <see cref="ColorRGB24"/> that contains the color value to be multiplied.</param>
        /// <param name="scalar">A scalar value to multiply the color by.</param>
        /// <returns>A new <see cref="ColorRGB24"/> instance that contains the result of the multiplication.</returns>
        public static ColorRGB24 operator *(ColorRGB24 color, double scalar)
        {
            return new ColorRGB24(
                (byte)(color.Red * scalar),
                (byte)(color.Green * scalar),
                (byte)(color.Blue * scalar));
        }
        #endregion
    }
}
