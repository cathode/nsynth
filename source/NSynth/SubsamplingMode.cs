/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth
{
    /// <summary>
    /// Represents modes of pixel subsampling.
    /// </summary>
    /// <remarks>
    /// In traditional video context, "chroma subsampling" is generally attributed to the YCbCr color spaces.
    /// </remarks>
    /// <seealso cref="http://en.wikipedia.org/wiki/Chroma_subsampling"/>
    public enum SubsamplingMode
    {
        J420,
        J422,
        J444,
    }
}
