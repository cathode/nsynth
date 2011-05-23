/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
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
    public class PerlinNoiseSourceFilter : SourceFilter
    {
        #region Fields

        #endregion
        #region Constructors
        public PerlinNoiseSourceFilter()
        {
            this.Seed = 0;
            this.ColorA = new ColorRGB(0.0f, 0.0f, 0.0f, 1.0f);
            this.ColorB = new ColorRGB(1.0f, 1.0f, 1.0f, 1.0f);
        }
        #endregion
        #region Properties
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
        public override Frame Render(long frameIndex)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
