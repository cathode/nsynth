/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */
using System;

namespace NSynth.Filters
{
    /// <summary>
    /// Provides the script designer with metadata about a parameter of a <see cref="Filter"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class FilterParameterAttribute : Attribute
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Name"/> property.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Backing field for the <see cref="AllowTweaks"/> property.
        /// </summary>
        private bool allowTweaks = true;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterParameterAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the action parameter.</param>
        public FilterParameterAttribute(string name)
        {
            this.name = name;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether the value of the parameter can be tweaked with a script-wide tweak.
        /// </summary>
        public bool AllowTweaks
        {
            get
            {
                return this.allowTweaks;
            }
            set
            {
                this.allowTweaks = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="FilterParameterKind"/> of the current <see cref="FilterParameterAttribute"/>.
        /// </summary>
        public FilterParameterKind Kind
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets the human-readable name of the parameter.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets or sets the human-readable description of the parameter.
        /// </summary>
        public string Description
        {
            get;
            set;
        }
        #endregion
    }
}
