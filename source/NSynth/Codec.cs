/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;
using System.IO;

namespace NSynth
{
    /// <summary>
    /// Represents a multimedia encoding format, allowing bitstreams in a specific format
    /// to be converted to/from meaningful API objects.
    /// </summary>
    public abstract class Codec
    {
        #region Properties
        /// <summary>
        /// Gets a value indicating whether the current <see cref="NSynth.Codecs.Codec"/>
        /// supports decoding of bitstreams.
        /// </summary>
        public abstract bool CanDecode
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="NSynth.Codecs.Codec"/>
        /// supports encoding of bitstreams.
        /// </summary>
        public abstract bool CanEncode
        {
            get;
        }

        /// <summary>
        /// Gets the maximum supported number of execution threads that can be used for encoding or decoding.
        /// </summary>
        public abstract int MaxThreads
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the current codec supports frame-accurate arbitrary seeking.
        /// </summary>
        public abstract bool SupportsFrameAccurateSeeking
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the current codec supports non-linear access to it's contents.
        /// </summary>
        public abstract bool SupportsNonLinearAccess
        {
            get;
        }

        /// <summary>
        /// Gets the codec specification version supported by the current <see cref="Codec"/> implementation.
        /// </summary>
        public abstract Version Version
        {
            get;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Creates and returns a <see cref="MediaEncoder"/> suitable for encoding to the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="output">The <see cref="Stream"/> to be encoded to.</param>
        /// <returns>A new <see cref="MediaEncoder"/>.</returns>
        public abstract MediaEncoder CreateEncoder(Stream output);

        /// <summary>
        /// Creates and returns a <see cref="MediaEncoder"/> suitable for encoding to the file at the specified path.
        /// </summary>
        /// <param name="outputPath">The path to the file to encode to.</param>
        /// <returns>A new <see cref="MediaEncoder"/>.</returns>
        public virtual MediaEncoder CreateEncoder(string outputPath)
        {
            return this.CreateEncoder(File.OpenWrite(outputPath));
        }

        /// <summary>
        /// Creates and returns a <see cref="MediaDecoder"/> suitable for decoding from the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="input">The <see cref="Stream"/> to be decoded from.</param>
        /// <returns>A new <see cref="MediaDecoder"/> that is initialized and ready to decode frames.</returns>
        public abstract MediaDecoder CreateDecoder(Stream input);

        /// <summary>
        /// Creates and returns a <see cref="MediaDecoder"/> suitable for decoding from the file at the specified path.
        /// </summary>
        /// <param name="inputPath">The path to the file to decode from.</param>
        /// <returns>A new <see cref="MediaDecoder"/> that is initialized and ready to decode frames.</returns>
        public virtual MediaDecoder CreateDecoder(string inputPath)
        {
            return this.CreateDecoder(File.OpenRead(inputPath));
        }
        #endregion
    }
}
