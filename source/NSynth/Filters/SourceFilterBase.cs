/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using NSynth.Imaging;

namespace NSynth.Filters
{
    /// <summary>
    /// Represents an abstract <see cref="Filter"/> which creates frames
    /// without frames supplied as an input, either using an algorithm or by
    /// reading from an external source.
    /// </summary>
    public abstract class SourceFilterBase : Filter
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceFilterBase"/> class.
        /// </summary>
        protected SourceFilterBase()
        {

        }
        #endregion
        #region Fields
        private decimal framerate;
        private Size size;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the frameRate of the current
        /// <see cref="SourceFilterBase"/>.
        /// </summary>
        public decimal Framerate
        {
            get
            {
                return this.framerate;
            }
            set
            {
                this.framerate = value;
            }
        }
        public Size Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }
        #endregion
    }
}
