/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;

namespace NSynth
{
    /// <summary>
    /// Represents a collection of track data associated with a <see cref="Clip"/>.
    /// </summary>
    /// <typeparam name="T">The track type.</typeparam>
    public sealed class ClipData<T> : IEnumerable<T> where T : Track
    {
        #region Fields
        /// <summary>
        /// Holds the track data.
        /// </summary>
        private readonly List<T> tracks;

        /// <summary>
        /// Holds the clip that this instance belongs to.
        /// </summary>
        private readonly Clip clip;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ClipData&lt;T&gt;"/> class.
        /// </summary>
        internal ClipData(Clip clip)
        {
            this.clip = clip;
            this.tracks = new List<T>();
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the number of tracks of the current kind contained in the <see cref="Clip"/>.
        /// </summary>
        public int Count
        {
            get
            {
                return this.tracks.Count;
            }
        }
        #endregion
        #region Indexers
        /// <summary>
        /// Gets the <see cref="T"/> at the specified track index.
        /// </summary>
        /// <param name="index">The zero-based index of the track to get.</param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return this.tracks[index];
            }
            set
            {
                this.tracks[index] = value;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Adds the specified track to the clip track data.
        /// </summary>
        /// <param name="track">The track to add.</param>
        public void Add(T track)
        {
            if (this.tracks.Contains(track))
                throw new InvalidOperationException("Cannot add the same track twice.");

            this.clip.FrameCount = Math.Max(this.clip.FrameCount, track.FrameCount);
            this.tracks.Add(track);
        }

        public void RemoveAt(int trackIndex)
        {
            throw new NotImplementedException();
            // this.tracks.RemoveAt(trackIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.tracks.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.tracks.GetEnumerator();
        }
        #endregion
    }
}
