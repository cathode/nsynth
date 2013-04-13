/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Video
{
    /// <summary>
    /// Provides shared functionality for <see cref="Codec"/> implementations that encode or decode video content.
    /// </summary>
    public abstract class VideoCodec : Codec
    {
        /// <summary>
        /// Gets a value indicating whether the codec supports interlaced video.
        /// </summary>
        public abstract bool SupportsInterlacing
        {
            get;
        }

        /// <summary>
        /// Gets the maximum bit depth per pixel supported by the codec.
        /// </summary>
        public abstract int MaxBitDepth
        {
            get;
        }

        /// <summary>
        /// Gets the maximum width of a video frame (in pixels) that is supported by the codec.
        /// </summary>
        public abstract int MaxFrameWidth
        {
            get;
        }

        /// <summary>
        /// Gets the maximum height of a video frame (in pixels) that is supported by the codec.
        /// </summary>
        public abstract int MaxFrameHeight
        {
            get;
        }

        /// <summary>
        /// Gets the maximum frame rate supported by the codec.
        /// </summary>
        public abstract SampleRate MaxFrameRate
        {
            get;
        }
    }
}
