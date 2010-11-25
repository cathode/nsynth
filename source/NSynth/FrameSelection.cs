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
