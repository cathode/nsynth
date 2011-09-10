/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;

namespace NSynth.Imaging.TGA
{
    /// <summary>
    /// Provides a bitstream encoder for the Truevision TARGA (TGA) image file format.
    /// </summary>
    public sealed class TGAEncoder : ImageEncoder
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TGAEncoder"/> class.
        /// </summary>
        /// <param name="bitstream">The stream that the encoded data will be written to.</param>
        public TGAEncoder(Stream bitstream)
            : base(bitstream)
        {
            if (this.Bitstream == null || !this.Bitstream.CanSeek || !this.Bitstream.CanWrite)
                throw new NotImplementedException();
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the codec of the current <see cref="MediaEncoder"/>.
        /// </summary>
        public override Codec Codec
        {
            get
            {
                return Codecs.TGA;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Prepares the stream for encoding.
        /// </summary>
        /// <returns></returns>
        public override bool Open()
        {
            // Assemble buffer
            var buffer = new byte[18];

            // No "Image ID" field
            buffer[0x00] = 0;

            buffer[0x01] = (byte)TGAColorMapType.None;
            buffer[0x02] = (byte)TGAImageType.UncompressedTrueColor;

            // No color map specification
            buffer[0x03] = 0;
            buffer[0x04] = 0;
            buffer[0x05] = 0;
            buffer[0x06] = 0;
            buffer[0x07] = 0;

            // Image X-origin/Y-origin are obsolete/unused.
            buffer[0x08] = 0;
            buffer[0x09] = 0;
            buffer[0x0A] = 0;
            buffer[0x0B] = 0;

            // Image width/height. Reserved for Close.
            buffer[0x0C] = 0;
            buffer[0x0D] = 0;
            buffer[0x0E] = 0;
            buffer[0x0F] = 0;

            // Pixel depth (bits per pixel). Reserved for close.
            buffer[0x10] = 0;

            // Image descriptor. Reserved for close.
            buffer[0x11] = 0;

            this.Bitstream.Seek(0, System.IO.SeekOrigin.Begin);
            this.Bitstream.Write(buffer, 0, 18);
            this.Bitstream.Flush();

            return true;
        }

        public override bool Close()
        {
            throw new NotImplementedException();
        }

        public override void EncodeImage(Image image)
        {
            this.Bitstream.Seek(18, System.IO.SeekOrigin.Begin);

            var tga = image as TGAImage ?? new TGAImage(image.Bitmap);

            if (tga.Bitmap is BitmapRGB24)
            {
                throw new NotImplementedException();
            }
            else if (tga.Bitmap is BitmapRGB32)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        #endregion

    }
}
