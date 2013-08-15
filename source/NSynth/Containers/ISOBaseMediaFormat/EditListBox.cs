using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    [BoxType(BoxTypes.EditList)]
    public class EditListBox : Box
    {
        public EditListBox()
            : base(BoxTypes.EditList)
        {

        }
    }
}
