/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2014 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSynth.Filters;

namespace NSynth.Video.H265
{
    public class H265SourceFilter : SourceFilter
    {
        public H265SourceFilter()
        {

        }

        protected override void DoProcessing(FilterProcessingContext context, Frame outputFrame)
        {
            base.DoProcessing(context, outputFrame);
        }
    }
}
