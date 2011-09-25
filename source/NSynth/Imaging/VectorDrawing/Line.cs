using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging.VectorDrawing
{
    public class Line : ILine
    {
        public Pointf Start;
        public Pointf End;

        public Pointf Sample(float t)
        {
            throw new NotImplementedException();
        }
    }
}
