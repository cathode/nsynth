using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace NSynth.Imaging
{
    public abstract class Shape : IEnumerable<Point>
    {
        #region Methods
        public abstract bool Contains(Point p);
        public abstract Rectangle GetBoundingBox();

        public abstract IEnumerator<Point> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
