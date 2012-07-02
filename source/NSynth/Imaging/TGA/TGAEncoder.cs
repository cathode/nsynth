/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;
using System.Collections.Generic;

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

        public unsafe override void EncodeImage(Image image)
        {
            this.Open();
            this.Bitstream.Seek(TGABitstreamHeader.Length, System.IO.SeekOrigin.Begin);

            var tga = image as TGAImage;

            if (tga == null)
                throw new NotImplementedException();

            var header = this.context.Header;
            header.Width = (ushort)tga.Width;
            header.Height = (ushort)tga.Height;

            // Temporarily force RLE off until RLE is implemented properly.
            tga.UseRunLengthEncoding = false;

            var bitmap = tga.Flatten();

            if (bitmap is BitmapRGB24)
            {
                header.BitsPerPixel = 24;
                header.AttributeBits = 0;
                header.ImageDescriptor = TGAImageDescriptor.BottomLeft;
                var bmp = bitmap as BitmapRGB24;

                if (tga.UseRunLengthEncoding)
                {
                    throw new NotImplementedException();
                    header.ImageType = TGAImageType.RunLengthEncodedTrueColor;
                    var buffer = new byte[(bmp.Size.Elements * 4)];
                    var pix = bmp.Pixels;
                    int n = 0;
                    var line = new ColorRGB24[tga.Width];

                    // Operate on each scanline.
                    for (int s = tga.Height - 1; s >= 0; --s)
                    {
                        // Copy pixels from source image into scanline buffer.
                        Array.Copy(pix, s * tga.Width, line, 0, line.Length);

                        int idx = 0;
                        int start = 0;

                    BeginPacket:
                        if (idx >= line.Length)
                            goto EndLine;
                        else
                        {
                            start = idx;

                            if (line[idx] == line[idx + 1])
                                goto NextPixelRLE;
                        }

                    NextPixelRLE:
                        if (line[idx] == line[++idx])
                            idx = 0;

                    EndLine:
                        continue;
                    }
                    this.Bitstream.Write(buffer, 0, ++n);
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
            else if (bitmap is BitmapRGB32)
            {
                var bmp = bitmap as BitmapRGB32;


                if (tga.UseRunLengthEncoding)
                    throw new NotImplementedException();
                else
                {
                    header.ImageType = TGAImageType.UncompressedTrueColor;

                    var buffer = new byte[bmp.Size.Elements * 4];
                    var pix = bmp.Pixels;

                    ColorRGB32 p;
                    for (int i = 0, n = -1; i < pix.Length; ++i)
                    {
                        p = pix[i];
                        buffer[++n] = p.Blue;
                        buffer[++n] = p.Green;
                        buffer[++n] = p.Red;
                        buffer[++n] = p.Alpha;
                    }
                }
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
        #region Types
        internal class TgaPacketRGB24
        {
            internal bool IsRle;
            internal int Basis;
            internal int RepetitionCount;
            internal readonly List<ColorRGB24> Pixels = new List<ColorRGB24>();
            internal TgaPacketRGB24(int basis)
            {
                this.Basis = basis;
            }
        }
        #endregion
    }
}
