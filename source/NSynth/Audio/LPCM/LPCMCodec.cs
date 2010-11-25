/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved. */
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Audio.LPCM
{
    public sealed class LPCMCodec : AudioCodec
    {
        public override int MaxChannels
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxDepth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxSampleRate
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

        public override MediaEncoder CreateEncoder(System.IO.Stream output)
        {
            throw new NotImplementedException();
        }

        public override MediaDecoder CreateDecoder(System.IO.Stream input)
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
