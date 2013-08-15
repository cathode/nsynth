using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    public class VideoMediaHeaderBox : FullBox
    {
        public VideoMediaHeaderBox()
            : base(BoxTypes.VideoMediaHeader, 0)
        {
        }
    }
}
