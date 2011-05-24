/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;
using System.Text;

namespace NSynth.Audio.DTS
{
    /// <summary>
    /// Indicates the quantization resolution of source PCM samples.
    /// </summary>
    public enum DTSSourcePCMResolution
    {
        /// <summary>
        /// 16-bits per sample.
        /// </summary>
        Sample16 = 0,

        /// <summary>
        /// 16-bits per sample, left and right channels mastered in DTS ES format.
        /// </summary>
        Sample16ES = 1,

        /// <summary>
        /// 20-bits per sample.
        /// </summary>
        Sample20 = 3,

        /// <summary>
        /// 20-bits per sample, left and right channels mastered in DTS ES format.
        /// </summary>
        Sample20ES = 4,

        /// <summary>
        /// 24-bits per sample.
        /// </summary>
        Sample24 = 5,

        /// <summary>
        /// 24-bits per sample, left and right channels mastered in DTS ES format.
        /// </summary>
        Sample24ES = 6,
    }
}
