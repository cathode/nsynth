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
using NSynth.Imaging;

namespace NSynth.Filters.Video
{
    /// <summary>
    /// Provides a frame source filter that generates video frames containing a perlin noise pattern.
    /// </summary>
    public class PerlinNoiseSourceFilter : SourceFilter
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PerlinNoiseSourceFilter"/> class.
        /// </summary>
        public PerlinNoiseSourceFilter()
        {
            this.Seed = 0;
            this.ColorA = new ColorRGB(0.0f, 0.0f, 0.0f, 1.0f);
            this.ColorB = new ColorRGB(1.0f, 1.0f, 1.0f, 1.0f);
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the seed used for the random generation of the noise pattern.
        /// </summary>
        public int Seed
        {
            get;
            set;
        }

        public ColorRGB ColorA
        {
            get;
            set;
        }
        public ColorRGB ColorB
        {
            get;
            set;
        }
        public Size Dimensions
        {
            get;
            set;
        }
        #endregion
        #region Methods
      
        #endregion
    }
}
