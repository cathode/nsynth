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

namespace NSynthRunner
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var input = new TGASourceFilter(@"C:\NSynth\sample.tga");
           
            var tgaout = new TGAOutputFilter();
            tgaout.Inputs.Default.Source = input;

            tgaout.RequestFrame(0);
        }
    }
}
