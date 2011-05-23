/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth
{
    /// <summary>
    /// Enumerates supported kinds of multimedia tracks.
    /// </summary>
    public enum TrackKind
    {
        /// <summary>
        /// Indicates an unspecified track.
        /// </summary>
        Unspecified = 0x0,

        /// <summary>
        /// Indicates a track containing video content.
        /// </summary>
        Video,

        /// <summary>
        /// Indicates a track containing audio content.
        /// </summary>
        Audio,

        /// <summary>
        /// Indicates a track containing subtitle (text) content.
        /// </summary>
        Subtitle,

        /// <summary>
        /// Indicates a track containing navigation (chapters, menus) content.
        /// </summary>
        Navigation,

        /// <summary>
        /// Indicates a track containing non-media data, such as embedded fonts.
        /// </summary>
        Data,
    }
}
