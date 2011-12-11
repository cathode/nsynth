/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth
{
    /// <summary>
    /// Implements an encoder for Intermediate Frame Format, a high-speed lossless codec for
    /// persisting or transporting frame data.
    /// </summary>
    public class IFFEncoder : MediaEncoder
    {
        #region Properties
        public override Codec Codec
        {
            get
            {
                return Codecs.IFF;
            }
        }
        #endregion
        #region Methods
        public override void EncodeFrame(Frame frame)
        {

        }

        /// <summary>
        /// Preps the underlying stream for encoding.
        /// </summary>
        /// <returns></returns>
        public override bool Open()
        {
            this.AllocateChunkHeader(0);
            

            return true;
        }

        public override bool Close()
        {
            throw new NotImplementedException();
        }

        private void AllocateChunkHeader(long baseOffset)
        {
            var buffer = new byte[4096]; // 4KiB reserved for stream chunk header.
            this.Bitstream.Seek(baseOffset, System.IO.SeekOrigin.Begin);
            this.Bitstream.Write(buffer, 0, buffer.Length);
        }
        #endregion
    }
}
