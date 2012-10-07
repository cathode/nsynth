using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging.VectorDrawing
{
    /// <summary>
    /// A floating-point 2d location.
    /// </summary>
    public struct Pointf
    {
        #region Fields

        public float x;
        public float y;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Pointf"/> class.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Pointf(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the x-component (horizontal) of the current <see cref="Pointf"/>.
        /// </summary>
        public float X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// Gets or sets the y-component (vertical) of the current <see cref="Pointf"/>.
        /// </summary>
        public float Y
        {
            get
            {
                return this.y;
            }
        }
        #endregion
        #region Operators
        public static Pointf operator *(float left, Pointf right)
        {
            return new Pointf(right.X * left, right.Y * left);
        }

        public static Pointf operator *(Pointf left, float right)
        {
            return new Pointf(left.X * right, left.Y * right);
        }

        public static Pointf operator /(Pointf left, float right)
        {
            return new Pointf(left.X / right, left.Y / right);
        }

        public static Pointf operator +(Pointf left, Pointf right)
        {
            return new Pointf(left.X + right.X, left.Y + right.Y);
        }
        #endregion
    }
}
