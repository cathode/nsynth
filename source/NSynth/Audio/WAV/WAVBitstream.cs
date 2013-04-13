/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

using System;

namespace NSynth.Audio.WAV
{
    /// <summary>
    /// Represents a Microsoft WAV audio bitstream.
    /// </summary>
    public sealed class WAVBitstream : AudioBitstream
    {
        /* Source: https://ccrma.stanford.edu/courses/422/projects/WaveFormat/
        The canonical WAVE format starts with the RIFF header:

        0         4   ChunkID          Contains the letters "RIFF" in ASCII form
                                       (0x52494646 big-endian form).
        4         4   ChunkSize        36 + SubChunk2Size, or more precisely:
                                       4 + (8 + SubChunk1Size) + (8 + SubChunk2Size)
                                       This is the size of the rest of the chunk 
                                       following this number.  This is the size of the 
                                       entire file in bytes minus 8 bytes for the
                                       two fields not included in this count:
                                       ChunkID and ChunkSize.
        8         4   Format           Contains the letters "WAVE"
                                       (0x57415645 big-endian form).

        The "WAVE" format consists of two subchunks: "fmt " and "data":
        The "fmt " subchunk describes the sound data's format:

        12        4   Subchunk1ID      Contains the letters "fmt "
                                       (0x666d7420 big-endian form).
        16        4   Subchunk1Size    16 for PCM.  This is the size of the
                                       rest of the Subchunk which follows this number.
        20        2   AudioFormat      PCM = 1 (i.e. Linear quantization)
                                       Values other than 1 indicate some 
                                       form of compression.
        22        2   NumChannels      Mono = 1, Stereo = 2, etc.
        24        4   SampleRate       8000, 44100, etc.
        28        4   ByteRate         == SampleRate * NumChannels * BitsPerSample/8
        32        2   BlockAlign       == NumChannels * BitsPerSample/8
                                       The number of bytes for one sample including
                                       all channels. I wonder what happens when
                                       this number isn't an integer?
        34        2   BitsPerSample    8 bits = 8, 16 bits = 16, etc.
                  2   ExtraParamSize   if PCM, then doesn't exist
                  X   ExtraParams      space for extra parameters

        The "data" subchunk contains the size of the data and the actual sound:

        36        4   Subchunk2ID      Contains the letters "data"
                                       (0x64617461 big-endian form).
        40        4   Subchunk2Size    == NumSamples * NumChannels * BitsPerSample/8
                                       This is the number of bytes in the data.
                                       You can also think of this as the size
                                       of the read of the subchunk following this 
                                       number.
        44        *   Data             The actual sound data.
         */

        #region Fields
        private WAVBitstreamHeader header;
        #endregion
        #region Properties
        public WAVBitstreamHeader Header
        {
            get
            {
                return this.header;
            }
        }
        #endregion
        #region Methods

        
        public override Segment Decode()
        {
            throw new NotImplementedException();
        }

        public override Segment Decode(long startIndex, long count)
        {
            throw new NotImplementedException();
        }
        public override Frame DecodeFrame(long frameIndex)
        {
            throw new NotImplementedException();
        }
        public override void Encode(Segment segment)
        {
            throw new NotImplementedException();
        }

        public override Codec Codec
        {
            get
            {
                return AudioCodec.WAV;
            }
        }

        protected override bool InitializeDecoding()
        {
            if (this.BaseStream.Length < 44)
                throw new NotImplementedException();

            this.header = new WAVBitstreamHeader();
            byte[] buffer = new byte[12];

            this.BaseStream.Read(buffer, 0, 12);
            char[] chunkID = new char[4] { (char)buffer[0x0], (char)buffer[0x1], (char)buffer[0x2], (char)buffer[0x3] }; // big-endian ChunkID ("RIFF" in ASCII)
            int chunkSize = (int)(buffer[0x4] | buffer[0x5] << 8 | buffer[0x6] << 16 | buffer[0x7] << 24); // little-endian ChunkSize
            char[] format = new char[4] { (char)buffer[0x8], (char)buffer[0x9], (char)buffer[0xA], (char)buffer[0xB] }; // big-endian Format ("WAVE" in ASCII)

            this.BaseStream.Read(buffer, 12, 12);
            char[] subchunk1ID = new char[4] { (char)buffer[0x0], (char)buffer[0x1], (char)buffer[0x2], (char)buffer[0x3] }; // big-endian Subchunk1ID ("fmt " in ASCII)
            int subchunk1Size = (int)(buffer[0x4] | buffer[0x5] << 8 | buffer[0x6] << 16 | buffer[0x7] << 24); // little-endian Subchunk1Size

            this.BaseStream.Read(buffer, 24, 12);

            return false;
        }

        protected override bool InitializeEncoding()
        {
            throw new NotImplementedException();
        }

        protected override bool FinalizeDecoding()
        {
            throw new NotImplementedException();
        }

        protected override bool FinalizeEncoding()
        {
            throw new NotImplementedException();
        }
        #endregion

        protected override void DoReset()
        {
            throw new NotImplementedException();
        }
    }
}
