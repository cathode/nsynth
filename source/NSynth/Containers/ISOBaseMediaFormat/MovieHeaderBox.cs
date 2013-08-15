using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    [BoxType(BoxTypes.MovieHeader)]
    public class MovieHeaderBox : Box
    {
        public MovieHeaderBox()
            : base(BoxTypes.MovieHeader)
        {
        }
    }
}
