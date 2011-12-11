// -----------------------------------------------------------------------
// <copyright file="IFFDecoder.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace NSynth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class IFFDecoder : MediaDecoder
    {
        public override Codec Codec
        {
            get
            {
                return Codecs.IFF;
            }
        }

        public override Frame Decode()
        {
            throw new NotImplementedException();
        }
    }
}
