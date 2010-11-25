/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NSynth.Imaging.TGA
{
    /// <summary>
    /// Represents state required to decode a TGA image from a bitstream.
    /// </summary>
    public sealed class TGADecodeContext
    {
        #region Fields
        private TGABitstreamHeader header;
        private Stream bitstream;
        private TGADecodeStage stage;
        private IBitmap decodedBitmap;
        #endregion
        #region Constructors
        public TGADecodeContext(Stream bitstream)
        {
            if (bitstream == null)
                throw EX.Create(EXCode.ArgumentNull, "bitstream");

            this.bitstream = bitstream;
            this.header = new TGABitstreamHeader();
        }
        #endregion
        #region Properties
        public Stream Bitstream
        {
            get
            {
                return this.bitstream;
            }
        }

        public IBitmap DecodedBitmap
        {
            get
            {
                return this.decodedBitmap;
            }
            internal set
            {
                this.decodedBitmap = value;
            }
        }

        public TGABitstreamHeader Header
        {
            get
            {
                return this.header;
            }
            internal set
            {
                this.header = value;
            }
        }

        public TGADecodeStage Stage
        {
            get
            {
                return this.stage;
            }
            internal set
            {
                this.stage = value;
            }
        }
        #endregion

        public TGAPixelOrder PixelOrder
        {
            get;
            set;
        }

        public long PixelDataLength
        {
            get;
            set;
        }

        public long PixelDataOffset
        {
            get;
            set;
        }
    }
}
