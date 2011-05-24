/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;
using NSynth.Filters;
using NSynth.Video;

namespace NSynth.Imaging.TGA
{
    /// <summary>
    /// Decodes bitmap image data from a Truevision TARGA bitstream.
    /// </summary>
    public sealed class TGASourceFilter : ImageSourceFilter
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TGASourceFilter"/> class.
        /// </summary>
        public TGASourceFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TGASourceFilter"/> class.
        /// </summary>
        public TGASourceFilter(string path)
            : base(path)
        {
        }
        #endregion
        #region Properties
        #endregion
        #region Methods
        /// <summary>
        /// Overridden. Renders the frame with the specified index.
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        public override Frame Render(long frameIndex)
        {
            using (var stream = this.OpenStreamForFrame(frameIndex))
            {
                using (var decoder = new TGADecoder())
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
                using (var decoder = new TGADecoder())
                {
                    decoder.Bitstream = stream;
                    decoder.Initialize();
                    var frame = decoder.Decode();
                    if (frame.Video.Count > 0)
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
        #endregion
    }
}
