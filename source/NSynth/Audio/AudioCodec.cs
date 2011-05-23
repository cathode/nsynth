/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.IO;

namespace NSynth.Audio
{
    /// <summary>
    /// Provides audio-specific functionality on top of the base <see cref="Codec"/> class to support audio codec implementations.
    /// </summary>
    public abstract class AudioCodec : Codec
    {
        #region Properties
        /// <summary>
        /// Gets the maximum number of audio channels in an audio track that is supported by the current audio codec.
        /// </summary>
        public abstract int MaxChannels
        {
            get;
        }

        /// <summary>
        /// Gets the maximum bit depth of audio samples that is supported by the current audio codec.
        /// </summary>
        public abstract int MaxDepth
        {
            get;
        }

        /// <summary>
        /// Gets the maximum audio sample rate that is supported by the current audio codec.
        /// </summary>
        public abstract int MaxSampleRate
        {
            get;
        }
        #endregion
    }
}
