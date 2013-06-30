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
    /// Provides a base filter type that applies an effect to frames coming from another filter.
    /// </summary>
    public abstract class EffectFilter : Filter
    {
        #region Fields
        #endregion
        #region Constructors
        protected EffectFilter()
        {
            this.Inputs.AddSlot("source");
            this.Inputs.AddSlot("mask");
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the <see cref="FilterInputSlot"/> for the primary input of the effect filter.
        /// </summary>
        public FilterInputSlot Source
        {
            get
            {
                return this.Inputs["source"];
            }
        }
        public FilterInputSlot Mask
        {
            get
            {
                return this.Inputs["mask"];
            }
        }
        #endregion

        protected override void OnClipInitializing(FilterInitializationEventArgs e)
        {
            base.OnClipInitializing(e);

            if (this.Source.Filter != null)
                this.Clip = this.Source.Filter.Clip;
            else
                this.Clip = new Clip();

        }
    }
}
