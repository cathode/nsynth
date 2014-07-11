using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.AVI
{
    public class AVIDecoder : ContainerDecoder
    {
        public override Codec Codec
        {
            get { return Codecs.AVI; }
        }

        protected override void OnOpen(EventArgs e)
        {
            base.OnOpen(e);


        }
    }
}
