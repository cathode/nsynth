/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */
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
