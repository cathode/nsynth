/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;

namespace NSynth.Audio
{
    /// <summary>
    /// Represents an ordered, contigious block of 32-bit floating point audio samples.
    /// </summary>
    public sealed class Segment
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Segment[int]"/> indexer.
        /// </summary>
        private readonly Sample32[] samples;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Segment"/> class.
        /// </summary>
        /// <param name="count">The number of audio samples that the new segment will contain.</param>
        public Segment(int count)
        {
            this.samples = new Sample32[count];
        }
        #endregion
        #region Properties

        /// <summary>
        /// Gets the length in samples of the current <see cref="Segment"/>
        /// </summary>
        public int Length
        {
            get
            {
                return this.samples.Length;
            }
        }
        #endregion
        #region Indexers
        /// <summary>
        /// Gets or sets the <see cref="Sample32"/> at the specified zero-based index within the current <see cref="Segment"/>.
        /// </summary>
        /// <param name="index">The zero-based index of the <see cref="Sample32"/> to get or set.</param>
        /// <returns>The <see cref="Sample32"/> at the specified index.</returns>
        public Sample32 this[int index]
        {
            get
            {
                return this.samples[index];
            }
            set
            {
                this.samples[index] = value;
            }
        }
        #endregion
        #region Operators
        public static Segment operator +(Segment left, Segment right)
        {
            var result = new Segment(left.Length + right.Length);

            left.samples.CopyTo(result.samples, 0);
            int i = left.Length;
            if (i <= result.Length + right.samples.Length)
                right.samples.CopyTo(result.samples, i);
            else
                throw new NotImplementedException();

            return result;
        }
        #endregion
    }
}
