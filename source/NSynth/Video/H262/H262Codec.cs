﻿/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NSynth.Video.H262
{
    public sealed class H262Codec : VideoCodec
    {
        public override bool SupportsInterlacing
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxBitDepth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxFrameWidth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxFrameHeight
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override SampleRate MaxFrameRate
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanDecode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanEncode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool SupportsFrameAccurateSeeking
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool SupportsNonLinearAccess
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Version Version
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MediaEncoder CreateEncoder(Stream output)
        {
            throw new NotSupportedException();
        }

        public override MediaDecoder CreateDecoder(Stream input)
        {
            throw new NotImplementedException();
        }

        public override int MaxThreads
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
