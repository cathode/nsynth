/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
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
    /// Represents an input to a filter where the data is multimedia frames.
    /// </summary>
    public class FrameInput : FilterInput<Frame>
    {
        #region Fields
        private Filter input;
        #endregion
        #region Constructors
        public FrameInput()
        {
        }
        #endregion
        #region Properties
        public Filter Filter
        {
            get
            {
                return this.input;
            }
            set
            {
                this.input = value;
            }
        }
        #endregion
        #region Methods
        public override Frame GetValue(long frameIndex)
        {
            return (this.input != null) ? this.input.Render(frameIndex) : null;
        }
        #endregion
    }
}
