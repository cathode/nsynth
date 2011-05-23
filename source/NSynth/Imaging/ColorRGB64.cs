/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Runtime.InteropServices;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a color using three color channels (Red, Green, Blue) and an alpha (opacity) channel, using 64 bits of color information per pixel (16 bits per channel).
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct ColorRGB64 : IColor
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="ColorRGB64.Red"/> property.
        /// </summary>
        [FieldOffset(0x0)]
        private ushort red;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB64.Green"/> property.
        /// </summary>
        [FieldOffset(0x2)]
        private ushort green;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB64.Blue"/> property.
        /// </summary>
        [FieldOffset(0x4)]
        private ushort blue;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB64.Alpha"/> property.
        /// </summary>
        [FieldOffset(0x6)]
        private ushort alpha;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB64"/> struct.
        /// </summary>
        /// <param name="red">The value of the red color component.</param>
        /// <param name="green">The value of the green color component.</param>
        /// <param name="blue">The value of the blue color component.</param>
        public ColorRGB64(byte red, byte green, byte blue)
        {
            this.red = (ushort)((red << 8) | red);
            this.green = (ushort)((green << 8) | green);
            this.blue = (ushort)((blue << 8) | blue);
            this.alpha = ushort.MaxValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB64"/> struct.
        /// </summary>
        /// <param name="red">The value of the red color component.</param>
        /// <param name="green">The value of the green color component.</param>
        /// <param name="blue">The value of the blue color component.</param>
        /// <param name="alpha">The value of the alpha (opacity) component.</param>
        public ColorRGB64(byte red, byte green, byte blue, byte alpha)
        {
            this.red = (ushort)((red << 8) | red);
            this.green = (ushort)((green << 8) | green);
            this.blue = (ushort)((blue << 8) | blue);
            this.alpha = (ushort)((alpha << 8) | alpha);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB64"/> struct.
        /// </summary>
        /// <param name="red">The value of the red color component.</param>
        /// <param name="green">The value of the green color component.</param>
        /// <param name="blue">The value of the blue color component.</param>
        public ColorRGB64(ushort red, ushort green, ushort blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = ushort.MaxValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB64"/> struct.
        /// </summary>
        /// <param name="red">The value of the red color component.</param>
        /// <param name="green">The value of the green color component.</param>
        /// <param name="blue">The value of the blue color component.</param>
        /// <param name="alpha">The value of the alpha (opacity) component.</param>
        public ColorRGB64(ushort red, ushort green, ushort blue, ushort alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }

        public ColorRGB64(double red, double green, double blue)
        {
            this.red = (ushort)(ushort.MaxValue * Math.Max(Math.Min(red, 1.0), 0.0));
            this.green = (ushort)(ushort.MaxValue * Math.Max(Math.Min(green, 1.0), 0.0));
            this.blue = (ushort)(ushort.MaxValue * Math.Max(Math.Min(blue, 1.0), 0.0));
            this.alpha = ushort.MaxValue;
        }

        public ColorRGB64(double red, double green, double blue, double alpha)
        {
            this.red = (ushort)(ushort.MaxValue * Math.Max(Math.Min(red, 1.0), 0.0));
            this.green = (ushort)(ushort.MaxValue * Math.Max(Math.Min(green, 1.0), 0.0));
            this.blue = (ushort)(ushort.MaxValue * Math.Max(Math.Min(blue, 1.0), 0.0));
            this.alpha = (ushort)(ushort.MaxValue * Math.Max(Math.Min(alpha, 1.0), 0.0));
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the value of the alpha (opacity) component of the current <see cref="ColorRGB64"/> instance.
        /// </summary>
        public ushort Alpha
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
        /// Gets or sets the value of the blue color component of the current <see cref="ColorRGB64"/> instance.
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
        /// Gets or sets the value of the green color component of the current <see cref="ColorRGB64"/> instance.
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
        /// Gets or sets the value of the red color component of the current <see cref="ColorRGB64"/> instance.
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
                return PixelFormat.RGB64;
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
            if (obj is ColorRGB64)
                return this == (ColorRGB64)obj;

            return false;
        }

        /// <summary>
        /// Indicates whether this <see cref="ColorRGB64"/> and a specified <see cref="ColorRGB64"/> instance represent the same color value.
        /// </summary>
        /// <param name="other">A <see cref="ColorRGB64"/> instance to compare to the current instance.</param>
        /// <returns>true if both instances represent the same color value; otherwise false.</returns>
        public bool Equals(ColorRGB64 other)
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
        /// Converts the current <see cref="ColorRGB64"/> to an equivalent 128-bit RGBA color.
        /// </summary>
        /// <returns>A new <see cref="ColorRGB"/> that is the equivalent color of the current <see cref="ColorRGB64"/>.</returns>
        public ColorRGB ToRGB()
        {
            return new ColorRGB((int)(this.Red << 16), (int)(this.Green << 16), (int)(this.Blue << 16), (int)(this.Alpha << 16));
        }
        #endregion
        #region Operators
        public static implicit operator ColorRGB64(ColorRGB24 color)
        {
            return new ColorRGB64(color.Red, color.Blue, color.Green);
        }
        public static implicit operator ColorRGB64(ColorRGB32 color)
        {
            return new ColorRGB64(color.Red, color.Blue, color.Green, color.Alpha);
        }
        public static implicit operator ColorRGB64(ColorRGB48 color)
        {
            return new ColorRGB64(color.Red, color.Blue, color.Green);
        }
        public static explicit operator ColorRGB64(ColorRGB color)
        {
            return new ColorRGB64((ushort)(color.Red * ushort.MaxValue), (ushort)(color.Green * ushort.MaxValue), (ushort)(color.Blue * ushort.MaxValue), (ushort)(color.Alpha * ushort.MaxValue));
        }
        public static bool operator ==(ColorRGB64 left, ColorRGB64 right)
        {
            return left.Red == right.Red && left.Green == right.Green && left.Blue == right.Blue && left.Alpha == right.Alpha;
        }
        public static bool operator !=(ColorRGB64 left, ColorRGB64 right)
        {
            return left.Red != right.Red || left.Green != right.Green || left.Blue != right.Blue || left.Alpha != right.Alpha;
        }
        public static bool operator <(ColorRGB64 left, ColorRGB64 right)
        {
            throw new NotImplementedException();
        }
        public static bool operator >(ColorRGB64 left, ColorRGB64 right)
        {
            throw new NotImplementedException();
        }
        public static ColorRGB64 operator +(ColorRGB64 left, ColorRGB64 right)
        {
            throw new NotImplementedException();
        }
        public static ColorRGB64 operator -(ColorRGB64 left, ColorRGB64 right)
        {
            throw new NotImplementedException();
        }
        public static ColorRGB64 operator *(ColorRGB64 left, double scalar)
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
                return this.alpha / 65535.0f;
            }
            set
            {
                this.alpha = (byte)(value * ushort.MaxValue);
            }
        }
    }
}
