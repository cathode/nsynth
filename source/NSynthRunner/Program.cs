/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSynth.Imaging.TGA;
using NSynth;
using NSynth.Imaging;
using NSynth.Win32;
using System.Windows.Forms;

namespace NSynthRunner
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var input = new TGASourceFilter(@"P:\nsynth\framedumps\avatar\avatar{0:000000}.tga");
            input.MultiFrame = true;
            input.ImageCount = 70;
            //input.FrameCount = 70000;
            input.InitializeClip();

            var writer = new TGAOutputFilter(@"C:\Temp\nsynth\avatar_out\avatar{0:000000}.tga");
            writer.Source.Bind(input);

            writer.GetFrame(0);
            Console.WriteLine(GC.GetTotalMemory(true));
            Console.ReadLine();
        }
    }
}
