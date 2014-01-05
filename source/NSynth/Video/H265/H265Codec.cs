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

namespace NSynth.Video.H265
{
    public class H265Codec : VideoCodec
    {
        public override bool SupportsInterlacing
        {
            get { throw new NotImplementedException(); }
        }

        public override int MaxBitDepth
        {
            get { throw new NotImplementedException(); }
        }

        public override int MaxFrameWidth
        {
            get { throw new NotImplementedException(); }
        }

        public override int MaxFrameHeight
        {
            get { throw new NotImplementedException(); }
        }

        public override SampleRate MaxFrameRate
        {
            get { throw new NotImplementedException(); }
        }

        public override bool CanDecode
        {
            get { throw new NotImplementedException(); }
        }

        public override bool CanEncode
        {
            get { throw new NotImplementedException(); }
        }

        public override int MaxThreads
        {
            get { throw new NotImplementedException(); }
        }

        public override bool SupportsFrameAccurateSeeking
        {
            get { throw new NotImplementedException(); }
        }

        public override bool SupportsNonLinearAccess
        {
            get { throw new NotImplementedException(); }
        }

        public override Version Version
        {
            get { throw new NotImplementedException(); }
        }

        public override MediaEncoder CreateEncoder(System.IO.Stream output)
        {
            throw new NotImplementedException();
        }

        public override MediaDecoder CreateDecoder(System.IO.Stream input)
        {
            throw new NotImplementedException();
        }
    }
}
