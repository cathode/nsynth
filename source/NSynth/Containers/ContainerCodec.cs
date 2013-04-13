/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;

using System.Text;

namespace NSynth.Containers
{
    /// <summary>
    /// Represents a multimedia container format.
    /// </summary>
    public abstract class ContainerCodec : Codec
    {
        /*
        #region Methods
        public virtual Track GetTrack(int index)
        {
            throw new NotImplementedException();
        }
        public abstract IEnumerable<Track> GetTracks();
        /// <summary>
        /// When overriden in a derived class, returns a value indicating if the specified <see cref="NSynth.TrackType"/> is supported by the container.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract bool IsTrackTypeSupported(TrackType type);
        #endregion*/
    }
}
