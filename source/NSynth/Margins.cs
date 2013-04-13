/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth
{
    public struct Margins
    {
        #region Properties
        public int Top
        {
            get;
            set;
        }
        public int Bottom
        {
            get;
            set;
        }
        public int Left
        {
            get;
            set;
        }
        public int Right
        {
            get;
            set;
        }
        #endregion
    }
}
