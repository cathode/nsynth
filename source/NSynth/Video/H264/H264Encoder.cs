﻿/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Video.H264
{
    public class H264Encoder : VideoEncoder
    {
        public H264Encoder(Stream bitstream) : base(bitstream)
        {
        }
        public override bool CanSuspend
        {
            get
            {
                throw new NotImplementedException();
            }
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

        public override Codec Codec
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
