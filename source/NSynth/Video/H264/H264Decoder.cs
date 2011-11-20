// -----------------------------------------------------------------------
// <copyright file="H264Decoder.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace NSynth.Video.H264
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class H264Decoder : VideoDecoder
    {
        public override Codec Codec
        {
            get
            {
                return Codecs.H264;
            }
        }

        public override Frame Decode()
        {
            throw new NotImplementedException();
        }
    }
}
