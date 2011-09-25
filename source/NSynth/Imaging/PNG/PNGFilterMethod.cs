using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging.PNG
{
    public enum PNGFilterMethod
    {
        None = 0,
        Sub = 1,
        Up = 2,
        Average = 3,
        Paeth = 4,
    }
}
