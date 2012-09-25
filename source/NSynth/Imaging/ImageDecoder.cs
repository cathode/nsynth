/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics.Contracts;

namespace NSynth.Imaging
{
    /// <summary>
    /// Provides common functionality to support types that decode static images from bitstreams.
    /// </summary>
    public abstract class ImageDecoder : MediaDecoder
    {
        #region Methods
        public static IBitmap DecodeBitmap(string path)
        {
            Contract.Requires(path != null);
            Contract.Requires(path != string.Empty);

            using (ImageDecoder decoder = ImageDecoder.CreateByFileExtension(path))
            {
                decoder.Bitstream = File.OpenRead(path);
                decoder.Initialize();

                var frame = decoder.Decode();
                if (frame != null)
                    return frame.Video[0];
                else
                    return null;
            }
        }

        /// <summary>
        /// Creates and returns a new <see cref="ImageDecoder"/> suitable for decoding a bitmap from a file with the specified file extension.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ImageDecoder CreateByFileExtension(string path)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(path));

            switch (Path.GetExtension(path).ToLower())
            {
                case ".tga":
                    return new NSynth.Imaging.TGA.TGADecoder();

                case ".png":
                    return new NSynth.Imaging.PNG.PNGDecoder();

                case ".tif":
                case ".tiff":
                    return new NSynth.Imaging.TIFF.TIFFDecoder();

                case ".bmp":
                    return new NSynth.Imaging.BMP.BMPDecoder();

                case ".jpg":
                case ".jpeg":
                    return new NSynth.Imaging.JPEG.JPEGDecoder();

                default:
                    return null;
            }
        }
        #endregion
    }
}
