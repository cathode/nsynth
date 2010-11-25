/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 *****************************************************************************/
using System;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a 128-bit floating point color in the CIELAB color space, using the D50 white point.
    /// </summary>
    public struct ColorLAB : IEquatable<ColorLAB>, IColor
    {
        #region Fields

        /// <summary>
        /// Backing field for the <see cref="ColorLAB.L"/> property.
        /// </summary>
        private float l;

        /// <summary>
        /// Backing field for the <see cref="ColorLAB.A"/> property.
        /// </summary>
        private float a;

        /// <summary>
        /// Backing field for the <see cref="ColorLAB.B"/> property.
        /// </summary>
        private float b;

        /// <summary>
        /// Backing field for the <see cref="ColorLAB.Alpha"/> property.
        /// </summary>
        private float alpha;

        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorLAB"/> struct.
        /// </summary>
        /// <param name="l">A 32-bit IEEE floating point number between -100.0 and 100.0 that is the lightness value of the new instance.</param>
        /// <param name="a">A 32-bit IEEE floating point number between -100.0 and 100.0 that is the blue-yellow difference value of the new instance.</param>
        /// <param name="b">A 32-bit IEEE floating point number between -100.0 and 100.0 that is the red-green difference value of the new instance.</param>
        public ColorLAB(int l, int a, int b)
        {
            this.l = l;
            this.a = a;
            this.b = b;
            this.alpha = int.MaxValue;
        }

        #endregion
        #region Properties

        /// <value>
        /// Gets or sets the alpha (transparency) value of the current <see cref="ColorLAB"/>.
        /// </value>
        /// <remarks>
        /// Acceptable values range from 0.0 (completely transparent) to 1.0 (completely opaque). Values outside this range are clamped.
        /// </remarks>
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
        /// Gets or sets the value of the blue-difference component.
        /// </summary>
        public float A
        {
            get
            {
                return this.a;
            }
            set
            {
                this.a = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the red-difference component.
        /// </summary>
        public float B
        {
            get
            {
                return this.b;
            }
            set
            {
                this.b = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the lightness component.
        /// </summary>
        public float L
        {
            get
            {
                return this.l;
            }
            set
            {
                this.l = value;
            }
        }

        #endregion
        #region Methods

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>true if obj and this instance are the same type and represent the same value; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ColorLAB)
                return this == (ColorLAB)obj;

            return false;
        }

        /// <summary>
        /// Indicates whether the current <see cref="ColorLAB"/> has the same value as the specified <see cref="ColorLAB"/> instance.
        /// </summary>
        /// <param name="other">A <see cref="ColorLAB"/> instance to compare to the current instance.</param>
        /// <returns>true if both instances represent the same value; otherwise, false.</returns>
        public bool Equals(ColorLAB other)
        {
            return this == other;
        }

        /// <summary>
        /// Overridden. Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return __HashCode.Calculate("ColorLAB", this.L, this.A, this.B);
        }

        #endregion
        #region Operators

        /// <summary>
        /// Indicates whether two <see cref="ColorLAB"/> instances have the same value.
        /// </summary>
        /// <param name="left">The left-hand <see cref="ColorLAB"/> instance to compare.</param>
        /// <param name="right">The right-hand <see cref="ColorLAB"/> instance to compare.</param>
        /// <returns>true if both instances represent the same value; otherwise, false.</returns>
        public static bool operator ==(ColorLAB left, ColorLAB right)
        {
            return left.L == right.L && left.A == right.A && left.B == right.B;
        }

        /// <summary>
        /// Indicates whether two <see cref="ColorLAB"/> instances have different values.
        /// </summary>
        /// <param name="left">The left-hand <see cref="ColorLAB"/> instance to compare.</param>
        /// <param name="right">The right-hand <see cref="ColorLAB"/> instance to compare.</param>
        /// <returns>true if both instances represent different values; otherwise, false.</returns>
        public static bool operator !=(ColorLAB left, ColorLAB right)
        {
            return left.L != right.L || left.A != right.A || left.B != right.B;
        }

        #endregion

        float IColor.Red
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        float IColor.Green
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        float IColor.Blue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
