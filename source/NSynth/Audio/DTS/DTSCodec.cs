using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NSynth.Audio.DTS
{
    /// <summary>
    /// Provides an audio codec that supports decoding of Digital Theater Surround Coherent Acoustics bitstreams.
    /// </summary>
    public class DTSCodec : AudioCodec
    {
        #region Fields
        /// <summary>
        /// Holds the DTS Synchronization word, used by the decoder to synchronize itself if it's decoding should become out of sync with the bitstream.
        /// </summary>
        public const int SyncWord = 0x7FFE8001;
        #endregion
        #region Methods

        #endregion
        #region Properties
        public override bool CanDecode
        {
            get
            {
                return false; //TODO: Implement DTS decoding
            }
        }
        public override bool CanEncode
        {
            get
            {
                return false; //TODO: Implement DTS encoding
            }
        }
        public override int MaxChannels
        {
            get
            {
                return 6;
            }
        }
        public override int MaxDepth
        {
            get
            {
                return 24;
            }
        }
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
                return new Version(0, 0, 0, 0);
            }
        }
        #endregion

        public override bool SupportsFrameAccurateSeeking
        {
            get
            {
                return false;
            }
        }

        public override bool SupportsNonLinearAccess
        {
            get
            {
                return false;
            }
        }

        public override MediaEncoder CreateEncoder(Stream output)
        {
            return new DTSEncoder(output);
        }

        public override MediaDecoder CreateDecoder(Stream input)
        {
            return new DTSDecoder(input);
        }

        public override int MaxThreads
        {
            get
            {
                // No explicit multithreading support yet.
                return 1;
            }
        }
    }
}
