/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */
using System;

namespace NSynth.Filters.Internal.Video
{
    [Flags]
    public enum InvertChannels
    {
        None = 0x0,
        Red = 0x1,
        Green = 0x2,
        Blue = 0x4,
        Alpha = 0x8,
        Luma = 0x16,
        Chroma = 0x32,
        All = 0xFF,
    }
}
