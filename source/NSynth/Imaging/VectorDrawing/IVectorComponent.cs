using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Imaging.VectorDrawing
{
    /// <summary>
    /// Provides an interface for parts that make up vector images.
    /// </summary>
    public interface IVectorComponent
    {
        /// <summary>
        /// When implemented in a derived class, generates a rectangle that fully encloses the vector component.
        /// </summary>
        /// <returns></returns>
        Rectangle GetBoundingBox();

        /// <summary>
        /// Generates a stencil mask that indicates the area which is occupied by the vector component.
        /// </summary>
        /// <param name="target"></param>
        void DrawStencilMask(BitmapG32 target);
    }
}
