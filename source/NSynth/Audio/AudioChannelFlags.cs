/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */
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
