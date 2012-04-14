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
    /// <summary>
    /// Provides a script action that removes frames from the beginning and/or end of it's input.
    /// </summary>
    public class TrimFilter : ProcessFilterBase
    {
        public override Clip GetClip()
        {
            throw new NotImplementedException();
        }

        protected override Frame RenderFrame(long frameIndex)
        {
            throw new NotImplementedException();
        }
    }
}
