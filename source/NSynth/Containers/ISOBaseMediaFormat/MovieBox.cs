using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    [BoxType(BoxTypes.Movie)]
    public class MovieBox : Box
    {
        public MovieBox()
            : base(BoxTypes.Movie)
        {

        }
    }
}
