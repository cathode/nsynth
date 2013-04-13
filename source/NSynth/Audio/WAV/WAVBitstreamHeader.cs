/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace NSynth.Audio.WAV
{
    /// <summary>
    /// Header of a Microsoft WAVE format audio file.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct WAVBitstreamHeader
    {
        #region Fields
        public const int CorrectChunkID = 'R' | 'I' << 8 | 'F' << 16 | 'F' << 24;
        public const int CorrectFormat = 'W' | 'A' << 8 | 'V' << 16 | 'E' << 24;
        public const int CorrectSubchunk1ID = 'f' | 'm' << 8 | 't' << 16 | ' ' << 24;
        public const int CorrectSubchunk2ID = 'd' | 'a' << 8 | 't' << 16 | 'a' << 24;
        [FieldOffset(0)]
        public int ChunkID;
        [FieldOffset(4)]
        public int ChunkSize;
        [FieldOffset(8)]
        public int Format;
        [FieldOffset(12)]
        public int Subchunk1ID;
        [FieldOffset(16)]
        public int Subchunk1Size;
        [FieldOffset(20)]
        public WAVAudioFormat AudioFormat;
        [FieldOffset(22)]
        public ushort NumChannels;
        [FieldOffset(24)]
        public int SampleRate;
        [FieldOffset(28)]
        public int ByteRate;
        [FieldOffset(32)]
        public ushort BlockAlign;
        [FieldOffset(34)]
        public ushort BitsPerSample;
        [FieldOffset(36)]
        public int Subchunk2ID;
        [FieldOffset(40)]
        public int Subchunk2Size;
        #endregion
    }
}
