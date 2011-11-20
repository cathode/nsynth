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
using NSynth.Imaging;

namespace NSynth
{
    /// <summary>
    /// Pools frame data to reduce redundant allocation of frames.
    /// </summary>
    public static class FramePool
    {
        private static List<Frame> frames = new List<Frame>();

        public static void Populate(int count)
        {
            Console.WriteLine("pre-populate memory usage: {0}MiB", System.Diagnostics.Process.GetCurrentProcess().PrivateMemorySize64 / 1024.0 / 1024.0);

            var clip = new Clip(new Video.VideoTrack(1920, 1080) { Format = ColorFormat.RGB});
            for (int i = 0; i < count; ++i)
            {
                FramePool.frames.Add(new Frame(clip));
            }

            Console.WriteLine("Populated frame pool with {0} frames", count);
            Console.WriteLine("post-populate memory usage: {0}MiB", System.Diagnostics.Process.GetCurrentProcess().PrivateMemorySize64 / 1024.0 / 1024.0);

        }
        public static Frame ObtainVideoFrame(Size size, ColorFormat format)
        {
            throw new NotImplementedException();
        }
    }
}
