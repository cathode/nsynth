/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using System.IO;
using zlib;

namespace NSynth.Imaging.PNG
{
    /// <summary>
    /// Provides a decoder for PNG (Portable Network Graphics) bitmap images.
    /// </summary>
    public sealed class PNGDecoder : ImageDecoder
    {
        #region Properties
        /// <summary>
        /// Gets the codec for the current decoder.
        /// </summary>
        public override Codec Codec
        {
            get
            {
                return Codecs.PNG;
            }
        }
        #endregion
        #region Methods
        public int CalculateCRC(byte[] data, int startIndex, int length)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decodes the next frame from the bitstream.
        /// </summary>
        /// <returns></returns>
        public override Frame Decode()
        {
            var frame = new Frame();
            this.Decode(frame);
            return frame;
        }

        public override void Decode(Frame output)
        {
            int width = 0, height = 0;
            byte depth = 0;
            PNGColorType colorType = PNGColorType.TruecolorWithAlpha;
            Frame result = output;

            // TODO: Verify signature

            // Pull the PNG into a data buffer.
            if (this.Bitstream == null || this.Bitstream.Length < 1)
                return;

            var bytes = new byte[this.Bitstream.Length];
            this.Bitstream.Read(bytes, 0, bytes.Length);
            var buf = new DataBuffer(bytes, ByteOrder.BigEndian);

            var signature = buf.ReadInt64();
            if (signature != PNGCodec.BitstreamSignature)
            {
            }

            bool ihdrDone = false;
            //bool iendDone = false;
            using (var pixelStream = new MemoryStream())
            {
                var zout = new ZOutputStream(pixelStream);

                // Start reading chunks.
                while (buf.Available > 0)
                {
                    int length = buf.ReadInt32();
                    string chunk = string.Concat((char)buf.ReadByte(), (char)buf.ReadByte(), (char)buf.ReadByte(), (char)buf.ReadByte());

                    switch (chunk)
                    {
                        case "IHDR":
                            if (ihdrDone)
                                throw new NotImplementedException();
                            else
                                ihdrDone = true;

                            if (length != 13)
                                throw new NotImplementedException();

                            width = buf.ReadInt32();
                            height = buf.ReadInt32();
                            depth = buf.ReadByte();
                            colorType = (PNGColorType)buf.ReadByte();
                            byte xmethod = buf.ReadByte();
                            PNGFilterMethod filterMethod = (PNGFilterMethod)buf.ReadByte();
                            byte interlaceMethod = buf.ReadByte();

                            break;

                        case "IDAT":
                            var data = buf.ReadBytes(length);
                            zout.Write(data, 0, data.Length);
                            break;

                        default:
                            Console.WriteLine("Skipping unknown chunk \"{0}\" in PNG bitstream at offset {1}", chunk, (buf.Position - 8).ToString("X"));
                            buf.Position += (length > buf.Available) ? buf.Available : length;
                            break;
                    }
                    int crc32 = buf.ReadInt32();
                }

                if (depth == 8)
                {
                    if (colorType == PNGColorType.TruecolorWithAlpha)
                    {
                        //var pd = new byte[width * height * 4];
                        var pd = new byte[pixelStream.Length];
                        pixelStream.Position = 0;
                        pixelStream.Read(pd, 0, pd.Length);

                        ColorRGB32[] pix = new ColorRGB32[width * height];
                        ColorRGB32 p = new ColorRGB32();

                        //File.WriteAllBytes("dump.bin", pd);

                        for (int i = 0, n = 0; i < pix.Length; i++)
                        {
                            if (i % width == 0)
                                n++;

                            p.Red = pd[n++];
                            p.Green = pd[n++];
                            p.Blue = pd[n++];
                            p.Alpha = pd[n++];
                            pix[i] = p;
                        }

                        result.Video[0] = new BitmapRGB32(width, height, pix);
                    }
                    else if (colorType == PNGColorType.Truecolor)
                    {
                        //var pd = new byte[width * height * 3];
                        var pd = new byte[pixelStream.Length];
                        pixelStream.Position = 0;
                        pixelStream.Read(pd, 0, pd.Length);
                        ColorRGB24[] pix = new ColorRGB24[width * height];
                        ColorRGB24 p = new ColorRGB24();

                        //File.WriteAllBytes("dump.bin", pd);

                        for (int i = 0, n = 0; i < pix.Length; i++)
                        {
                            if (i % width == 0)
                                n++;

                            p.Red = pd[n++];
                            p.Green = pd[n++];
                            p.Blue = pd[n++];
                            pix[i] = p;
                        }

                        result.Video[0] = new BitmapRGB24(width, height, pix);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
        #endregion
    }
}
