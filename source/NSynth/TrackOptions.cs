/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;

namespace NSynth
{
    /// <summary>
    /// Represents a set of options that can be applied to a <see cref="Track"/>.
    /// </summary>
    [Flags]
    public enum TrackOptions
    {
        /// <summary>
        /// Indicates no options are specified.
        /// </summary>
        None = 0x00,

        /// <summary>
        /// Indicates the track is comprised of frames with varying durations.
        /// </summary>
        VariableFrameRate = 0x01,

        /// <summary>
        /// Indicates the track is comprised of frames with varying sample counts.
        /// </summary>
        VariableSampleRate = 0x02,

        /// <summary>
        /// Indicates the track repeats the same frame or frames infinitely.
        /// </summary>
        Infinite = 0x04,
    }
}
