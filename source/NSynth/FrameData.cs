/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NSynth
{
    /// <summary>
    /// Represents data contained in a video frame.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class FrameData<T> : IEnumerable<T>
    {
        #region Fields
        private readonly T[] data;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FrameData"/> class.
        /// </summary>
        /// <param name="tracks"></param>
        internal FrameData(int tracks)
        {
            Contract.Requires(tracks >= 0);

            this.data = new T[tracks];
        }
        #endregion
        #region Indexers
        public T this[int track]
        {
            get
            {
                Contract.Requires(track >= 0);
                Contract.Requires(track < this.Count);

                return this.data[track];
            }
            set
            {
                Contract.Requires(track >= 0);
                Contract.Requires(track < this.Count);

                this.data[track] = value;
            }
        }
        #endregion
        #region Properties
        public int Count
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);

                return this.data.Length;
            }
        }
        #endregion
        #region Methods
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Length; i++)
                yield return this.data[i];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Invariants for this type.
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariants()
        {
            Contract.Invariant(this.data != null);
        }
        #endregion
    }
}
