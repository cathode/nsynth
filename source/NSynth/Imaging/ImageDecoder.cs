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

namespace NSynth.Imaging
{
    public abstract class ImageDecoder : MediaDecoder
    {
        public static IBitmap DecodeBitmap(string path)
        {
            var ext = Path.GetExtension(path).ToLower();
            ImageDecoder decoder = null;
            switch (ext)
            {
                case ".tga":
                    decoder = new TGA.TGADecoder();
                    break;

                case ".png":
                    decoder = new PNG.PNGDecoder();
                    break;

                default:
                    return null;
            }

            decoder.Bitstream = File.OpenRead(path);
            decoder.Initialize();

            var frame = decoder.Decode();
            if (frame != null)
                return frame.Video[0];
            else
                return null;
        }
    }
}
