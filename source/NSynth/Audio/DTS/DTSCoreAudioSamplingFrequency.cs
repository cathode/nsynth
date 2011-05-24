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
    /// Specifies the sampling frequency of audio samples in the core encoder.
    /// </summary>
    /// <remarks>
    /// This enumeration represents possible values of the Core Audio Sampling Frequency (SFREQ) field in the DTS specification.
    /// The SFREQ field is 4-bits.
    /// </remarks>
    public enum DTSCoreAudioSamplingFrequency
    {
        /*
        The following is taken from the DTS Coherent Acoustics specification document, pages 12 and 13.
        
        It specifies the sampling frequency of audio samples in the core encoder, based on table 5.5. When the source sampling
        frequency is beyond 48 kHz the audio is encoded in up to 3 separate frequency bands. The base-band audio, for
        example, 0 kHz to 16 kHz, 0 kHz to 22,05 kHz or 0 kHz to 24 kHz, is encoded and packed into the core audio data
        arrays. The SFREQ corresponds to the sampling frequency of the base-band audio. The audio above the base-band (the
        extended bands), for example, 16 kHz to 32kHz, 22,05 kHz to 44,1 kHz, 24 kHz to 48 kHz, is encoded and packed into
        the extended coding arrays which reside at the end of the core audio data arrays. If the decoder is unable to make use of
        the high sample rate data this information may be ignored and the base-band audio converted normally using a standard
        sampling rates (32 kHz, 44,1 kHz or 48 kHz). If the decoder is receiving data coded at sampling rates lower than that
        available from the system then interpolation (2× or 4×) will be required (see table 5.6).

        Table 5.5: Core audio sampling frequencies
        
        SFREQ       Core Audio Sampling Frequency
        0b0000      Invalid
        0b0001      8 kHz
        0b0010      16 kHz
        0b0011      32 kHz
        0b0100      Invalid
        0b0101      Invalid
        0b0110      11,025 kHz
        0b0111      22,05 kHz
        0b1000      44,1 kHz
        0b1001      Invalid
        0b1010      Invalid
        0b1011      12 kHz
        0b1100      24 kHz
        0b1101      48 kHz
        0b1110      Invalid

        Table 5.6: Sub-sampled audio decoding for standard sampling rates.
        
        Core Audio              Hardware                Required 
        Sampling Frequency      Sampling Frequency      Filtering

        8 kHz                   32 kHz                  4 × Interpolation
        16 kHz                  32 kHz                  2 × Interpolation
        32 kHz                  32 kHz                  none
        11 kHz                  44,1 kHz                4 × Interpolation
        22,05 kHz               44,1 kHz                2 × Interpolation
        44,1 kHz                44,1 kHz                none
        12 kHz                  48 kHz                  4 × Interpolation
        24 kHz                  48 kHz                  2 × Interpolation
        48 kHz                  48 kHz                  none
        */
        /// <summary>
        /// Indicates the default value for this enumeration is not a valid sampling frequency.
        /// </summary>
        Invalid = 0x0,
        /// <summary>
        /// 8kHz core audio sampling rate.
        /// </summary>
        _8kHz = 1,
        /// <summary>
        /// 16kHz core audio sampling rate.
        /// </summary>
        _16kHz = 2,
        /// <summary>
        /// 32kHz core audio sampling rate.
        /// </summary>
        _32kHz = 3,
        /// <summary>
        /// 11.025kHz core audio sampling rate.
        /// </summary>
        _11_025kHz = 6,
        /// <summary>
        /// 22.050kHz core audio sampling rate.
        /// </summary>
        _22_050kHz = 7,
        /// <summary>
        /// 44.100kHz core audio sampling rate.
        /// </summary>
        _44_100kHz = 8,
        /// <summary>
        /// 12kHz core audio sampling rate.
        /// </summary>
        _12kHz = 11,
        /// <summary>
        /// 24kHz core audio sampling rate.
        /// </summary>
        _24kHz = 12,
        /// <summary>
        /// 48kHz core audio sampling rate.
        /// </summary>
        _48kHz = 13,
    }
}
