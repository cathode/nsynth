/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth;

namespace NSynth.Filters.Internal
{
    public class TrackMerge : Filter
    {
        #region Methods
        public override Clip GetClip()
        {
            throw new NotImplementedException();
        }

        protected override Frame RenderFrame(long frameIndex)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
