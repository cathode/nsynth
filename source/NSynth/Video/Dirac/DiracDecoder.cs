/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;

namespace NSynth.Video.Dirac
{
    /// <summary>
    /// Provides a <see cref="MediaDecoder"/> implementation that decodes frames from a Dirac bitstream.
    /// </summary>
    public sealed class DiracDecoder : VideoDecoder
    {
        #region Fields
        //private DiracDecoderState state;
        //private List<DiracSequence> sequences;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DiracDecoder"/> class.
        /// </summary>
        public DiracDecoder()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DiracDecoder"/> class.
        /// </summary>
        /// <param name="source"></param>
        public DiracDecoder(Stream source)
        {
            this.Bitstream = source;
        }
        #endregion
        #region Properties
        public override Codec Codec
        {
            get
            {
                return Codecs.Dirac;
            }
        }
        #endregion
        #region Methods
        public override bool Initialize()
        {
            if (this.Bitstream == null)
                return false;

            this.Bitstream.Seek(0, SeekOrigin.Begin);

            long sequenceOffset = this.Synchronize();

            while (sequenceOffset >= 0)
            {
                Console.WriteLine("DiracSequence found at {0:X8}", sequenceOffset);
                sequenceOffset = this.Synchronize();
            }


            return true;
        }


        public override Frame Decode()
        {
            this.Synchronize();

            throw new NotImplementedException();
        }

        private DiracSequence ReadSequence()
        {
            DiracSequence sequence = new DiracSequence();

            return sequence;
        }

        private DiracParseInfoHeader ReadParseInfoHeader()
        {
            byte[] buffer = new byte[13];
            long position = this.Bitstream.Position;
            if (this.Bitstream.Read(buffer, 0, buffer.Length) < 13)
                throw new Exception();

            int n = 0;
            return new DiracParseInfoHeader()
            {
                //AbsolutePosition = position,
                //Prefix = (int)(buffer[n++] << 24 | buffer[n++] << 16 | buffer[n++] << 8 | buffer[n++]),
                Code = (DiracParseCode)buffer[n++],
                NextOffset = (uint)(buffer[n++] << 24 | buffer[n++] << 16 | buffer[n++] << 8 | buffer[n++]),
                PreviousOffset = (uint)(buffer[n++] << 24 | buffer[n++] << 16 | buffer[n++] << 8 | buffer[n++]),
            };
        }
        private DiracSequenceHeader ReadSequenceHeader()
        {
            return new DiracSequenceHeader();
        }

        /// <summary>
        /// Synchronizes the decoder with the bitstream by seeking to the next 32-bit synchronization word that is found in the stream.
        /// </summary>
        private long Synchronize()
        {
            int syncWord = int.MaxValue;

            while (this.Bitstream.Position < this.Bitstream.Length)
            {
                syncWord = (syncWord << 8) | this.Bitstream.ReadByte();
                if (syncWord == DiracCodec.ParseInfoPrefix)
                    return this.Bitstream.Position;
            }
            return -1;
        }
        #endregion
    }
}
