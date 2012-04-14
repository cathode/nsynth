/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;

namespace NSynth.Imaging.TIFF
{
    /// <summary>
    /// Provides an imaging codec for encoding and decoding Tagged Image File Format bitstreams.
    /// </summary>
    public sealed partial class TIFFCodec : ImageCodec
    {
        #region Fields

        /// <summary>
        /// Holds the value of the byte order mark that indicates big-endian encoding in a TIFF bitstream.
        /// </summary>
        public const int BigEndianMark = 0x4D4D;

        /// <summary>
        /// Holds the value of the byte order mark that indicates little-endian encoding in a TIFF bitstream.
        /// </summary>
        public const int LittleEndianMark = 0x4949;

        /// <summary>
        /// Holds the special identifier mark which follows the byte order mark in a TIFF bitstream.
        /// </summary>
        public const ushort IdentifierMark = 42;

        #endregion
        #region Properties

        /// <summary>
        /// Overridden. Returns true, indicating that decoding image data from a TIFF bitstream is supported.
        /// </summary>
        public override bool CanDecode
        {
            get
            {
                return false; // TODO: Implement support for decoding TIFF images.
            }
        }

        /// <summary>
        /// Overridden. Returns true, indicating that encoding image data as a TIFF bitstream is supported.
        /// </summary>
        public override bool CanEncode
        {
            get
            {
                return false; // TODO: Implement support for encoding TIFF images.
            }
        }

        /// <summary>
        /// Overridden. Returns the version of TIFF supported.
        /// </summary>
        public override Version Version
        {
            get
            {
                return new Version(6, 0); // TIFF 6.0 specification
            }
        }

        #endregion
        #region Methods


        #endregion

        public override bool SupportsFrameAccurateSeeking
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool SupportsNonLinearAccess
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MediaEncoder CreateEncoder(System.IO.Stream output)
        {
            throw new NotImplementedException();
        }

        public override MediaDecoder CreateDecoder(System.IO.Stream input)
        {
            throw new NotImplementedException();
        }

        public override bool SupportsLayers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Image CreateImage(int width, int height)
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
