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
        private Filter source;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterInputSlot"/> class.
        /// </summary>
        /// <param name="name"></param>
        internal FilterInputSlot(string name)
        {
            Contract.Requires(name != null);
            Contract.Requires(name != string.Empty);

            this.name = name;
        }
        #endregion
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
        public Filter Source
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

        public bool IsBound
        {
            get
            {
                return this.source != null;
            }
        }

        
        /// <summary>
        /// Gets or sets a value that indicates how many frames before the current frame are necessary to be cached by the filter assigned to this input slot,
        /// if the parent filter operates on multiple frames at once.
        /// </summary>
        public int FramesBefore
        {
            get;
            set;
        }

        public int FramesAfter
        {
            get;
            set;
        }
        #endregion
        #region Methods

        /// <summary>
        /// Binds the input slot to a filter, thereby establishing a link between the specified filter and the filter
        /// to which this input slot belongs.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public bool Bind(Filter filter)
        {
            Contract.Requires(filter != null);

            if (this.source == filter)
                return true;
            else
                this.Unbind();


            //if (!filter.IsInSubtree(this))
            {

            }

            return true;
        }


        /// <summary>
        /// Determines if a specified <see cref="Filter"/> is already bound as part of the subtree of the current input slot.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public bool IsInSubtree(Filter filter)
        {
            Contract.Requires(filter != null);

            if (this.source == null)
                return false; // Nothing to look in.
            else if (this.source == filter)
                return true; // Found!
            else
                foreach (var input in this.source.Inputs)
                    if (input.IsInSubtree(filter))
                        return true; // Found in a subtree

            // Not found
            return false;
        }

        public void Unbind()
        {
            //this.source.
        }
        #endregion
    }
}
