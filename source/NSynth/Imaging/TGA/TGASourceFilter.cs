/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;
using NSynth.Filters;
using NSynth.Video;
using NSynth;

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
        protected override void OnClipInitializing(FilterInitializationEventArgs e)
        {
            base.OnClipInitializing(e);

            using (var stream = this.OpenStreamForFrame(0))
            {
                using (var decoder = new TGADecoder(stream))
                {
                    decoder.Initialize();
                    var context = decoder.DecodeHeader();
                    var header = context.Header;
                    var track = new VideoTrack()
                    {
                        SampleCount = 1,
                        SamplesPerFrame = 1,
                        Width = header.Width,
                        Height = header.Height,
                    };

                    //track.Format = 
                    if (header.BitsPerPixel == 24)
                        track.Format = ColorFormat.RGB24;
                    else
                        track.Format = ColorFormat.RGB32;

                    track.SamplesPerFrame = 1;
                    track.SampleCount = 1;

                    /*
                    var track = new VideoTrack();
                    track.SampleCount = 1;
                    track.Width = bitmap.Width;
                    track.Height = bitmap.Height;
                    track.Format = bitmap.Format;
                    track.SamplesPerFrame = 1;
                    track.Options = TrackOptions.Infinite;
                    */

                    this.Clip = new Clip(track);
                }
            }
        }

        protected override void DoProcessing(FilterProcessingContext inputFrames, Frame outputFrame)
        {
            Console.WriteLine("decoding tga frame");

            using (var stream = this.OpenStreamForFrame(0))
            {
                using (var decoder = new TGADecoder(stream))
                {
                    decoder.Initialize();
                    decoder.Decode(outputFrame);
                }
            }
        }
        #endregion
    }
}
