/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved. */
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Video.Dirac
{
    /// <summary>
    /// Represents a state variable used when encoding or decoding a <see cref="DiracSequence"/> to/from a <see cref="DiracBitstream"/>.
    /// </summary>
    public class DiracState
    {
        public int ParseInfoPrefix;
        public DiracParseCode ParseCode;
        public int NextParseOffset;
        public int PreviousParseOffset;
        public int VersionMajor;
        public int VersionMinor;
        public int Profile;
        public int Level;
    }
}
