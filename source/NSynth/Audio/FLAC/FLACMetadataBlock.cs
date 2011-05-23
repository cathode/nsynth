/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */
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
