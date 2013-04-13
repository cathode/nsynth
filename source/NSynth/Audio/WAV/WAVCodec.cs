/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace NSynth.Audio.WAV
{
    /// <summary>
    /// Provides audio encoding/decoding functionality for Microsoft WAVE format audio files.
    /// </summary>
    public class WAVCodec : AudioCodec
    {
        #region Fields
        #endregion
        #region Methods
        #endregion
        #region Properties

        /// <summary>
        /// Gets a value indicating whether the current <see cref="Codec"/> supports decoding.
        /// </summary>
        public override bool CanDecode
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="Codec"/> supports encoding.
        /// </summary>
        public override bool CanEncode
        {
            get
            {
                return false; //TODO: Implement encoding of WAV bitstreams.
            }
        }

        /// <summary>
        /// Gets the maximum number of sound channels supported by Microsoft WAV bitstreams.
        /// </summary>
        public override int MaxChannels
        {
            get
            {
                return 8;
            }
        }

        /// <summary>
        /// Gets the maximum depth (in bits per sample) supported by Microsoft WAV bitstreams.
        /// </summary>
        public override int MaxDepth
        {
            get
            {
                return 16;
            }
        }

        /// <summary>
        /// Gets the maximum sample rate supported by Microsoft WAVE bitstreams.
        /// </summary>
        public override int MaxSampleRate
        {
            get
            {
                return 48000;
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
            throw new System.NotImplementedException();
        }

        public override MediaDecoder CreateDecoder(Stream input)
        {
            throw new System.NotImplementedException();
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
