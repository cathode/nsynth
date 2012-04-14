/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
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
    /// Provides a base filter type that applies an effect to frames coming from another filter.
    /// </summary>
    public abstract class EffectFilter : SourceFilter
    {
        #region Fields
        #endregion
        #region Constructors
        protected EffectFilter()
        {
            
        }
        #endregion
        #region Properties
       
        #endregion
    }
}
