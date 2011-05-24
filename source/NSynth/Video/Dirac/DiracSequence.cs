/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Video.Dirac
{
    /// <summary>
    /// Represents a single video sequence with constant video parameters, which can be decoded from a Dirac stream independantly.
    /// </summary>
    public class DiracSequence
    {
        public DiracSequenceHeader Header
        {
            get;
            set;
        }
        public long AbsolutePosition
        {
            get;
            set;
        }
    }
}
