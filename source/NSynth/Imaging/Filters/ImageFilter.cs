using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging.Filters
{
    public class ImageFilter<T> where T : IColor
    {
        public virtual Bitmap<T> Apply(Bitmap<T> source)
        {
            throw new NotImplementedException();
        }
    }
}
