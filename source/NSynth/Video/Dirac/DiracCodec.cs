/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;

namespace NSynth.Video.Dirac
{
    /// <summary>
    /// Provides support for the royalty-free Dirac video compression codec.
    /// </summary>
    public class DiracCodec : VideoCodec
    {
        #region Fields
        /// <summary>
        /// Holds the Dirac stream synchronization code.
        /// </summary>
        public const int ParseInfoPrefix = 'B' << 24 | 'B' << 16 | 'C' << 8 | 'D';
        #endregion
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
                return false;
            }
        }

        public override Version Version
        {
            get
            {
                return new Version(2, 0);
            }
        }

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
        public override bool SupportsInterlacing
        {
            get
            {
                return true;
            }
        }

        public override int MaxBitDepth
        {
            get
            {
                return -1;
            }
        }

        public override int MaxFrameWidth
        {
            get
            {
                return -1;
            }
        }

        public override int MaxFrameHeight
        {
            get
            {
                return -1;
            }
        }

        public override SampleRate MaxFrameRate
        {
            get
            {
                return new SampleRate(60, 1.0);
            }
        }

        public override int MaxThreads
        {
            get
            {
                return 1;
            }
        }
        #endregion
        #region Methods
        public override MediaEncoder CreateEncoder(Stream output)
        {
            return new DiracEncoder(output);
        }

        public override MediaDecoder CreateDecoder(Stream input)
        {
            return new DiracDecoder(input);
        }
        #endregion
    }
}
