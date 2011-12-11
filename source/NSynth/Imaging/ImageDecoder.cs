/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
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
    public abstract class ImageDecoder : MediaDecoder
    {
        public static IBitmap DecodeBitmap(string path)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(path));

            using (ImageDecoder decoder = ImageDecoder.CreateByFileExtension(path))
            {
                decoder.Bitstream = File.OpenRead(path);
                decoder.Initialize();

                var frame = decoder.Decode();
                if (frame != null)
                    return frame.Video;
                else
                    return null;
            }
        }
        public static ImageDecoder CreateByFileExtension(string path)
        {
            switch (Path.GetExtension(path).ToLower())
            {
                case ".tga":
                    return new TGA.TGADecoder();

                case ".png":
                    return new PNG.PNGDecoder();

                default:
                    return null;
            }
        }
    }
}
