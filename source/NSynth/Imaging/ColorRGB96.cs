/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a color using three linear floating point color channels (Red, Green, Blue),
    /// using 96 bits of color information per pixel (32 bits per channel).
    /// </summary>
    public struct ColorRGB96 : IColor
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="ColorRGB96.Red"/> property.
        /// </summary>
        private float red;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB96.Green"/> property.
        /// </summary>
        private float green;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB96.Blue"/> property.
        /// </summary>
        private float blue;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB96"/> struct.
        /// </summary>
        /// <param name="red">The value of the red color component.</param>
        /// <param name="green">The value of the green color component.</param>
        /// <param name="blue">The value of the blue color component.</param>
        public ColorRGB96(byte red, byte green, byte blue)
        {
            this.red = red / 255.0f;
            this.green = green / 255.0f;
            this.blue = blue / 255.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB96"/> struct.
        /// </summary>
        /// <param name="red">The value of the red color component.</param>
        /// <param name="green">The value of the green color component.</param>
        /// <param name="blue">The value of the blue color component.</param>
        public ColorRGB96(ushort red, ushort green, ushort blue)
        {
            this.red = red / 65535.0f;
            this.green = green / 65535.0f;
            this.blue = blue / 65535.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB96"/> struct.
        /// </summary>
        /// <param name="red">The value of the red color component.</param>
        /// <param name="green">The value of the green color component.</param>
        /// <param name="blue">The value of the blue color component.</param>
        public ColorRGB96(int red, int green, int blue)
        {
            this.red = red / 4294967296.0f;
            this.green = green / 4294967296.0f;
            this.blue = blue / 4294967296.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB96"/> struct.
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public ColorRGB96(float red, float green, float blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the value of the red color component of the current <see cref="ColorRGB96"/> instance.
        /// </summary>
        public float Red
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
        /// Gets or sets the value of the green color component of the current <see cref="ColorRGB96"/> instance.
        /// </summary>
        public float Green
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
        /// Gets or sets the value of the blue color component of the current <see cref="ColorRGB96"/> instance.
        /// </summary>
        public float Blue
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

        float IColor.Alpha
        {
            get
            {
                return 1.0f;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Clamps the <see cref="ColorRGB"/> color values to the 0.0-1.0 range.
        /// </summary>
        public void Clamp()
        {
            this.red = Math.Max(Math.Min(this.red, 1.0f), 0.0f);
            this.green = Math.Max(Math.Min(this.green, 1.0f), 0.0f);
            this.blue = Math.Max(Math.Min(this.blue, 1.0f), 0.0f);
        }

        /// <summary>
        /// Compresses the <see cref="ColorRGB96"/> color values to the 0.0-1.0 range.
        /// </summary>
        public void Compress()
        {
            var shift = (this.red < 0.0f) ? this.red : 0.0f;
            shift = (this.green < shift) ? this.green : shift;
            shift = (this.blue < shift) ? this.blue : shift;

            if (shift > 0)
            {
                this.red += shift;
                this.green += shift;
                this.blue += shift;
            }

            var maxRange = (this.red > 1.0f) ? this.red : 1.0f;
            maxRange = (this.green > maxRange) ? this.green : maxRange;
            maxRange = (this.blue > maxRange) ? this.blue : maxRange;

            if (maxRange > 1.0f)
            {
                var factor = 1.0f / maxRange;

                this.red *= factor;
                this.green *= factor;
                this.blue *= factor;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is ColorRGB96)
                return this == (ColorRGB96)obj;

            return false;
        }

        public bool Equals(ColorRGB96 other)
        {
            return this.Red == other.Red && this.Green == other.Green && this.Blue == other.Blue;
        }

        /// <summary>
        /// Gets a new <see cref="ColorRGB"/> instance that is the clamped version of the current <see cref="ColorRGB"/>.
        /// </summary>
        /// <returns>A new <see cref="ColorRGB"/> instance that is the clamped version of the current <see cref="ColorRGB"/>.</returns>
        public ColorRGB96 GetClamped()
        {
            return new ColorRGB96(
                Math.Max(Math.Min(this.red, 1.0f), 0.0f),
                Math.Max(Math.Min(this.green, 1.0f), 0.0f),
                Math.Max(Math.Min(this.blue, 1.0f), 0.0f));
        }

        public ColorRGB96 GetCompressed()
        {
            var comp = this;
            comp.Compress();
            return comp;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region Operators
        public static bool operator ==(ColorRGB96 left, ColorRGB96 right)
        {
            return left.Red == right.Red && left.Green == right.Green && left.Blue == right.Blue;
        }
        public static bool operator !=(ColorRGB96 left, ColorRGB96 right)
        {
            return left.Red != right.Red || left.Green != right.Green || left.Blue != right.Blue;
        }

        /// <summary>
        /// Adds the two specified colors and returns a new <see cref="ColorRGB96"/> that is the result of the addition.
        /// </summary>
        /// <param name="left">The left-hand <see cref="ColorRGB96"/> operand.</param>
        /// <param name="right">The right-hand <see cref="ColorRGB96"/> operand.</param>
        /// <returns>A new <see cref="ColorRGB96"/> that is the result of the addition.</returns>
        /// <remarks>Values are not clamped when added. Color channel values outside the 0.0-1.0 range are possible.</remarks>
        public static ColorRGB96 operator +(ColorRGB96 left, ColorRGB96 right)
        {
            return new ColorRGB96(left.red + right.red, left.green + right.green, left.blue + right.blue);
        }

        /// <summary>
        /// Subtracts one <see cref="ColorRGB96"/> from another and produces a new <see cref="ColorRGB96"/> instance as the result.
        /// </summary>
        /// <param name="left">The left-hand <see cref="ColorRGB96"/> operand.</param>
        /// <param name="right">The right-hand <see cref="ColorRGB96"/> operand.</param>
        /// <returns>A new <see cref="ColorRGB96"/> that is the result of the subtraction.</returns>
        /// <remarks>Values are not clamped when subtracted. Color channel values outside the 0.0-1.0 range are possible.</remarks>
        public static ColorRGB96 operator -(ColorRGB96 left, ColorRGB96 right)
        {
            return new ColorRGB96(left.red - right.red, left.green - right.green, left.blue - right.blue);
        }
        #endregion
    }
}
