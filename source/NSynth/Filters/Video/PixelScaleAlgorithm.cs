/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/

namespace NSynth.Filters.Internal.Video
{
    /// <summary>
    /// Represents supported pixel scaling algorithms.
    /// </summary>
    public enum PixelScaleAlgorithm
    {
        /// <summary>
        /// Indicates 2x magnification using HQX algorithm.
        /// </summary>
        HQ2x,

        /// <summary>
        /// Indicates 3x magnification using HQX algorithm.
        /// </summary>
        HQ3x,

        /// <summary>
        /// Indicates 4x magnification using HQX algorithm.
        /// </summary>
        HQ4x,
        EPX,
        Scale2X,
        AdvMAME2X,
        AdvMAME3X,
        Eagle,
        Sai2X,
        SuperSai2X,
        SuperEagle,
    }
}
