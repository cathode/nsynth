/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections;
using System.Collections.Generic;

namespace NSynth
{
    /// <summary>
    /// Represents a range of integers.
    /// </summary>
    public struct Range : IEnumerable<long>
    {
        #region Fields
        private long start;
        private long count;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> struct.
        /// </summary>
        /// <param name="start">The first value in the range.</param>
        /// <param name="count">The number of values in the range.</param>
        public Range(long start, long count)
        {
            this.start = start;
            this.count = count;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Enumerates over the frame indices in the current
        /// <see cref="Range"/>.
        /// </summary>
        /// <returns>A range of <see cref="int32"/>s representing the
        /// frames in the current <see cref="Range"/>.</returns>
        public IEnumerator<long> GetEnumerator()
        {
            for (long i = 0; i < count; i++)
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
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the 0-aligned frame number that marks the first frame
        /// in the current <see cref="Range"/>.
        /// </summary>
        public int Start
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
        /// Gets or sets the number of frames in the current
        /// <see cref="Range"/>.
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }
        #endregion
    }
}
