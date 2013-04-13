/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;

namespace NSynth.Imaging.BMP
{
    public class BMPCodec : ImageCodec
    {
        public override Size MaximumSize
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

        public override Version Version
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
                throw new System.NotImplementedException();
            }
        }

        public override bool SupportsNonLinearAccess
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override bool SupportsLayers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MediaEncoder CreateEncoder(Stream output)
        {
            throw new NotImplementedException();
        }

        public override MediaDecoder CreateDecoder(Stream input)
        {
            throw new NotImplementedException();
        }

        public override Image CreateImage(int width, int height)
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
