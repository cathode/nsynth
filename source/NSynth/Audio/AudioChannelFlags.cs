/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;

namespace NSynth.Audio
{
    /// <summary>
    /// Represents flags associated with an audio channel.
    /// </summary>
    [Flags]
    public enum AudioChannelFlags
    {
        /// <summary>
        /// Indicates no special attributes.
        /// </summary>
        None = 0x0,
        /// <summary>
        /// Indicates the channel carries low-frequency effects data.
        /// </summary>
        LowFrequencyEffects,
    }
}
