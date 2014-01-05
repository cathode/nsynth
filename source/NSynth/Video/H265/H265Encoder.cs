/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2014 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NSynth.Video.H265
{
    /// <summary>
    /// Implements a video encoder that encodes frames 
    /// </summary>
    public class H265Encoder : VideoEncoder
    {
        public H265Encoder(Stream bitstream)
            : base(bitstream)
        {

        }

        public override Codec Codec
        {
            get { throw new NotImplementedException(); }
        }

        public override void EncodeFrame(Frame frame)
        {
            throw new NotImplementedException();
        }

        public override bool Open()
        {
            throw new NotImplementedException();
        }

        public override bool Close()
        {
            throw new NotImplementedException();
        }
    }
}
