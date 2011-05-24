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
    /// Represents the header at the beginning of a DTS bitstream.
    /// </summary>
    public struct DTSBitstreamHeader
    {
        public DTSFrameType FrameType; // V, FTYPE, 1 bit
        public byte DeficitSampleCount; // V, SHORT, 5 bits
        public bool CRCPresent; // V, CPF, 1 bit
        public byte PCMSampleBlocks; // V, NBLKS, 7 bits
        public short PrimaryFrameSize; // V, FSIZE, 14 bits
        public DTSAudioChannelArrangement AudioChannelArrangement; // ACC, AMODE, 6 bits
        public DTSCoreAudioSamplingFrequency CoreAudioSamplingFrequency; // ACC, SFREQ, 4 bits
        public DTSTransmissionBitRate TransmissionBitRate; // ACC, RATE, 5 bits
        public bool EmbeddedDownMixEnabled; // V, MIX, 1 bit
        public bool EmbeddedDynamicRangeFlag; // V, DYNF, 1 bit
        public bool EmbeddedTimeStampFlag; // V, TIMEF, 1 bit
        // 48 bits

        public bool AuxiliaryDataFlag; // V, AUXF, 1 bit
        public bool HDCD; // NV, HDCD, 1 bit
        public DTSExtensionAudioDescriptorFlag ExtensionAudioDescriptorFlag; // ACC, EXT_AUDIO_ID, 3 bits
        public bool ExtendedCodingFlag; // ACC, EXT_AUDIO, 1 bit
        public bool AudioSyncWordInsertionFlag; // ACC, ASPF, 1 bit
        public DTSLowFrequencyEffectsFlag LowFrequencyEffectsFlag; // V, LFF, 2 bits
        public bool PredictorHistoryFlagSwitch; // V, HFLAG, 1 bit
        public short HeaderCRCCheckBytes; // V, HCRC, 16 bits
        public bool MultirateInterpolatorSwitch; // NV, FILTS, 1 bit
        public byte EncoderSoftwareRevision; // ACC/NV, VERNUM, 4 bits
        public byte CopyHistory; // NV, CHIST, 2 bits
        public DTSSourcePCMResolution SourcePCMResolution; // ACC/NV, PCMR, 3 bits
        public bool FrontSumDifferenceFlag; // V, SUMF, 1 bit
        public bool SurroundSumDifferenceFlag; // V, SUMS, 1 bit
        
    }
}
