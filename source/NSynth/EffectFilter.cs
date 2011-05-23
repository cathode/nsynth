/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
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
        private readonly FrameInput effectSource;
        #endregion
        #region Constructors
        protected EffectFilter()
        {
            this.effectSource = new FrameInput();
        }
        #endregion
        #region Properties
        public FrameInput InputFrames
        {
            get
            {
                return this.effectSource;
            }
        }
        #endregion
    }
}
