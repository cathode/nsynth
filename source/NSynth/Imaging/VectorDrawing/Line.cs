using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging.VectorDrawing
{
    /// <summary>
    /// Represents a straight line between two points.
    /// </summary>
    public class Line : ILine
    {
        public Pointf Start { get; set; }
        public Pointf End { get; set; }

        #region Methods
        /// <summary>
        /// Performs a linear interpolation along the current line.
        /// </summary>
        /// <param name="t">A value indicating the position along the line, where 0.0 is the starting point and 1.0 is the ending point.</param>
        /// <returns>A new <see cref="Pointf"/> containing the value of the sampled point.</returns>
        public Pointf Sample(float t)
        {
            var x1 = this.Start.X;
            var x2 = this.End.X;
            var y1 = this.Start.Y;
            var y2 = this.End.Y;

            return new Pointf((x1 * t) + (x2 * (1.0f - t)), (y1 * t) + (y2 * (1.0f - t)));
        }
        #endregion

        public float Thickness
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
