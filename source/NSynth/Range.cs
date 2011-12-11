/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics.Contracts;

namespace NSynth
{
    /// <summary>
    /// Represents a range of integers.
    /// </summary>
    public struct Range : IEnumerable<ulong>
    {
        #region Fields
        private ulong start;
        private ulong length;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> struct.
        /// </summary>
        /// <param name="start">The first value in the range.</param>
        /// <param name="length">The number of values in the range.</param>
        public Range(ulong start, ulong length)
        {
            this.start = start;
            this.length = length;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Enumerates over the frame indices in the current
        /// <see cref="Range"/>.
        /// </summary>
        /// <returns>A range of <see cref="int32"/>s representing the
        /// frames in the current <see cref="Range"/>.</returns>
        public IEnumerator<ulong> GetEnumerator()
        {
            for (ulong i = 0; i < length; i++)
            {
                yield return i + start;
            }
        }

        /// <summary>
        /// Enumerates over the frame indices in the current
        /// <see cref="Range"/>.
        /// </summary>
        /// <returns>A range of <see cref="int32"/>s representing the
        /// frames in the current <see cref="Range"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Determines if the specified index is contained within the current <see cref="Range"/>.
        /// </summary>
        /// <param name="index">The index to compare.</param>
        /// <returns>true if the specified index is inside the current range; otherwise false.</returns>
        public bool Contains(ulong index)
        {
            return (this.Length > 0) && (index >= this.Start) && (index <= this.End);
        }

        /// <summary>
        /// Determines if the specified <see cref="Range"/> is contained within
        /// the current <see cref="Range."/>
        /// </summary>
        /// <param name="range">true if the specified <see cref="Range"/> is
        /// contained entirely within the current <see cref="Range"/>; otherwise false.</param>
        /// <returns></returns>
        public bool Contains(Range range)
        {
            return (this.Length > 0) && (range.Length > 0) && (range.Start >= this.Start) && (range.End <= this.End);
        }

        /// <summary>
        /// Determines if the current <see cref="Range"/> and the specified <see cref="Range"/>
        /// share any indices.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        /// <remarks>
        /// The current <see cref="Range"/> and the specified <see cref="Range"/> both must have a length of 1 or more,
        /// or else they aren't considered to be overlapping even if their start and end indices would otherwise overlap.
        /// </remarks>
        public bool Overlaps(Range range)
        {
            return (this.Length > 0) && (range.Length > 0) && (range.Start >= this.Start) && (range.Start <= this.End);
        }

        /// <summary>
        /// Returns a new <see cref="Range"/> that represents the indices which are shared by the current instance
        /// and the specified instance.
        /// </summary>
        /// <param name="range">The <see cref="Range"/> to intersect with.</param>
        /// <returns>A new <see cref="Range"/> instance representing the result of the intersection.</returns>
        public static Range Intersect(Range a, Range b)
        {
            if (a.Length > 0 && b.Length > 0 && b.Start < a.End && a.Start < b.End)
            {
                var start = Math.Max(a.Start, b.Start);
                var end = Math.Min(a.End, b.End);

                return new Range(start, end - start);
            }

            // No intersection
            return new Range();
        }

        [ContractInvariantMethod]
        private void ObjectInvariants()
        {
            Contract.Invariant(this.Length >= 0);
            Contract.Invariant(this.Start <= this.End);
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the index of the first index in the range.
        /// </summary>
        public ulong Start
        {
            get
            {
                return this.start;
            }
            set
            {
                this.start = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of indices in the range.
        /// </summary>
        public ulong Length
        {
            get
            {
                return this.length;
            }
            set
            {
                this.length = value;
            }
        }

        /// <summary>
        /// Gets the index of the last index in the range.
        /// </summary>
        public ulong End
        {
            get
            {
                return this.start + this.length;
            }
        }
        #endregion
    }
}
