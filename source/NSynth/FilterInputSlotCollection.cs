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
    /// Provides a collection of filter inputs.
    /// </summary>
    public sealed class FilterInputSlotCollection
    {
        #region Fields
        private readonly Filter owner;
        private readonly Dictionary<string, FilterInputSlot> items;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterInputSlotCollection"/> class.
        /// </summary>
        /// <param name="owner"></param>
        internal FilterInputSlotCollection(Filter owner)
        {
            Contract.Requires(owner != null);

            this.owner = owner;
            this.items = new Dictionary<string, FilterInputSlot>();
        }
        #endregion
        #region Indexers
        /// <summary>
        /// Gets the input slot with the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public FilterInputSlot this[string name]
        {
            get
            {
                return this.items[name];
            }
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the default filter input slot.
        /// </summary>
        public FilterInputSlot Default
        {
            get
            {
                if (!this.items.ContainsKey(FilterInputSlot.DefaultName))
                    this.AddSlot(FilterInputSlot.DefaultName);

                return this[FilterInputSlot.DefaultName];
            }
        }
        #endregion
        #region Methods
        internal void AddSlot(string name)
        {
            Contract.Requires(name != null);

            if (!items.ContainsKey(name))
                this.items.Add(name, new FilterInputSlot(name));
        }
        internal void RemoveSlot(string name)
        {
            this.items.Remove(name);
        }
        #endregion
    }
}
