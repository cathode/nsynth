/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Audio
{
    /// <summary>
    /// Represents an audio sample stored using a 32-bit signed integer value.
    /// </summary>
    public struct Sample32
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Sample32.Value"/> property.
        /// </summary>
        private int value;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Sample32"/> struct.
        /// </summary>
        /// <param name="value">The value of the audio sample.</param>
        public Sample32(int value)
        {
            this.value = value;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the value of the current audio sample.
        /// </summary>
        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
        #endregion
        #region Methods
        public static Sample32 From8BitUnsigned(byte value)
        {
            return new Sample32(value << 24);
        }

        public static Sample32 From8BitSigned(sbyte value)
        {
            return new Sample32(value << 24);
        }

        public static Sample32 From16BitSigned(short value)
        {
            return new Sample32(value << 16);
        }

        public static Sample32 From24BitSigned(int value)
        {
            return new Sample32(value << 8);
        }

        public static Sample32 From16BitUnsigned(ushort value)
        {
            return new Sample32(value << 16);
        }

        public static Sample32 From24BitUnsigned(int value)
        {
            return new Sample32((int)(value << 8));
        }

        public override bool Equals(object obj)
        {
            if (obj is Sample32)
                return this == (Sample32)obj;

            return false;
        }

        /// <summary>
        /// Overridden. Returns the hash code for the current <see cref="Scample"/>.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for the current <see cref="Sample32"/>.</returns>
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Operators

        /// <summary>
        /// Indicates if the two <see cref="Sample32f"/> instances have the same value.
        /// </summary>
        /// <param name="left">The left-hand <see cref="Sample32f"/> instance.</param>
        /// <param name="right">The right-hand <see cref="Sample32f"/> instance.</param>
        /// <returns>true if both instances have the same value; otherwise, false.</returns>
        public static bool operator ==(Sample32 left, Sample32 right)
        {
            return left.Value == right.Value;
        }

        /// <summary>
        /// Indicates if the two <see cref="Sample32f"/> instances have different values.
        /// </summary>
        /// <param name="left">The left-hand <see cref="Sample32f"/> instance.</param>
        /// <param name="right">The right-hand <see cref="Sample32f"/> instance.</param>
        /// <returns>true if both instances have different values; otherwise, false.</returns>
        public static bool operator !=(Sample32 left, Sample32 right)
        {
            return left.Value != right.Value;
        }

        public static implicit operator Sample32(Sample16 sample)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}