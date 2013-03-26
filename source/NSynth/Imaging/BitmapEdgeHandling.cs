using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Imaging
{
    /// <summary>
    /// Enumerates supported methods of dealing with off-bitmap pixel coordinates.
    /// </summary>
    public enum BitmapEdgeHandling
    {
        Transparent,
        Zeroed,
        NearestPixel,
        MirrorAcrossEdge,
        WrapAcrossBitmap,
    }
}
