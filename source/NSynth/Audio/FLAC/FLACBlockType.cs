/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved. */
using System.Collections.Generic;

using System.Text;

namespace NSynth.Audio.FLAC
{
    /// <summary>
    /// Represents a FLAC block type.
    /// </summary>
    /// <remarks>
    /// Values between 7 and 126 are reserved, value of 127 or higher is invalid (to avoid confusing with a frame sync code).
    /// </remarks>
    public enum FLACBlockType : byte
    {
        StreamInfo = 0,
        Padding = 1,
        Application = 2,
        SeekTable = 3,
        VorbisComment = 4,
        CueSheet = 5,
        Picture = 6,
    }
}
