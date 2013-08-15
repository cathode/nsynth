using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    [BoxType(BoxTypes.TrackReference)]
    public class TrackReferenceBox : Box
    {
        public TrackReferenceBox()
            : base(BoxTypes.TrackReference)
        {
           
        }

        public uint[] TrackIds { get; set; }
    }
}
