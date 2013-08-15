using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    [BoxType(BoxTypes.EditListContainer)]
    public class EditListContainerBox : Box
    {
        public EditListContainerBox() : base(BoxTypes.EditListContainer)
        {
        }

    }
}
