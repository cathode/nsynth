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
        public float X;
        public float Y;
        #endregion
        #region Constructors
        public Pointf(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        #endregion
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
    }
}
