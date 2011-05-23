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

namespace NSynth
{
    /// <summary>
    /// Represents a graph of filters, and maintains links between them.
    /// </summary>
    public class FilterGraph
    {
        #region Properties
        public IEnumerable<EffectFilter> Effects
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public IEnumerable<Filter> Filters
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public IEnumerable<SourceFilter> Inputs
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public IEnumerable<OutputFilter> Outputs
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        #region Methods
        public bool Initialize()
        {
            foreach (var f in this.Filters)
                if (!f.Initialize())
                    return false;

            return true;
        }
        public void Render(long frameIndex)
        {
            this.Render(frameIndex, 1);
        }
        public void Render(long startIndex, long count)
        {
            for (long index = startIndex, i = 0; i < count; i++, index++)
            {
                foreach (var input in this.Inputs)
                {
                    
                }
            }
        }
        #endregion
    }
}
