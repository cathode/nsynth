/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 *****************************************************************************/

namespace NSynth
{
    /// <summary>
    /// Provides common frame rate values for various types of video sources. This class cannot be instantiated.
    /// </summary>
    public static class FrameRates
    {
        #region Fields
        /// <summary>
        /// Gets the frame rate of the NTSC standard, or about 29.97003 frames per second.
        /// </summary>
        public const decimal NTSC = 30000.0m / 1001.0m;

        /// <summary>
        /// Gets the frame rate of the PAL standard, or 25 frames per second.
        /// </summary>
        public const decimal PAL = 25000.0m / 1000.0m;

        /// <summary>
        /// Gets the frame rate of film, or about 23.976024 frames per second.
        /// </summary>
        public const decimal Film = 24000.0m / 1001.0m;
        #endregion
    }
}