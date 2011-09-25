using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging
{
    public class CompoundShape : Shape
    {
        public Shape Primary
        {
            get;
            set;
        }
        public Shape Secondary
        {
            get;
            set;
        }
        public CompoundAction Action
        {
            get;
            set;
        }

        public override Rectangle GetBoundingBox()
        {
            throw new NotImplementedException();
        }

        public override bool Contains(Point p)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<Point> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public enum CompoundAction
    {
        Union,
        Difference,
        Intersection,
    }
}
