using System;
using System.Collections.Generic;

using System.Text;

namespace NSynth.Filters.Internal.Video
{
    [Flags]
    public enum FlipDirection
    {
        None = 0x0,
        Horizontal = 0x1,
        Vertical = 0x2,
    }
}
