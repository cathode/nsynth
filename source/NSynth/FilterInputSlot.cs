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
using System.Diagnostics.Contracts;

namespace NSynth
{
    /// <summary>
    /// Represents an input slot of a filter.
    /// </summary>
    public sealed class FilterInputSlot
    {
        #region Fields
        /// <summary>
        /// Holds the default input slot name.
        /// </summary>
        public const string DefaultName = "default";
        /// <summary>
        /// Backing field for the <see cref="FilterInputSlot.Name"/> property.
        /// </summary>
        private string name;

        /// <summary>
        /// Backing field for the <see cref="FilterInputSlot.Source"/> property.
        /// </summary>
        private IFrameSource source;
        #endregion
        internal FilterInputSlot(string name)
        {
            Contract.Requires(name != null);

            this.name = name;
        }
        #region Properties
        /// <summary>
        /// Gets the name of the input slot.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Filter"/> that is assigned to the
        /// current input slot.
        /// </summary>
        public IFrameSource Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
            }
        }
        #endregion
    }
}
