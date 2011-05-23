/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;

namespace NSynth.Video.Dirac
{
    /// <summary>
    /// Provides a Dirac video encoder implementation.
    /// </summary>
    public sealed class DiracEncoder : VideoEncoder
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DiracEncoder"/> class.
        /// </summary>
        /// <param name="bitstream"></param>
        public DiracEncoder(Stream bitstream) : base(bitstream)
        {
        }
        #endregion
        #region Properties

        /// <summary>
        /// Gets a value indicating whether suspending the encoding process is supported. Returns false.
        /// </summary>
        public override bool CanSuspend
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the <see cref="Codec"/> of the current <see cref="MediaEncoder"/>.
        /// </summary>
        public override Codec Codec
        {
            get
            {
                return Codecs.Dirac;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Encodes the specified frame to the underlying bitstream.
        /// </summary>
        /// <param name="frame">A <see cref="Frame"/> containing video data to encode.</param>
        public override void EncodeFrame(Frame frame)
        {
            throw new NotImplementedException();
        }

        public override bool Open()
        {
            throw new NotImplementedException();
        }

        public override bool Close()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
