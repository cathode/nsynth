/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;

namespace NSynth.Imaging.PNG
{
    public sealed class PNGCodec : ImageCodec
    {
        #region Fields
        public const long BitstreamSignature = 137 << 56 | 80 << 48 | 78 << 40 | 71 << 32 | 13 << 24 | 10 << 16 | 26 << 8 | 10;
        #endregion
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

        public override bool SupportsLayers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MediaEncoder CreateEncoder()
        {
            throw new NotImplementedException();
        }

        public override MediaDecoder CreateDecoder()
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
