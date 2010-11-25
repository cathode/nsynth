/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;

namespace NSynth
{
    public sealed class FrameData<T> : IEnumerable<T>
    {
        #region Fields
        private readonly T[] data;
        #endregion
        #region Constructors
        internal FrameData(int tracks)
        {
            this.data = new T[tracks];
        }
        #endregion
        #region Indexers
        public T this[int track]
        {
            get
            {
                return this.data[track];
            }
            set
            {
                this.data[track] = value;
            }
        }
        #endregion
        #region Properties
        public int Count
        {
            get
            {
                return this.data.Length;
            }
        }
        #endregion

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Length; i++)
                yield return this.data[i];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
