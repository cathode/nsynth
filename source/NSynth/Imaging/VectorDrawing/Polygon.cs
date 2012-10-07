using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Imaging.VectorDrawing
{
    public class Polygon : IVectorComponent
    {
        public Polygon(params Pointf[] vertices)
        {

        }

        public Rectangle GetBoundingBox()
        {
            throw new NotImplementedException();
        }

        public void DrawStencilMask(BitmapG32 target)
        {
            throw new NotImplementedException();
        }
    }
}
