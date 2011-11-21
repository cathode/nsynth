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
            path = @"c:\nsynth\capture\frames\chaostheory{0:d6}.tga";
            Console.Write("Frame count: ");
            var count = 6376;//int.Parse(Console.ReadLine());
            var start = 0;
            var src = new TGASourceFilter(path);
            src.FrameCount = count;
            //if (count > 1)
            src.MultiFrame = true;

            var outpath = @"c:\nsynth\capture\rgb24\chaostheory_post{0:d6}.tga";
            var end = start + count;
            for (int i = start; i < end; ++i)
            {
                var frame = src.Render(i);
                var bitmap = frame.Video[0] as BitmapRGB32;
                var ymax = bitmap.Height;
                var xmax = bitmap.Width;
                var bmp = new BitmapRGB24(bitmap.Size);

                for (int y = 0; y < ymax; ++y)
                {
                    for (int x = 0; x < xmax; ++x)
                    {
                        var px = bitmap[x, y];
                        bmp[x, y] = new ColorRGB24(px.Red, px.Green, px.Blue);
                    }
                }
                var tga = new TGAImage(bmp);
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
