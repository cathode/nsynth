/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 *****************************************************************************/

namespace NSynth.Filters
{
    /// <summary>
    /// Provides shared functionality to filters which operate on an input filter to produce an output.
    /// </summary>
    public abstract class ProcessFilterBase : Filter
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Input"/> property.
        /// </summary>
        private Filter input;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessFilterBase"/>
        /// class.
        /// </summary>
        protected ProcessFilterBase()
        {
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="Filter"/> which provides frames
        /// as the input for the current <see cref="ProcessFilterBase"/>.
        /// </summary>
        [FilterParameter("Input")]
        public Filter Input
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
        public override Media.Clip GetClip()
        {
            return this.Input.GetClip();
        }
        #endregion
    }
}
