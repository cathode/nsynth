using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSynth.Imaging.TGA;
using NSynth;

namespace NSynthRunner
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var src = new TGASourceFilter("C:\\NSynth\\Capture\\frames\\BinaryFlow_{0:D6}.tga")
            {
                MultiFrame = true,
                FrameCount = 10,
            };
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < src.FrameCount; ++i)
            {
                var frame = src.Render(i);
                Console.WriteLine("Decoded frame {0}", i);
            }
            sw.Stop();
            Console.WriteLine("Decoding took {0}ms", sw.Elapsed.TotalMilliseconds);

            Console.Read();
        }
    }
}
