using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace NSynth.Imaging.VectorDrawing
{
    /// <summary>
    /// Implements a Bézier curve.
    /// </summary>
    public class BCurve : ILine
    {
        #region Fields
        private readonly LinkedList<Pointf> points;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BCurve"/> class.
        /// </summary>
        public BCurve()
            : this(default(Pointf))
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BCurve"/> class.
        /// </summary>
        /// <param name="points"></param>
        public BCurve(params Pointf[] points)
        {
            Contract.Requires(points != null);
            this.points = new LinkedList<Pointf>(points);
        }
        #endregion
        #region Indexers
        /// <summary>
        /// Gets the order of the curve which is equivalent to the number of points that define it.
        /// </summary>
        public int Order
        {
            get
            {
                return this.points.Count;
            }
        }
        #endregion
        #region Methods
        public Pointf Sample(float t)
        {
            // Linear interpolation between points P0 and P1
            if (this.Order == 2)
            {
                var p0 = points.First.Value;
                var p1 = points.Last.Value;
                var b = ((1f - t) * p0) + (t * p1);

                return b;
            }

            var pts = this.points;
            var npts = new LinkedList<Pointf>();

            var current = pts.First;
            var next = current.Next;

            // Recursively iterate over the points until we've condensed them to a single point (which is the resulting sample).
            while (pts.Count > 1)
            {
                next = current.Next;
                var p0 = current.Value;
                var p1 = next.Value;
                npts.AddLast(((1f - t) * p0) + (t * p1));
                if (next.Next == null)
                {
                    pts = npts;
                    npts = new LinkedList<Pointf>();

                    current = pts.First;
                }
                else
                    current = next;

            }

            return pts.First.Value;
        }
        public Pointf SampleX(int x)
        {
            return default(Pointf);
        }
        public Pointf SampleY(int y)
        {
            return default(Pointf);
        }
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Order > 0);
        }
        #endregion
    }
}
