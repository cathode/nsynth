/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved. */
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Video.Dirac
{
    /// <summary>
    /// Enumerates predefined base video formats, as defined in table 10.1.
    /// </summary>
    public enum DiracPredefinedVideoFormats
    {
        /// <summary>
        /// Indicates a custom base video format (that is not predefined in the Dirac specification).
        /// </summary>
        Custom = 0,

        /// <summary>
        /// 
        /// </summary>
        QSIF525 = 1,

        /// <summary>
        /// 
        /// </summary>
        QCIF = 2,

        /// <summary>
        /// 
        /// </summary>
        SIF525 = 3,

        /// <summary>
        /// 
        /// </summary>
        CIF = 4,

        /// <summary>
        /// 
        /// </summary>
        X4SIF525 = 5,

        /// <summary>
        /// 
        /// </summary>
        X4CIF = 6,

        /// <summary>
        /// Indicates standard-definition interlaced video, 525 lines x 59.94 fields per second.
        /// </summary>
        SD480I60 = 7,

        /// <summary>
        /// Indicates standard-definition interlaced video, 625 lines x 50 fields per second.
        /// </summary>
        SD576I50 = 8,

        /// <summary>
        /// Indicates high-definition progressive video, 720 lines x 59.94 frames per second.
        /// </summary>
        HD720P60 = 9,

        /// <summary>
        /// Indicates high-definition progressive video, 720 lines x 50 frames per second.
        /// </summary>
        HD720P50 = 10,

        /// <summary>
        /// Indicates high-definition interlaced video, 1080 lines x 60 fields per second.
        /// </summary>
        HD1080I60 = 11,

        /// <summary>
        /// Indicates high-definition interlaced video, 1080 lines x 50 fields per second.
        /// </summary>
        HD1080I50 = 12,

        /// <summary>
        /// Indicates high-definition progressive video, 1080 lines x 59.94 frames per second.
        /// </summary>
        HD1080P60 = 13,

        /// <summary>
        /// Indicates high-definition progressive video, 1080 lines x 50 frames per second.
        /// </summary>
        HD1080P50 = 14,

        /// <summary>
        /// Indicates digital cinema progressive video, 2048 x 1080 ("2K") pixels per frame, 24 frames per second.
        /// </summary>
        DC2K24 = 15,

        /// <summary>
        /// Indicates digital cinema progressive video, 4096 x 2160 ("4K") pixels per frame, 24 frames per second.
        /// </summary>
        DC4K24 = 16,

        /// <summary>
        /// Indicates ultra high-definition progressive video, 3840 x 2160 pixels per frame, 59.94 frames per second.
        /// </summary>
        UHDTV4K60 = 17,

        /// <summary>
        /// Indicates ultra high-definition progressive video, 3840 x 2160 pixels per frame, 50 frames per second.
        /// </summary>
        UHDTV4K50 = 18,

        /// <summary>
        /// Indicates ultra high-definition progressive video, 7680 x 4320 pixels per frame, 59.94 frames per second.
        /// </summary>
        UHDTV8K60 = 19,

        /// <summary>
        /// Indicates ultra high-definition progressive video, 7680 x 4320 pixels per frame, 50 frames per second.
        /// </summary>
        UHDTV8K50 = 20,
    }
}
