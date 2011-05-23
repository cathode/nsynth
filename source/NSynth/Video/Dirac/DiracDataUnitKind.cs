/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Video.Dirac
{
    public enum DiracDataUnitKind
    {
        SequenceHeader,
        Picture,
        Auxiliary,
        Padding,
    }
}
