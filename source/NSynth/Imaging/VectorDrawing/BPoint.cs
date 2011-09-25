using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging.VectorDrawing
{
    /// <summary>
    /// Represents a point on a <see cref="BCurve"/> (Bezier Curve).
    /// </summary>
    public class BPoint
    {
        public Pointf Position;
        public Pointf ControlA;
        public Pointf ControlB;
    }
}
