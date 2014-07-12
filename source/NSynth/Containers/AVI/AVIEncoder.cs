using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.AVI
{
    public class AVIEncoder : ContainerEncoder
    {
        public override Codec Codec
        {
            get { return Codecs.AVI; }
        }

        public override void EncodeFrame(Frame frame)
        {
            throw new NotImplementedException();
        }
    }
}
