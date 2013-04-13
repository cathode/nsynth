/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NSynth.Imaging.TGA
{
    public class TGAOutputFilter : ImageOutputFilter
    {
        #region Constructors
        public TGAOutputFilter(string path)
            : base(path)
        {

        }
        #endregion
        #region Methods
        protected override ImageEncoder GetEncoder(Stream bitstream)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
