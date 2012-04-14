/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth;

namespace NSynth.Filters.Internal.Video
{
    /// <summary>
    /// Provides a <see cref="ProcessFilterBase"/> that performs a gaussian blurring of it's input frame.
    /// </summary>
    public class GaussianBlur : ProcessFilterBase
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
