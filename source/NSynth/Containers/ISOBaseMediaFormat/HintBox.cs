using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    //[BoxType(BoxTypes.Hint)]
    public class HintBox : Box
    {
        public HintBox()
            : base(BoxTypes.HintMediaHeader)
        {

        }
    }
}
