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
                header.ImageDescriptor = TGAImageDescriptor.BottomLeft;
                var bmp = tga.Bitmap as BitmapRGB24;
                //tga.UseRunLengthEncoding = false;
                if (tga.UseRunLengthEncoding)
                {
                    header.ImageType = TGAImageType.RunLengthEncodedTrueColor;
                    var buffer = new byte[bmp.Size.Elements * 4];
                    var pix = bmp.Pixels;
                    int n = -1;
                    var line = new ColorRGB24[tga.Width];

                    // Operate on each scanline.
                    for (int s = tga.Height - 1; s >= 0; --s)
                    {
                        // Copy pixels from source image into scanline buffer.
                        Array.Copy(pix, s * tga.Width, line, 0, line.Length);

                        int remaining = line.Length;
                        int idx = 0;
                        while (remaining > 0)
                        {
                            // Record the offset of where the packet header will be,
                            // n is incremented so that the pixel is written to the correct offset.
                            var basis = ++n;
                            // Get the first pixel of the packet.
                            var p = line[idx];
                            // c is the number of pixels we counted. There will always be at least 1.
                            var c = 1;
                            bool rle = false;

                            // Only go into a loop if there's more than one pixel left on the scanline.
                            if (remaining > 1)
                            {
                                // pn holds the next pixel to compare, as we loop.
                                var pn = line[idx + 1];
                                // Even if there is more than 128 pixels remaining,
                                // we don't loop more times than that (actually, one less, since pn is the first
                                // pixel beyond the packet pixel.)
                                var iMax = idx + Math.Min(remaining, 127);
                                if (p == pn)
                                {
                                    rle = true;
                                    // Write out the first pixel of the packet header.
                                    buffer[++n] = p.Blue;
                                    buffer[++n] = p.Green;
                                    buffer[++n] = p.Red;
                                    // We can use 'i' as a direct index into 'line'.
                                    for (int i = idx; i < iMax - 1; ++i)
                                        if (line[i] == line[i + 1])
                                            ++c;
                                        else
                                            break;
                                }
                                else
                                {
                                    rle = false;
                                    bool last = true;
                                    pn = line[idx];
                                    c = 0;
                                    for (int i = idx + 1; i < iMax; ++i)
                                    {
                                        if (line[i] != pn)
                                        {
                                            ++c;
                                            buffer[++n] = pn.Blue;
                                            buffer[++n] = pn.Green;
                                            buffer[++n] = pn.Red;
                                            pn = line[i];
                                        }
                                        else
                                        {
                                            last = false;
                                            break;
                                        }
                                    }
                                    if (last)
                                    {
                                        buffer[++n] = pn.Blue;
                                        buffer[++n] = pn.Green;
                                        buffer[++n] = pn.Red;
                                    }
                                }
                            }

                            // Write out the packet header.
                            // We save c as 1 less since a packet with 0 pixels is never written (what's the point?).
                            // Allows a maximum of 128 for the repetition count.
                            buffer[basis] = (byte)((rle ? 0x80 : 0x00) | (c - 1));

                            idx += c;
                            remaining -= c;
                        }
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
