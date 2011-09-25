using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging.VectorDrawing
{
    public interface ILine
    {
        Pointf Sample(float t);
    }
}
