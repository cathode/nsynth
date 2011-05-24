/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;

namespace NSynth.Audio
{
    /// <summary>
    /// Represents a discrete audio channel within an audio track.
    /// </summary>
    public class AudioChannel
    {
        #region Fields
        private readonly List<Segment> segments;
        private AudioChannelFlags flags;
        #endregion
        #region Properties
        public AudioChannelFlags Flags
        {
            get
            {
                return this.flags;
            }
            set
            {
                this.flags = value;
            }
        }
        #endregion
        #region Constructors
        public AudioChannel()
        {
            this.segments = new List<Segment>();
        }
        #endregion
    }
}
