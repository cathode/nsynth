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
                    else if (frame.Video != null)
                    {
                        var bitmap = frame.Video;
                        if (bitmap != null)
                        {
                            var track = new VideoTrack();
                            //track.SampleCount = this.FrameCount;
                            track.Width = bitmap.Width;
                            track.Height = bitmap.Height;
                            track.Format = bitmap.Format;
                            track.SamplesPerFrame = 1;

                            //this.Clip = new Clip(track);
                        }
                    }
                }
            }
        }
    }
}
