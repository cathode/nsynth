/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
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
    public sealed class FrameSelection : IEnumerable<long>
    {
        #region Fields
        private readonly List<Range> ranges;
        #endregion
        #region Constructors
        public FrameSelection()
        {
            this.ranges = new List<Range>();
        }
        #endregion
        #region Methods
        public void Include(long index)
        {
            throw new NotImplementedException();
        }
        public void Include(long startIndex, long count)
        {
            throw new NotImplementedException();
        }
        public void Include(long[] indexes)
        {
            throw new NotImplementedException();
        }
        public void Exclude(long index)
        {
            throw new NotImplementedException();
        }
        public void Exclude(long startIndex, long count)
        {
            throw new NotImplementedException();
        }
        public void Exclude(long[] indexes)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<long> GetEnumerator()
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
