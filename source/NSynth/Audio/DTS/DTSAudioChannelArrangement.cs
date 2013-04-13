/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;
using System.Text;

namespace NSynth.Audio.DTS
{
    /// <summary>
    /// Represents supported values for the audio channel arrangement field in a DTS frame header.
    /// </summary>
    /// <remarks>
    /// Represents the Audio Channel Arrangement (AMODE) field in a DTS header. AMODE is a 6-bit field with valid values defined by this enum.
    /// </remarks>
    public enum DTSAudioChannelArrangement
    {
        /// <summary>
        /// 1 channel, A (mono).
        /// </summary>
        Mono = 0x00,

        /// <summary>
        /// 2 channel, A+B (dual mono).
        /// </summary>
        DualMono = 0x01,

        /// <summary>
        /// 2 channel, L + R (stereo).
        /// </summary>
        Stereo = 0x02,

        /// <summary>
        /// 2 channel, (L+R) + (L-R) (sum-difference).
        /// </summary>
        Stereo_SumDifference = 0x03,

        /// <summary>
        /// 2 channel, LT + RT (left and right total).
        /// </summary>
        Left_Right_Total = 0x04,

        /// <summary>
        /// 3 channels, C + L + R.
        /// </summary>
        Center_Left_Right = 0x05,

        /// <summary>
        /// 3 channels, L + R + S.
        /// </summary>
        Left_Right_Surround = 0x06,

        /// <summary>
        /// 4 channels, C + L + R + S.
        /// </summary>
        Center_Left_Right_Surround = 0x07,

        /// <summary>
        /// 4 channels, L + R + SL + SR.
        /// </summary>
        Left_Right_SurroundLeft_SurroundRight = 0x08,

        /// <summary>
        /// 5 channels, C + L + R + SL + SR.
        /// </summary>
        Center_Left_Right_SurroundLeft_SurroundRight = 0x09,

        /// <summary>
        /// 6 channels, CL + CR + L + R + SL + SR.
        /// </summary>
        CenterLeft_CenterRight_Left_Right_SurroundLeft_SurroundRight = 0x0A,

        /// <summary>
        /// 6 channels, C + L + R + LR + RR + OV.
        /// </summary>
        Center_Left_Right_LeftRight_RightRight_Overhead = 0x0B,

        /// <summary>
        /// 6 channels, CF + CR + LF + RF + LR + RR.
        /// </summary>
        CenterFront_CenterRear_LeftFront_RightFront_LeftRear_RightRear = 0x0C,

        /// <summary>
        /// 7 channels, CL + C + CR + L + R + SL + SR.
        /// </summary>
        CenterLeft_Center_CenterRight_Left_Right_SurroundLeft_SurroundRight = 0x0D,

        /// <summary>
        /// 8 channels, CL + CR + L + R + SL1 + SL2 + SR2 + SR2.
        /// </summary>
        CenterLeft_CenterRight_Left_Right_SurroundLeft1_SurroundLeft2_SurroundRight1_SurroundRight2 = 0x0E,

        /// <summary>
        /// 8 channels, CL + C + CR + L + R + SL + S + SR.
        /// </summary>
        CenterLeft_Center_CenterRight_Left_Right_SurroundLeft_Surround_SurroundRight = 0x0F,
    }
}
