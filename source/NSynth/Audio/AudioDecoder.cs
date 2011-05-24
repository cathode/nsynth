/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NSynth.Audio
{
    public abstract class AudioDecoder : MediaDecoder
    {
        #region Constructors
        protected AudioDecoder()
        {
        }
        protected AudioDecoder(Stream bitstream)
            : base(bitstream)
        {
        }
        #endregion
    }
}
