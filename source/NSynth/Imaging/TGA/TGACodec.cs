/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;
using System.IO;

namespace NSynth.Imaging.TGA
{
    /// <summary>
    /// Provides an image codec for encoding and decoding Truevision Graphics Adapter bitstreams.
    /// </summary>
    public class TGACodec : ImageCodec
    {
        #region Properties
        /// <summary>
        /// Gets a value indicating whether the current <see cref="NSynth.Codecs.Codec"/>
        /// supports decoding of bitstreams.
        /// </summary>
        public override bool CanDecode
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="NSynth.Codecs.Codec"/>
        /// supports encoding of bitstreams.
        /// </summary>
        public override bool CanEncode
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a <see cref="Size"/> indicating the maximum image width and height, in pixels, that is supported by the current <see cref="Codec"/>.
        /// </summary>
        public override Size MaximumSize
        {
            get
            {
                return new Size(65535, 65535);
            }
        }

        /// <summary>
        /// Gets the version of the specification supported by the current <see cref="Codec"/>.
        /// </summary>
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
        #endregion

 

        public override MediaEncoder CreateEncoder(Stream output)
        {
            return new TGAEncoder(output);
        }

        public override MediaDecoder CreateDecoder(Stream input)
        {
            return null;
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
