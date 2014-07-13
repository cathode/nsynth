using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.AVI
{
    public class AVICodec : ContainerCodec
    {
        public override bool CanDecode
        {
            get { return true; }
        }

        public override bool CanEncode
        {
            get { return false; }
        }

        public override bool SupportsFrameAccurateSeeking
        {
            get { return true; }
        }

        public override bool SupportsNonLinearAccess
        {
            get { return true; }
        }

        public override Version Version
        {
            get { return new Version(1, 0); }
        }

        public override MediaDecoder CreateDecoder()
        {
            return new AVIDecoder();
        }
        public override MediaEncoder CreateEncoder()
        {
            return new AVIEncoder();
        }
    }
}
