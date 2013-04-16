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
using System.Diagnostics.Contracts;

namespace NSynth
{
    /// <summary>
    /// Provides a collection of filter inputs.
    /// </summary>
    public sealed class FilterInputSlotCollection : IEnumerable<FilterInputSlot>
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
            Contract.Ensures(this.Owner == owner);

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
                Contract.Requires(!string.IsNullOrEmpty(name));
                Contract.Ensures(Contract.Result<FilterInputSlot>().Owner == this.Owner);

                if (this.items.ContainsKey(name.ToLowerInvariant()))
                    return this.items[name.ToLowerInvariant()];
                else
                    throw new NotImplementedException();
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

        public Filter Owner
        {
            get
            {
                return this.owner;
            }
        }
        #endregion
        #region Methods
        public IEnumerator<FilterInputSlot> GetEnumerator()
        {
            return this.items.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        internal void AddSlot(string name)
        {
            Contract.Requires(name != null);
            Contract.Requires(name != string.Empty);

            if (!items.ContainsKey(name))
                this.items.Add(name, new FilterInputSlot(this.owner, name));
        }
        internal void RemoveSlot(string name)
        {
            Contract.Requires(name != null);

            this.items.Remove(name);
        }

        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(this.items != null);
            Contract.Invariant(this.owner != null);
        }
        #endregion


    }
}
