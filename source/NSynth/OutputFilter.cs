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
    /// Provides a filter that consumes frames from another filter, and outputs
    /// them to a non-filter target, such as a file, network socket,
    /// or user interface.
    /// </summary>
    public abstract class OutputFilter : Filter
    {
        #region Fields
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputFilter"/>
        /// </summary>
        protected OutputFilter()
        {

        }
        #endregion
        #region Properties
        #endregion
        #region Methods
        public void Output(ulong index)
        {
            this.RequestFrame(index);
        }

        protected override bool Render(Frame output, ulong index)
        {
            return base.Render(output, index);
        }
        #endregion
    }
}
