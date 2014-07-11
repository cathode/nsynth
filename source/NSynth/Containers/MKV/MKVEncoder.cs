using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.MKV
{
    public class MKVEncoder : ContainerEncoder
    {
        public override Codec Codec
        {
            get { throw new NotImplementedException(); }
        }

        public override void EncodeFrame(Frame frame)
        {
            throw new NotImplementedException();
        }
    }
}
