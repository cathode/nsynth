/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace NSynth.Audio.FLAC
{
    /// <summary>
    /// Provides audio encoding/decoding functionality for Free Lossless Audio Codec format audio files.
    /// </summary>
    public class FLACCodec : AudioCodec
    {
        #region Constructors
        public FLACCodec()
        {
        }
        #endregion
        #region Methods

        #endregion
        #region Methods - Public

        #endregion
        #region Properties
        /// <summary>
        /// Overridden. Returns true indicating decoding of a FLAC bitstream to audio sample data is supported.
        /// </summary>
        public override bool CanDecode
        {
            get
            {
                return false; //TODO: Implement support for FLAC decoding.
            }
        }
        /// <summary>
        /// Overridden. Returns true indicating encoding audio sample data to a FLAC bitstream is supported.
        /// </summary>
        public override bool CanEncode
        {
            get
            {
                return false; //TODO: Implement support for FLAC encoding.
            }
        }
        /// <summary>
        /// Overridden. Returns the maximum number of audio channels supported in a single FLAC bitstream.
        /// </summary>
        public override int MaxChannels
        {
            get
            {
                return 8; // reference: http://flac.sourceforge.net/faq.html#general__channels
            }
        }
        /// <summary>
        /// Overridden. Returns the maximum bit depth for audio samples supported by a FLAC bitstream.
        /// </summary>
        public override int MaxDepth
        {
            get
            {
                return 32;
            }
        }
        /// <summary>
        /// Overridden. Returns the maximum sample rate (in samples per second) supported by a FLAC bitstream.
        /// </summary>
        public override int MaxSampleRate
        {
            get
            {
                return 655350;
            }
        }
        /// <summary>
        /// Overridden. Returns the version of the supported FLAC bitstream format.
        /// </summary>
        public override Version Version
        {
            get
            {
                return new Version("1.2.1.0");
            }
        }
        #endregion

        public override bool SupportsFrameAccurateSeeking
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override bool SupportsNonLinearAccess
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override MediaEncoder CreateEncoder(Stream output)
        {
            throw new NotImplementedException();
        }

        public override MediaDecoder CreateDecoder(Stream input)
        {
            throw new NotImplementedException();
        }

        public override int MaxThreads
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
