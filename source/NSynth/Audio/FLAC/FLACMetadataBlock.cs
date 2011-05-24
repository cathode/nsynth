/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;

using System.Text;

namespace NSynth.Audio.FLAC
{
    public struct FLACMetadataBlock
    {
        #region Fields - Private
        private FLACMetadataBlockHeader header;
        #endregion
        #region Properties - Public
        public FLACMetadataBlockHeader Header
        {
            get
            {
                return this.header;
            }
            set
            {
                this.header = value;
            }
        }
        #endregion
    }
}
