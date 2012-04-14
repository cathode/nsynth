/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;
using NSynth.Filters;

namespace NSynth
{
    /// <summary>
    /// Represents a organized collection of actions.
    /// </summary>
    public class Script
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Root"/> property.
        /// </summary>
        private Filter root;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Script"/> class.
        /// </summary>
        public Script()
        {
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the top-level <see cref="Filter"/> for the current <see cref="Script"/>.
        /// </summary>
        public Filter Root
        {
            get
            {
                return this.root;
            }
            set
            {
                this.root = value;
            }
        }
        #endregion
        #region Methods
        #endregion
    }
}
