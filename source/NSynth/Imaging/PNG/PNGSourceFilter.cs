using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSynth.Video;

namespace NSynth.Imaging.PNG
{
    public class PNGSourceFilter : ImageSourceFilter
    {
        public PNGSourceFilter(string path)
            : base(path)
        {
        }
        public override Frame Render(long frameIndex)
        {
            using (var stream = this.OpenStreamForFrame(frameIndex))
            {
                /*
                var bmp = new System.Drawing.Bitmap(stream, false);

                Frame frame = new Frame(this.Clip);

                var b32 = new BitmapRGB32(bmp.Size.Width, bmp.Size.Height);
                for (int y = 0; y < b32.Height; y++)
                    for (int x = 0; x < b32.Width; x++)
                    {
                        var bx = bmp.GetPixel(x, y);
                        b32[y, x] = new ColorRGB32(bx.R, bx.G, bx.B, bx.A);
                    }

                frame.Video[0] = b32;

                return frame;
                */
                using (var decoder = new PNGDecoder())
                {
                    decoder.Bitstream = stream;
                    if (!decoder.Initialize())
                        throw new NotImplementedException();

                    return decoder.Decode();
                }
            }
        }
        protected override void OnInitializing(FilterInitializationEventArgs e)
        {
            base.OnInitializing(e);

            using (var stream = this.OpenStreamForFrame(0))
            {
                using (var decoder = new PNGDecoder())
                {
                    decoder.Bitstream = stream;
                    decoder.Initialize();
                    var frame = decoder.Decode();
                    if (frame == null)
                        return;
                    else if (frame.Video.Count > 0)
                    {
                        var bitmap = frame.Video[0];
                        if (bitmap != null)
                        {
                            var track = new VideoTrack();
                            track.SampleCount = this.FrameCount;
                            track.Width = bitmap.Width;
                            track.Height = bitmap.Height;
                            track.Format = bitmap.Format;
                            track.SamplesPerFrame = 1;

                            this.Clip = new Clip(track);
                        }
                    }
                }
            }
        }
    }
}
