/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Imaging.JPEG
{
    public class JPEGCodec : ImageCodec
    {
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

        public override MediaEncoder CreateEncoder(System.IO.Stream output)
        {
            throw new NotImplementedException();
        }

        public override MediaDecoder CreateDecoder(System.IO.Stream input)
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
