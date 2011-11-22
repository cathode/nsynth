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
            Console.Write("TGA frame path: ");
            var path = Console.ReadLine();
            path = @"c:\nsynth\capture\rgb24\chaostheory_post{0:d6}.tga";
            Console.Write("Frame count: ");
            var count = 1;//int.Parse(Console.ReadLine());
            var start = 1500;
            var src = new TGASourceFilter(path);
            src.FrameCount = count;
            //if (count > 1)
            src.MultiFrame = true;

            var outpath = @"c:\nsynth\capture\rgb24\chaostheory_rle{0:d6}.tga";
            var end = start + count;
            for (int i = start; i < end; ++i)
            {
                var frame = src.Render(i);
                var tga = new TGAImage(frame.Video[0]);
                tga.UseRunLengthEncoding = true;
                var outfile = string.Format(outpath, i);
                System.IO.File.Delete(outfile);
                using (var enc = new TGAEncoder(System.IO.File.Open(outfile, System.IO.FileMode.Create, System.IO.FileAccess.Write)))
                {
                    enc.EncodeImage(tga);
                }
            }
        }
    }
}
