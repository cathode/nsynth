/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;

using System.Text;

namespace NSynth
{
    /// <summary>
    /// Represents a range of selected frame indices.
    /// </summary>
    public sealed class FrameSelection : IEnumerable<int>
    {
        #region Methods
        public void Include(int index)
        {
            throw new NotImplementedException();
        }
        public void Include(int startIndex, int count)
        {
            throw new NotImplementedException();
        }
        public void Include(int[] indexes)
        {
            throw new NotImplementedException();
        }
        public void Exclude(int index)
        {
            throw new NotImplementedException();
        }
        public void Exclude(int startIndex, int count)
        {
            throw new NotImplementedException();
        }
        public void Exclude(int[] indexes)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<int> GetEnumerator()
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
