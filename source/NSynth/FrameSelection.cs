/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.Contracts;

namespace NSynth
{
    /// <summary>
    /// Represents a selection of frames (accessed by index), and supports non-contigious ranges.
    /// </summary>
    public sealed class FrameSelection : IEnumerable<ulong>
    {
        #region Fields
        private readonly List<Range> ranges;
        #endregion
        #region Constructors
        public FrameSelection()
        {
            this.ranges = new List<Range>();
        }
        public FrameSelection(Range range)
        {
            this.ranges = new List<Range>();
            this.ranges.Add(range);
        }
        #endregion
        #region Methods
        public void Include(ulong index)
        {
            this.Include(index, 1);

        }
        public void Include(ulong startIndex, ulong count)
        {
            var rng = new Range(startIndex, 1);
            for (int i = 0; i < ranges.Count; ++i)
            {
                var r = this.ranges[i];
                //if (r.Contains(rng)

            }
        }
        public void Include(ulong[] indexes)
        {
            throw new NotImplementedException();
        }
        public void Exclude(ulong index)
        {
            throw new NotImplementedException();
        }
        public void Exclude(ulong startIndex, ulong count)
        {
            throw new NotImplementedException();
        }
        public void Exclude(ulong[] indexes)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<ulong> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}