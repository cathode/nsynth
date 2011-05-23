/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */
using System.Collections.Generic;
using System.Text;

namespace NSynth.Audio.DTS
{
    public enum DTSLowFrequencyEffectsFlag
    {
        NotPresent = 0,
        Present128InterpolationFactor = 1,
        Present64InterpolationFactor = 2,
    }
}
