// -----------------------------------------------------------------------
// <copyright file="IFFCodec.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NSynth
{
    /// <summary>
    /// Codec for Intermediate Frame Format.
    /// </summary>
    public class IFFCodec : Codec
    {
        #region Properties
        public override bool CanDecode
        {
            get
            {
                return true;
            }
        }

        public override bool CanEncode
        {
            get
            {
                return true;
            }
        }

        public override int MaxThreads
        {
            get
            {
                return 1;
            }
        }

        public override bool SupportsFrameAccurateSeeking
        {
            get
            {
                return true;
            }
        }

        public override bool SupportsNonLinearAccess
        {
            get
            {
                return true;
            }
        }

        public override Version Version
        {
            get
            {
                return new Version(1, 0);
            }
        }
        #endregion
        #region Methods
        public override MediaEncoder CreateEncoder(System.IO.Stream output)
        {
            return new IFFEncoder
            {
                Bitstream = output
            };
        }

        public override MediaDecoder CreateDecoder(System.IO.Stream input)
        {
            return new IFFDecoder
            {
                Bitstream = input
            };
        }
        #endregion
    }
}
