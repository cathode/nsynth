﻿/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Video.H264
{
    public sealed class H264SourceFilter : SourceFilter
    {
        #region Fields

        #endregion
        #region Methods
        
        protected override void OnClipInitializing(FilterInitializationEventArgs e)
        {
            base.OnClipInitializing(e);

            if (e is H264SourceFilterInitializationEventArgs)
            {

            }
            else
                throw new NotImplementedException();
        }

        #endregion
    }
}
