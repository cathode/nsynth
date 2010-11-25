/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Runtime.InteropServices;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a color using three color channels (Red, Green, Blue) and an alpha (opacity) channel, using 32 bits of color information per pixel (8 bits per channel).
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct ColorRGB32 : IColor
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="ColorRGB32.Alpha"/> property.
        /// </summary>
        [FieldOffset(0x3)]
        private byte alpha;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB32.Blue"/> property.
        /// </summary>
        [FieldOffset(0x0)]
        private byte blue;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB32.Green"/> property.
        /// </summary>
        [FieldOffset(0x1)]
        private byte green;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB32.Red"/> property.
        /// </summary>
        [FieldOffset(0x2)]
        private byte red;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB32"/> struct.
        /// </summary>
        /// <param name="red">The value of the red color channel.</param>
        /// <param name="green">The value of the green color channel.</param>
        /// <param name="blue">The value of the blue color channel.</param>
        public ColorRGB32(byte red, byte green, byte blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = byte.MaxValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB32"/> struct.
        /// </summary>
        /// <param name="red">The value of the red color channel.</param>
        /// <param name="green">The value of the green color channel.</param>
        /// <param name="blue">The value of the blue color channel.</param>
        /// <param name="alpha">The value of the alpha (opacity) channel.</param>
        public ColorRGB32(byte red, byte green, byte blue, byte alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }

        public ColorRGB32(double red, double green, double blue)
        {
            this.red = (byte)(byte.MaxValue * Math.Max(Math.Min(red, 1.0), 0.0));
            this.green = (byte)(byte.MaxValue * Math.Max(Math.Min(green, 1.0), 0.0));
            this.blue = (byte)(byte.MaxValue * Math.Max(Math.Min(blue, 1.0), 0.0));
            this.alpha = byte.MaxValue;
        }

        public ColorRGB32(double red, double green, double blue, double alpha)
        {
            this.red = (byte)(byte.MaxValue * Math.Max(Math.Min(red, 1.0), 0.0));
            this.green = (byte)(byte.MaxValue * Math.Max(Math.Min(green, 1.0), 0.0));
            this.blue = (byte)(byte.MaxValue * Math.Max(Math.Min(blue, 1.0), 0.0));
            this.alpha = (byte)(byte.MaxValue * Math.Max(Math.Min(alpha, 1.0), 0.0));
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the value of the alpha (opacity) channel.
        /// </summary>
        public byte Alpha
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
        /// Gets or sets the value of the blue color channel.
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
        /// Gets or sets the value of the green color channel.
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
        /// Gets or sets the value of the red color channel.
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

        /// <summary>
        /// Gets the <see cref="PixelFormat"/> that describes how pixel data is stored by the current <see cref="IColor"/> implementation.
        /// </summary>
        public PixelFormat Format
        {
            get
            {
                return PixelFormat.RGB32;
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
            if (obj is ColorRGB32)
                return this == (ColorRGB32)obj;

            return false;
        }

        /// <summary>
        /// Indicates whether this <see cref="ColorRGB32"/> and a specified <see cref="ColorRGB32"/> instance represent the same color value.
        /// </summary>
        /// <param name="other">A <see cref="ColorRGB32"/> instance to compare to the current instance.</param>
        /// <returns>true if both instances represent the same color value; otherwise false.</returns>
        public bool Equals(ColorRGB32 other)
        {
            return this == other;
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
        /// Pre-multiplies the Red, Green, and Blue color components against the Alpha component.
        /// </summary>
        /// <returns>A new <see cref="ColorRGBA32"/> instance that contains the premultiplied color value.</returns>
        public ColorRGB32 PremultiplyAlpha()
        {
            return ColorRGB32.PremultiplyAlpha(this);
        }

        /// <summary>
        /// Pre-multiplies the Red, Green, and Blue color components against the Alpha component.
        /// </summary>
        /// <param name="color">The color value to be premultiplied.</param>
        /// <returns>A new <see cref="ColorRGBA32"/> instance that contains the premultiplied color value.</returns>
        public static ColorRGB32 PremultiplyAlpha(ColorRGB32 color)
        {
            byte red = (byte)(color.Red * (color.Alpha / 255f));
            byte green = (byte)(color.Green * (color.Alpha / 255f));
            byte blue = (byte)(color.Blue * (color.Alpha / 255f));
            return new ColorRGB32(red, green, blue, 255);
        }

        /// <summary>
        /// Converts the current <see cref="ColorRGB32"/> to an equivalent 128-bit RGBA color.
        /// </summary>
        /// <returns>A new <see cref="ColorRGB"/> that is the equivalent color of the current <see cref="ColorRGB32"/>.</returns>
        public ColorRGB ToRGB()
        {
            return new ColorRGB(this.Red, this.Green, this.Blue, this.Alpha);
        }
        #endregion
        #region Operators
        /// <summary>
        /// Indicates if the two <see cref="ColorRGB32"/> instances represent the same color value.
        /// </summary>
        /// <param name="left">The <see cref="ColorRGB32"/> instance to compare which appears on the left side of the operator.</param>
        /// <param name="right">The <see cref="ColorRGB32"/> instance to compare which appears on the right side of the operator.</param>
        /// <returns>true if <paramref name="left"/> represents the same color value as <paramref name="right"/>; otherwise false.</returns>
        public static bool operator ==(ColorRGB32 left, ColorRGB32 right)
        {
            return left.Alpha == right.Alpha
                && left.Blue == right.Blue
                && left.Green == right.Green
                && left.Red == right.Red;
        }

        /// <summary>
        /// Indicates if two <see cref="ColorRGB32"/> instances do not represent the same color value.
        /// </summary>
        /// <param name="left">The <see cref="ColorRGB32"/> instance to compare which appears on the left side of the operator.</param>
        /// <param name="right">The <see cref="ColorRGB32"/> instance to compare which appears on the right side of the operator.</param>
        /// <returns>true if <paramref name="left"/> represents a different color value than <paramref name="right"/>; otherwise false.</returns>
        public static bool operator !=(ColorRGB32 left, ColorRGB32 right)
        {
            return left.Alpha != right.Alpha
                || left.Blue != right.Blue
                || left.Green != right.Green
                || left.Red != right.Red;
        }

        /// <summary>
        /// Determines if one <see cref="ColorRGB32"/> instance represents a darker color value than the other <see cref="ColorRGB32"/> instance.
        /// </summary>
        /// <remarks>
        /// The term "darker" refers to a color that is closer to black.
        /// </remarks>
        /// <param name="left">The <see cref="ColorRGB32"/> instance to compare which appears on the left side of the operator.</param>
        /// <param name="right">The <see cref="ColorRGB32"/> instance to compare which appears on the right side of the operator.</param>
        /// <returns>true if <paramref name="left"/> is darker than <paramref name="right"/>; otherwise false.</returns>
        public static bool operator <(ColorRGB32 left, ColorRGB32 right)
        {
            return ((left.Red / 255f) + (left.Green / 255f) + (left.Blue / 255f)) * (left.Alpha / 255f) < ((right.Red / 255f) + (right.Green / 255f) + (right.Blue / 255f)) * (right.Alpha / 255f);
        }

        /// <summary>
        /// Determines if one <see cref="ColorRGB32"/> instance represents a lighter color value than the other <see cref="ColorRGB32"/> instance.
        /// </summary>
        /// <remarks>
        /// The term "lighter" refers to a color that is closer to white.
        /// </remarks>
        /// <param name="left">The <see cref="ColorRGB32"/> instance to compare which appears on the left side of the operator.</param>
        /// <param name="right">The <see cref="ColorRGB32"/> instance to compare which appears on the right side of the operator.</param>
        /// <returns>true if <paramref name="left"/> is lighter than <paramref name="right"/>; otherwise false.</returns>
        public static bool operator >(ColorRGB32 left, ColorRGB32 right)
        {
            return ((left.Red / 255f) + (left.Green / 255f) + (left.Blue / 255f)) * (left.Alpha / 255f) > ((right.Red / 255f) + (right.Green / 255f) + (right.Blue / 255f)) * (right.Alpha / 255f);
        }

        /// <summary>
        /// Adds two <see cref="ColorRGB32"/> instances.
        /// </summary>
        /// <param name="left">The left-hand operand.</param>
        /// <param name="right">The right-hand operand.</param>
        /// <returns>A new <see cref="ColorRGB32"/> that is the result of the addition operation.</returns>
        public static ColorRGB32 operator +(ColorRGB32 left, ColorRGB32 right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subtracts one color from another.
        /// </summary>
        /// <param name="left">The left-hand operand.</param>
        /// <param name="right">The right-hand operand.</param>
        /// <returns>A new <see cref="ColorRGB32"/> that is the result of the subtraction operation.</returns>
        public static ColorRGB32 operator -(ColorRGB32 left, ColorRGB32 right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplies a color by a scalar value.
        /// </summary>
        /// <param name="left">The <see cref="ColorRGB32"/> instance to be multiplied.</param>
        /// <param name="right">The scalar value to multiply by.</param>
        /// <returns>A new <see cref="ColorRGB32"/> that is the result of the multiplication operation.</returns>
        public static ColorRGB32 operator *(ColorRGB32 left, double right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implicitly converts a 24-bit RGB value to a 32-bit RGB value by assuming a completely opaque alpha channel value.
        /// </summary>
        /// <param name="color">The 24-bit RGB color to be converted.</param>
        /// <returns>A new <see cref="ColorRGB32"/> instance that is the result of the conversion.</returns>
        public static implicit operator ColorRGB32(ColorRGB24 color)
        {
            return new ColorRGB32(color.Red, color.Green, color.Blue, byte.MaxValue);
        }
        public static explicit operator ColorRGB32(ColorRGB64 color)
        {
            return new ColorRGB32((byte)(color.Red >> 8), (byte)(color.Green >> 8), (byte)(color.Blue >> 8), (byte)(color.Alpha >> 8));
        }
        public static explicit operator ColorRGB32(ColorRGB color)
        {
            return new ColorRGB32((byte)(color.Red  * 0xFF), (byte)(color.Green * 0xFF), (byte)(color.Blue * 0xFF), (byte)(color.Alpha * 0xFF));
        }
        #endregion

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
                return this.alpha / 255.0f;
            }
            set
            {
                this.alpha = (byte)(value * 255);
            }
        }
    }
}
