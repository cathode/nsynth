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
    /// Reads primitive types with variable bit lengths from a buffer.
    /// </summary>
    public sealed class BitDecoder
    {
        #region Properties
        private int Offset
        {
            get;
            set;
        }
        public byte[] Buffer
        {
            get;
            set;
        }
        #endregion
        #region Methods

        #endregion
    }
}
