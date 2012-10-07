using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Imaging
{
    public class BitmapG32 : Bitmap<ColorG32>
    {
        public BitmapG32(Size size)
            : base(size)
        {
        }
        public override ColorFormat Format
        {
            get { return ColorFormat.G32; }
        }
    }
}
