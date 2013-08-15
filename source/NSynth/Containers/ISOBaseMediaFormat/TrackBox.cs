using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    [BoxType(BoxTypes.Track)]
    public class TrackBox : Box
    {
        public TrackBox()
            : base(0)
        {

        }
    }
}
