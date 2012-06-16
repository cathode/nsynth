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
            var input = new TGASourceFilter(@"C:\NSynth\source\lost{0:000000}.tga");
            input.MultiFrame = true;
            
            input.Initialize();

            var frames = new Frame[16];

            for (int i = 0; i < frames.Length; ++i)
            {
                frames[i] = input.GetFrame(i);
                //frames[i].Video[0][0, 0] = new ColorRGB24(255, 255, 255);
            }
           
            Console.WriteLine(GC.GetTotalMemory(true));
            Console.ReadLine();
        }
    }
}
