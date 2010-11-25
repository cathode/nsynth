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
