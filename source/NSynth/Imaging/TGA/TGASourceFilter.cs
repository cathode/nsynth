/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;

namespace NSynth.Imaging.TGA
{
    /// <summary>
    /// Decodes bitmap image data from a Truevision TARGA bitstream.
    /// </summary>
    public sealed class TGASourceFilter : ImageSourceFilter
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TGASourceFilter"/> class.
        /// </summary>
        public TGASourceFilter()
        {
        }
        #endregion
        #region Properties
        public override Codec Codec
        {
            get
            {
                return Codecs.TGA;
            }
        }
        #endregion
        #region Methods
        public override Frame Render(long frameIndex)
        {
            Frame frame = null;

            using (var stream = this.OpenStreamForFrame(frameIndex))
            {
                if (stream != null)
                {
                    var dc = new TGADecodeContext(stream);
                    
                    this.DecodeBitmap(dc);
                    frame = this.Clip.NewFrame();
                    frame.Video[0] = dc.DecodedBitmap;
                }
            }

            return frame;
        }
        /*
        public unsafe override Image DecodeImage()
        {
            if (!this.IsInitialized)
                if (!this.Open())
                    throw new Exception();

           
        }
        */

        protected override void OnInitializing(FilterInitializationEventArgs e)
        {
            base.OnInitializing(e);

            // Assign the bitstream to the stream of the first frame (or the only frame if not multi-frame mode).
            this.Bitstream = this.OpenStreamForFrame(0);

            // Decode header of first frame.
            var dc = new TGADecodeContext(this.Bitstream);
            this.DecodeHeader(dc);

            // The clip configuration is based on the first frame.
            // Subsequent frames (TGA files) with different attributes will cause unexpected results.
            this.Clip = new Clip(
                new Video.VideoTrack()
                {
                    Width = dc.Header.Width,
                    Height = dc.Header.Height,
                    Format = (dc.Header.BitsPerPixel == 24) ? ColorFormat.RGB24 : ColorFormat.RGB32,
                    FrameRate = new SampleRate(1),
                    SampleCount = this.FrameCount,
                    SamplesPerFrame = 1,
                });

            e.Succeeded = true;
        }

        private void InitContext(TGADecodeContext dc)
        {
            dc.Stage = TGADecodeStage.Initialized;
        }

        private void DecodeHeader(TGADecodeContext dc)
        {
            if (dc.Stage < TGADecodeStage.Initialized)
                this.InitContext(dc);

            DataBuffer buffer = new DataBuffer(18, ByteOrder.LittleEndian);
            dc.Bitstream.Seek(0, SeekOrigin.Begin);
            dc.Bitstream.Read(buffer.Contents, 0, 18);

            TGABitstreamHeader header;
            header.IdLength = buffer.ReadByte();
            header.ColorMapType = (TGAColorMapType)buffer.ReadByte();
            header.ImageType = (TGAImageType)buffer.ReadByte();
            header.ColorMapOrigin = buffer.ReadUInt16();
            header.ColorMapLength = buffer.ReadUInt16();
            header.ColorMapDepth = buffer.ReadByte();
            header.XOrigin = buffer.ReadUInt16();
            header.YOrigin = buffer.ReadUInt16();
            header.Width = buffer.ReadUInt16();
            header.Height = buffer.ReadUInt16();
            header.BitsPerPixel = buffer.ReadByte();
            header.ImageDescriptor = (TGAImageDescriptor)buffer.ReadByte();

            if (header.Validate())
                dc.Header = header;
            else
                throw new NotImplementedException();

            dc.PixelDataLength = dc.Bitstream.Length - 18;
            dc.PixelDataOffset = 18;

            dc.Stage = TGADecodeStage.HeaderDecoded;
        }

        private void DecodeFooter(TGADecodeContext dc)
        {
            if (dc.Stage < TGADecodeStage.HeaderDecoded)
                this.DecodeHeader(dc);

            dc.Stage = TGADecodeStage.FooterDecoded;
        }

        private void DecodeBitmap(TGADecodeContext dc)
        {
            if (dc.Stage < TGADecodeStage.FooterDecoded)
                this.DecodeFooter(dc);

            var header = dc.Header;

            // Syntax sugar
            int w = dc.Header.Width;
            int h = dc.Header.Height;

            if (w < 1 || h < 1)
                throw new NotImplementedException();

            if (header.BitsPerPixel % 8 != 0)
                throw new NotImplementedException("BitsPerPixel not multiple of 8");
            // Number of bytes per scanline
            int stride = header.Width * (header.BitsPerPixel / 8);

            // Read all the bytes that contain pixel data
            var data = new byte[dc.PixelDataLength];
            this.Bitstream.Seek(dc.PixelDataOffset, SeekOrigin.Begin);
            this.Bitstream.Read(data, 0, data.Length);

            if (header.ColorMapType == TGAColorMapType.ColorMapped) // Read color map data
                throw new NotImplementedException();
            else if (header.ImageType == TGAImageType.UncompressedTrueColor)
            {
                if (header.BitsPerPixel == 16)
                    throw new NotImplementedException(); // TODO: Implement support for 16-bit TGA decoding.
                else if (header.BitsPerPixel == 24)
                {
                    // Create an array of all the pixels in the bitmap (width x height).
                    var pixels = new ColorRGB24[w * h];
                    // ...and assign it to the Bitmap that will eventually be returned.
                    dc.DecodedBitmap = new BitmapRGB24(w, h, pixels);

                    var n = 0;

                    if (dc.PixelOrder == TGAPixelOrder.BottomLeft)
                    {
                        var line = new ColorRGB24[w];
                        for (int y = h; y > 0; y--)
                        {
                            for (int x = 0; x < line.Length; x++)
                            {
                                line[x].Blue = data[n++];
                                line[x].Green = data[n++];
                                line[x].Red = data[n++];
                            }
                            line.CopyTo(pixels, (y - 1) * line.Length);
                        }

                    }
                    else if (dc.PixelOrder == TGAPixelOrder.BottomRight)
                    {
                        var line = new ColorRGB24[w];

                        // BTT + Right-to-Left (RTL) pixel order.
                        for (int y = h; y > 0; y--)
                        {
                            // Iterate over the pixels in the scanline from right-to-left.
                            for (int x = line.Length - 1; x >= 0; x--)
                            {
                                line[x].Blue = data[n++];
                                line[x].Green = data[n++];
                                line[x].Red = data[n++];
                            }
                            line.CopyTo(pixels, (y - 1) * line.Length);
                        }
                    }

                    else if (dc.PixelOrder == TGAPixelOrder.TopLeft)
                    {
                        // Top-to-bottom (TTB) + LTR pixel order.
                        for (int i = 0; i < pixels.Length; i++)
                        {
                            // All pixels can be decoded in one pass; TTB + LTR is the way bitmaps are laid out in memory.
                            pixels[i].Blue = data[n++];
                            pixels[i].Green = data[n++];
                            pixels[i].Red = data[n++];
                        }
                    }
                    else if (dc.PixelOrder == TGAPixelOrder.TopRight)
                    {
                        var line = new ColorRGB24[w];

                        for (int y = 0; y < h; y++)
                        {
                            for (int x = line.Length - 1; x >= 0; x--)
                            {
                                line[x].Blue = data[n++];
                                line[x].Green = data[n++];
                                line[x].Red = data[n++];
                            }
                            line.CopyTo(pixels, y * line.Length);
                        }
                    }
                    else
                        throw new NotImplementedException();
                }
                else if (header.BitsPerPixel == 32) // Same as above, plus alpha channel.
                {
                    // Create an array of all the pixels in the bitmap (width x height).
                    var pixels = new ColorRGB32[w * h];
                    // ...and assign it to the Bitmap that will eventually be returned.
                    dc.DecodedBitmap = new BitmapRGB32(w, h, pixels);

                    int n = 0;

                    // Most common scanline direction first; TGA stores scanlines bottom-to-top by default.
                    if (dc.PixelOrder == TGAPixelOrder.BottomLeft)
                    {
                        var line = new ColorRGB32[w];
                        // Bottom-to-top (BTT) + Left-to-right (LTR) pixel order.
                        for (int y = h; y > 0; y--)
                        {
                            for (int x = 0; x < line.Length; x++)
                            {
                                line[x].Blue = data[n++];
                                line[x].Green = data[n++];
                                line[x].Red = data[n++];
                                line[x].Alpha = data[n++];
                            }
                            line.CopyTo(pixels, (y - 1) * line.Length);
                        }
                    }
                    else if (dc.PixelOrder == TGAPixelOrder.BottomRight)
                    {
                        var line = new ColorRGB32[w];
                        for (int y = h; y > 0; y--)
                        {
                            // Iterate over the pixels in the scanline from right-to-left.
                            for (int x = line.Length - 1; x >= 0; x--)
                            {
                                line[x].Blue = data[n++];
                                line[x].Green = data[n++];
                                line[x].Red = data[n++];
                                line[x].Alpha = data[n++];
                            }
                            line.CopyTo(pixels, (y - 1) * line.Length);
                        }
                    }
                    else if (dc.PixelOrder == TGAPixelOrder.TopLeft)
                    {
                        for (int i = 0; i < pixels.Length; i++)
                        {
                            // All pixels can be decoded in one pass; TTB + LTR is the way bitmaps are laid out in memory.
                            pixels[i].Blue = data[n++];
                            pixels[i].Green = data[n++];
                            pixels[i].Red = data[n++];
                            pixels[i].Alpha = data[n++];
                        }
                    }
                    else if (dc.PixelOrder == TGAPixelOrder.TopRight)
                    {
                        var line = new ColorRGB32[w];

                        for (int y = 0; y < h; y++)
                        {
                            for (int x = line.Length - 1; x >= 0; x--)
                            {
                                line[x].Blue = data[n++];
                                line[x].Green = data[n++];
                                line[x].Red = data[n++];
                                line[x].Alpha = data[n++];
                            }
                            line.CopyTo(pixels, y * line.Length);
                        }
                    }
                }
            }
            else if (header.ImageType == TGAImageType.RunLengthEncodedTrueColor)
            {
                int n = 0;
                bool raw = false;
                byte p;

                if (header.BitsPerPixel == 16)
                    throw new NotImplementedException();
                if (header.BitsPerPixel == 24)
                {
                    // Create an array of all the pixels in the bitmap (width x height).
                    var pixels = new ColorRGB24[w * h];
                    // ...and assign it to the Bitmap that will eventually be returned.
                    dc.DecodedBitmap = new BitmapRGB24(w, h, pixels);
                    ColorRGB24 px = new ColorRGB24();
                    // Operate on a line-by-line basis; RLE packets will never wrap from one scanline to another.
                    var line = new ColorRGB24[w];
                    for (int y = h; y > 0; y--)
                    {
                        for (int x = 0, e = 0; x < line.Length; x++, e--)
                        {
                            if (e == 0)
                            {
                                // Read the "packet header"
                                p = data[n++];
                                // Highest bit of packet header indicates RLE (1) or RAW (0).
                                raw = (p & 0x80) != 0x80;
                                // Remaining 7 bits indicate RLE packet length.
                                e = 1 + (p & 0x7F);

                                // Read color
                                px.Blue = data[n++];
                                px.Green = data[n++];
                                px.Red = data[n++];
                            }
                            else if (raw)
                            {
                                px.Blue = data[n++];
                                px.Green = data[n++];
                                px.Red = data[n++];
                            }

                            //line[(this.rightToLeft ? line.Length - x - 1 : x)] = px;
                        }
                        // Scanlines can be stored top-to-bottom or bottom-to-top.
                        //line.CopyTo(pixels, (this.topToBottom ? h - y : y - 1) * w);
                    }
                }
                else if (header.BitsPerPixel == 32) // Just like above, but with an alpha channel.
                {
                    // Create an array of all the pixels in the bitmap (width x height).
                    var pixels = new ColorRGB32[w * h];
                    // ...and assign it to the Bitmap that will eventually be returned.
                    dc.DecodedBitmap = new BitmapRGB32(w, h, pixels);
                    ColorRGB32 px = new ColorRGB32();
                    // Operate on a line-by-line basis; RLE packets will never wrap from one scanline to another.
                    var line = new ColorRGB32[w];
                    for (int y = h; y > 0; y--)
                    {
                        for (int x = 0, e = 0; x < line.Length; x++, e--)
                        {
                            if (e == 0)
                            {
                                // Read the "packet header"
                                p = data[n++];
                                // Highest bit of packet header indicates RLE (1) or RAW (0).
                                raw = (p & 0x80) != 0x80;
                                // Remaining 7 bits indicate RLE packet length.
                                e = 1 + (p & 0x7F);

                                // Read color
                                px.Blue = data[n++];
                                px.Green = data[n++];
                                px.Red = data[n++];
                                px.Alpha = data[n++];
                            }
                            else if (raw)
                            {
                                px.Blue = data[n++];
                                px.Green = data[n++];
                                px.Red = data[n++];
                                px.Alpha = data[n++];
                            }

                            //line[(this.rightToLeft ? line.Length - x - 1 : x)] = px;
                        }
                        // Scanlines can be stored top-to-bottom or bottom-to-top.
                        //line.CopyTo(pixels, (this.topToBottom ? h - y : y - 1) * w);
                    }
                }
                else
                    throw new NotImplementedException();
            }
            //return image;

            dc.Stage = TGADecodeStage.BitmapDecoded;
        }
        #endregion
    }
}
