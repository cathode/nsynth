/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Runtime.InteropServices;
using System.Diagnostics.Contracts;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a color using three linear floating point color channels (Red, Green, Blue) and an alpha (opacity) channel,
    /// using 128 bits of color information per pixel (32 bits per channel).
    /// </summary>
    /// <remarks>
    /// The standard range for floating point values for each of the three color channels and the alpha channel is 0.0 to 1.0.
    /// Values outside of this range are supported but may yield unexpected results.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
    public struct ColorRGB : IColor
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="ColorRGB.Alpha"/> property.
        /// </summary>
        [FieldOffset(0x0C)]
        private float alpha;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB.Blue"/> property.
        /// </summary>
        [FieldOffset(0x08)]
        private float blue;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB.Green"/> property.
        /// </summary>
        [FieldOffset(0x04)]
        private float green;

        /// <summary>
        /// Backing field for the <see cref="ColorRGB.Red"/> property.
        /// </summary>
        [FieldOffset(0x00)]
        private float red;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB"/> struct.
        /// </summary>
        /// <param name="red">The value of the red component.</param>
        /// <param name="green">The value of the green component.</param>
        /// <param name="blue">The value of the blue component.</param>
        public ColorRGB(byte red, byte green, byte blue)
        {
            this.red = red / 255.0f;
            this.green = green / 255.0f;
            this.blue = blue / 255.0f;
            this.alpha = 1.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB"/> struct.
        /// </summary>
        /// <param name="red">The value of the red component.</param>
        /// <param name="green">The value of the green component.</param>
        /// <param name="blue">The value of the blue component.</param>
        /// <param name="alpha">The value of the alpha (opacity) component.</param>
        public ColorRGB(byte red, byte green, byte blue, byte alpha)
        {
            this.red = red / 255.0f;
            this.green = green / 255.0f;
            this.blue = blue / 255.0f;
            this.alpha = alpha / 255.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB"/> struct.
        /// </summary>
        /// <param name="red">The value of the red component.</param>
        /// <param name="green">The value of the green component.</param>
        /// <param name="blue">The value of the blue component.</param>
        public ColorRGB(ushort red, ushort green, ushort blue)
        {
            this.red = red / 65535.0f;
            this.green = green / 65535.0f;
            this.blue = blue / 65535.0f;
            this.alpha = 1.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB"/> struct.
        /// </summary>
        /// <param name="red">The value of the red component.</param>
        /// <param name="green">The value of the green component.</param>
        /// <param name="blue">The value of the blue component.</param>
        /// <param name="alpha">The value of the alpha (opacity) component.</param>
        public ColorRGB(ushort red, ushort green, ushort blue, ushort alpha)
        {
            this.red = red / 65535.0f;
            this.green = green / 65535.0f;
            this.blue = blue / 65535.0f;
            this.alpha = alpha / 65535.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB"/> struct.
        /// </summary>
        /// <param name="red">The value of the red component.</param>
        /// <param name="green">The value of the green component.</param>
        /// <param name="blue">The value of the blue component.</param>
        public ColorRGB(int red, int green, int blue)
        {
            this.red = red / 4294967296.0f;
            this.green = green / 4294967296.0f;
            this.blue = blue / 4294967296.0f;
            this.alpha = 1.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB"/> struct.
        /// </summary>
        /// <param name="red">The value of the red component.</param>
        /// <param name="green">The value of the green component.</param>
        /// <param name="blue">The value of the blue component.</param>
        /// <param name="alpha">The value of the alpha (opacity) component.</param>
        public ColorRGB(int red, int green, int blue, int alpha)
        {
            this.red = red / 4294967296.0f;
            this.green = green / 4294967296.0f;
            this.blue = blue / 4294967296.0f;
            this.alpha = alpha / 4294967296.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB"/> struct.
        /// </summary>
        /// <param name="red">The value of the red component,
        /// as a single-precision linear floating point value between 0.0 (fully unsaturated) and 1.0 (fully saturated).</param>
        /// <param name="green">The value of the green component,
        /// as a single-precision linear floating point value between 0.0 (fully unsaturated) and 1.0 (fully saturated).</param>
        /// <param name="blue">The value of the blue component,
        /// as a single-precision linear floating point value between 0.0 (fully unsaturated) and 1.0 (fully saturated).</param>
        public ColorRGB(float red, float green, float blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = 1.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB"/> struct.
        /// </summary>
        /// <param name="red">The value of the red component,
        /// as a single-precision linear floating point value between 0.0 (fully unsaturated) and 1.0 (fully saturated).</param>
        /// <param name="green">The value of the green component,
        /// as a single-precision linear floating point value between 0.0 (fully unsaturated) and 1.0 (fully saturated).</param>
        /// <param name="blue">The value of the blue component,
        /// as a single-precision linear floating point value between 0.0 (fully unsaturated) and 1.0 (fully saturated).</param>
        /// <param name="alpha">The value of the alpha (opacity) component,
        /// as a single-precision linear floating point value between 0.0 (fully transparent) and 1.0 (fully opaque).</param>
        public ColorRGB(float red, float green, float blue, float alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRGB"/> struct.
        /// </summary>
        /// <param name="color">An <see cref="IColor"/> instance from which the red, green, blue, and alpha values are used.</param>
        public ColorRGB(IColor color)
        {
            Contract.Requires(color != null);

            this.red = color.Red;
            this.green = color.Green;
            this.blue = color.Blue;
            this.alpha = color.Alpha;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the alpha (opacity) component of the current <see cref="ColorRGB"/>.
        /// </summary>
        public float Alpha
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
        /// Gets or sets the blue component of the current <see cref="ColorRGB"/>.
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

        /// <summary>
        /// Gets or sets the green component of the current <see cref="ColorRGB"/>.
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
        /// Gets or sets the red component of the current <see cref="ColorRGB"/>.
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
        public bool IsNormalized
        {
            get
            {
                return (this.red <= 1.0f && this.red >= 0.0f
                    && this.green <= 1.0f && this.green >= 0.0f
                    && this.blue <= 1.0f && this.blue >= 0.0f
                    && this.alpha <= 1.0f && this.alpha >= 0.0f);
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Constrains the current <see cref="ColorRGB"/> color values to the 0.0 to 1.0 range.
        /// </summary>
        public void Clamp()
        {
            Contract.Ensures(this.red >= 0.0f);
            Contract.Ensures(this.red <= 1.0f);
            Contract.Ensures(this.green >= 0.0f);
            Contract.Ensures(this.green <= 1.0f);
            Contract.Ensures(this.blue >= 0.0f);
            Contract.Ensures(this.blue <= 1.0f);
            Contract.Ensures(this.alpha >= 0.0f);
            Contract.Ensures(this.alpha <= 1.0f);
            Contract.Ensures(this.IsNormalized == true);

            this.red = (this.red > 1.0f) ? 1.0f : ((this.red < 0.0f) ? 0.0f : this.red);
            this.green = (this.green > 1.0f) ? 1.0f : (this.green < 0.0f) ? 0.0f : this.green;
            this.blue = (this.blue > 1.0f) ? 1.0f : (this.blue < 0.0f) ? 0.0f : this.blue;
            this.alpha = (this.alpha > 1.0f) ? 1.0f : (this.alpha < 0.0f) ? 0.0f : this.alpha;
        }

        /// <summary>
        /// Constrains the values of the current <see cref="ColorRGB"/> instance to the [0.0, 1.0] range.
        /// </summary>
        public void Normalize()
        {
            Contract.Ensures(this.red >= 0.0f);
            Contract.Ensures(this.red <= 1.0f);
            Contract.Ensures(this.green >= 0.0f);
            Contract.Ensures(this.green <= 1.0f);
            Contract.Ensures(this.blue >= 0.0f);
            Contract.Ensures(this.blue <= 1.0f);
            Contract.Ensures(this.alpha >= 0.0f);
            Contract.Ensures(this.alpha <= 1.0f);
            Contract.Ensures(this.IsNormalized == true);

            var shift = (this.red < 0.0f) ? this.red : 0.0f;
            shift = (this.green < shift) ? this.green : shift;
            shift = (this.blue < shift) ? this.blue : shift;
            shift = (this.alpha < shift) ? this.alpha : shift;

            if (shift > 0)
            {
                this.red += shift;
                this.green += shift;
                this.blue += shift;
                this.alpha += shift;
            }

            var maxRange = (this.red > 1.0f) ? this.red : 1.0f;
            maxRange = (this.green > maxRange) ? this.green : maxRange;
            maxRange = (this.blue > maxRange) ? this.blue : maxRange;
            maxRange = (this.alpha > maxRange) ? this.alpha : maxRange;

            if (maxRange > 1.0f)
            {
                var factor = 1.0f / maxRange;

                this.red *= factor;
                this.green *= factor;
                this.blue *= factor;
                this.alpha *= factor;
            }
        }

        /// <summary>
        /// Gets a new <see cref="ColorRGB"/> instance that is the constrained version of the specified <see cref="ColorRGB"/>.
        /// </summary>
        /// <returns>A new <see cref="ColorRGB"/> instance that is the constrained version of the specified <see cref="ColorRGB"/>.</returns>
        public static ColorRGB Clamp(ColorRGB color)
        {
            color.Clamp();
            return color;
        }

        /// <summary>
        /// Gets a new <see cref="ColorRGB"/> instance that is the compressed version of the current <see cref="ColorRGB"/>.
        /// </summary>
        /// <returns>A new <see cref="ColorRGB"/> instance that is the compressed version of the current <see cref="ColorRGB"/>.</returns>
        public ColorRGB GetNormalized()
        {
            ColorRGB comp = this;
            comp.Normalize();
            return comp;
        }

        /// <summary>
        /// Gets a new <see cref="ColorRGB96"/> instance that is the premultiplied alpha version of the current <see cref="ColorRGB"/>.
        /// </summary>
        /// <returns>A new <see cref="ColorRGB96"/> instance that is the premultiplied alpha version of the current <see cref="ColorRGB"/>.</returns>
        public ColorRGB96 GetPremultipliedAlpha()
        {
            return new ColorRGB96(this.red * this.alpha, this.green * this.alpha, this.blue * this.alpha);
        }

        /// <summary>
        /// Calculates a unique hash code for the current <see cref="ColorRGB"/> instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for the current instance.</returns>
        public override int GetHashCode()
        {
            var prefix = (int)((this.Red - this.Green) * this.Blue);

            int result = 128; // Seed with 128.

            unchecked
            {
                result += prefix + (result ^ (int)(this.Red * int.MaxValue));
                result += prefix + (result ^ (int)(this.Green * int.MaxValue));
                result += prefix + (result ^ (int)(this.Blue * int.MaxValue));
                result += prefix + (result ^ (int)(this.Alpha * int.MaxValue));
            }

            return (int)result;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false</returns>
        public override bool Equals(object obj)
        {
            if (obj is ColorRGB)
                return this == (ColorRGB)obj;

            return false;
        }

        /// <summary>
        /// Indicates whether this instance and a specified <see cref="ColorRGB"/> are equal.
        /// </summary>
        /// <param name="other">A <see cref="ColorRGB"/> instance to compare.</param>
        /// <returns>true if both instances represent the same value; otherwise, false.</returns>
        public bool Equals(ColorRGB other)
        {
            return this == other;
        }

        /// <summary>
        /// Premultiplies the alpha against the red, green, and blue components of the current <see cref="ColorRGB"/>.
        /// </summary>
        public void PremultiplyAlpha()
        {
            this.red *= this.alpha;
            this.green *= this.alpha;
            this.blue *= this.alpha;
            this.alpha = 1.0f;
        }
        #endregion
        #region Operators
        /// <summary>
        /// Determines if two <see cref="ColorRGB"/> instances represent the same value.
        /// </summary>
        /// <param name="left">The left-hand operand to compare.</param>
        /// <param name="right">The right-hand operand to compare.</param>
        /// <returns>true if both instances represent the same value; otherwise, false.</returns>
        public static bool operator ==(ColorRGB left, ColorRGB right)
        {
            return left.blue == right.blue && left.green == right.green && left.red == right.red;
        }

        /// <summary>
        /// Determines if two <see cref="ColorRGB"/> instances represent different values.
        /// </summary>
        /// <param name="left">The left-hand operand to compare.</param>
        /// <param name="right">The right-hand operand to compare.</param>
        /// <returns>true if both instances represent different values; otherwise, false.</returns>
        public static bool operator !=(ColorRGB left, ColorRGB right)
        {
            return left.blue != right.blue || left.green != right.green || left.red != right.red;
        }
        #endregion
    }
}