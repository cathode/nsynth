/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth
{
    /// <summary>
    /// Provides a filter that produces frames.
    /// </summary>
    public abstract class SourceFilter : Filter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceFilter"/> class.
        /// </summary>
        protected SourceFilter()
        {

        }
    }
}
