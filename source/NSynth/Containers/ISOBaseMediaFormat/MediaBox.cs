using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    [BoxType(BoxTypes.Media)]
    public class MediaBox : Box
    {
        public MediaBox()
            : base(BoxTypes.Media)
        {
        }
    }
}
