/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */
using System.Collections.Generic;
using System.Text;

namespace NSynth.Audio.DTS
{
    /// <summary>
    /// Enumerates supported bit rates for DTS bitstreams.
    /// </summary>
    /// <remarks>
    /// This enum represents values of the Transmission Bit Rate (RATE) field in the DTS specification.
    /// RATE has a 5-bit value.
    /// <para>
    /// The DTS specification also notes with regard to the RATE field;
    /// "Due to the limitations of the transmission medium the actual bit rate may be slightly different from the targeted bit rate,
    /// as listed in table 5.8 for the two types of applications. The bit-rates that are not shown in the table 5.8 are not applicable
    /// on either of these two applications."
    /// </para>
    /// </remarks>
    public enum DTSTransmissionBitRate
    {
        /// <summary>
        /// Indicates a constant bit rate of 32 kbps.
        /// </summary>
        Fixed32kbps = 0,

        /// <summary>
        /// Indicates a constant bit rate of 56 kbps.
        /// </summary>
        Fixed56kbps = 1,

        /// <summary>
        /// Indicates a constant bit rate of 64 kbps.
        /// </summary>
        Fixed64kbps = 2,

        /// <summary>
        /// Indicates a constant bit rate of 96 kbps.
        /// </summary>
        Fixed96kbps = 3,

        /// <summary>
        /// Indicates a constant bit rate of 112 kbps.
        /// </summary>
        Fixed112kbps = 4,

        /// <summary>
        /// Indicates a constant bit rate of 128 kbps.
        /// </summary>
        Fixed128kbps = 5,

        /// <summary>
        /// Indicates a constant bit rate of 192 kbps.
        /// </summary>
        Fixed192kbps = 6,

        /// <summary>
        /// Indicates a constant bit rate of 224 kbps.
        /// </summary>
        Fixed224kbps = 7,

        /// <summary>
        /// Indicates a constant bit rate of 256 kbps.
        /// </summary>
        Fixed256kbps = 8,

        /// <summary>
        /// Indicates a constant bit rate of 320 kbps.
        /// </summary>
        Fixed320kbps = 9,

        /// <summary>
        /// Indicates a constant bit rate of 384 kbps.
        /// </summary>
        Fixed384kbps = 10,

        /// <summary>
        /// Indicates a constant bit rate of 448 kbps.
        /// </summary>
        Fixed448kbps = 11,

        /// <summary>
        /// Indicates a constant bit rate of 512 kbps.
        /// </summary>
        Fixed512kbps = 12,

        /// <summary>
        /// Indicates a constant bit rate of 576 kbps.
        /// </summary>
        Fixed576kbps = 13,

        /// <summary>
        /// Indicates a constant bit rate of 640 kbps.
        /// </summary>
        Fixed640kbps = 14,

        /// <summary>
        /// Indicates a constant bit rate of 768 kbps.
        /// </summary>
        Fixed768kbps = 15,

        /// <summary>
        /// Indicates a constant bit rate of 960 kbps.
        /// </summary>
        Fixed960kbps = 16,

        /// <summary>
        /// Indicates a constant bit rate of 1024 kbps.
        /// </summary>
        Fixed1024kbps = 17,

        /// <summary>
        /// Indicates a constant bit rate of 1152 kbps.
        /// </summary>
        Fixed1152kbps = 18,

        /// <summary>
        /// Indicates a constant bit rate of 1280 kbps.
        /// </summary>
        Fixed1280kbps = 19,

        /// <summary>
        /// Indicates a constant bit rate of 1344 kbps.
        /// </summary>
        Fixed1344kbps = 20,

        /// <summary>
        /// Indicates a constant bit rate of 1408 kbps.
        /// </summary>
        Fixed1408kbps = 21,

        /// <summary>
        /// Indicates a constant bit rate of 1411.2 kbps.
        /// </summary>
        Fixed1411_2kbps = 22,

        /// <summary>
        /// Indicates a constant bit rate of 1472 kbps.
        /// </summary>
        Fixed1472kbps = 23,

        /// <summary>
        /// Indicates a constant bit rate of 1536 kbps.
        /// </summary>
        Fixed1536kbps = 24,

        /// <summary>
        /// Indicates a constant bit rate of 1920 kbps.
        /// </summary>
        Fixed1920kbps = 25,

        /// <summary>
        /// Indicates a constant bit rate of 2048 kbps.
        /// </summary>
        Fixed2048kbps = 26,

        /// <summary>
        /// Indicates a constant bit rate of 3072 kbps.
        /// </summary>
        Fixed3072kbps = 27,

        /// <summary>
        /// Indicates a constant bit rate of 3840 kbps.
        /// </summary>
        Fixed3840kbps = 28,

        /// <summary>
        /// Allows for bit rates that are not predefined.
        /// </summary>
        Open = 29,

        /// <summary>
        /// Variable, potentially lossy rate. Bit rate may change between frames.
        /// </summary>
        Variable = 30,

        /// <summary>
        /// Variable mathematically-lossless rate. Bit rate may change between frames.
        /// </summary>
        Lossless = 31,
    }
}
