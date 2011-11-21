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
        #region Fields
        private TGAEncodeContext context;
        #endregion
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
            this.context = new TGAEncodeContext();
            this.context.Header = new TGABitstreamHeader();

            this.WriteHeader(this.context.Header);

            return true;
        }

        public override bool Close()
        {
            this.WriteHeader(this.context.Header);

            return true;
        }

        public override void EncodeImage(Image image)
        {
            this.Open();
            this.Bitstream.Seek(18, System.IO.SeekOrigin.Begin);

            var tga = image as TGAImage ?? new TGAImage(image.Bitmap);
            var header = this.context.Header;
            header.Width = (ushort)tga.Width;
            header.Height = (ushort)tga.Height;

            if (tga.Bitmap is BitmapRGB24)
            {
                header.BitsPerPixel = 24;
                header.AttributeBits = 0;
                header.ImageDescriptor = TGAImageDescriptor.TopLeft;
                var bmp = tga.Bitmap as BitmapRGB24;
                tga.UseRunLengthEncoding = false;
                if (tga.UseRunLengthEncoding)
                {
                    header.ImageType = TGAImageType.RunLengthEncodedTrueColor;
                    var buffer = new byte[bmp.Size.Elements * 4];
                    var pix = bmp.Pixels;
                    int n = -1;
                    var line = new ColorRGB24[tga.Width];

                    // Operate on each scanline.
                    for (int s = 0; s < tga.Height; ++s)
                    {
                        // Copy pixels from source image into scanline buffer.
                        Array.Copy(pix, s * tga.Width, line, 0, line.Length);

                        int rle = 0;
                        int raw = 0;

                        // Record the offset of where the packet header will be
                        var packetOffset = ++n;
                        for (int i = 1; i < line.Length; ++i)
                        {
                            var current = line[i];
                            var prev = line[i - 1];

                            
                        }
                    }
                    this.Bitstream.Write(buffer, 0, n);
                }
                else
                {
                    header.ImageType = TGAImageType.UncompressedTrueColor;

                    var buffer = new byte[bmp.Size.Elements * 3];
                    var pix = bmp.Pixels;
                    for (int i = 0, n = -1; i < pix.Length; ++i)
                    {
                        buffer[++n] = pix[i].Blue;
                        buffer[++n] = pix[i].Green;
                        buffer[++n] = pix[i].Red;
                    }
                    this.Bitstream.Write(buffer, 0, buffer.Length);
                }
            }
            else if (tga.Bitmap is BitmapRGB32)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
            this.context.Header = header;
            this.Close();
        }

        private void WriteHeader(TGABitstreamHeader header)
        {
            var buffer = header.ToByteArray();

            this.Bitstream.Seek(0, System.IO.SeekOrigin.Begin);
            this.Bitstream.Write(buffer, 0, buffer.Length);
            this.Bitstream.Flush();
        }
        #endregion

    }
}
