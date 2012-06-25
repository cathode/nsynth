/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
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
        protected override void OnInitializing(FilterInitializationEventArgs e)
        {
            try
            {
                this.Mutex.WaitOne();

                base.OnInitializing(e);

                using (var stream = this.OpenStreamForFrame(0))
                {
                    using (var decoder = new TGADecoder())
                    {
                        decoder.Bitstream = stream;
                        decoder.Initialize();
                        var frame = new Frame();
                        decoder.Decode(frame);

                        var bitmap = frame.Video[0];
                        if (bitmap != null)
                        {
                            var track = new VideoTrack();
                            track.SampleCount = 1;
                            track.Width = bitmap.Width;
                            track.Height = bitmap.Height;
                            track.Format = bitmap.Format;
                            track.SamplesPerFrame = 1;
                            track.Options = TrackOptions.Infinite;

                            this.Clip = new Clip(track);
                        }
                    }
                }
            }
            finally
            {
                this.Mutex.ReleaseMutex();
            }
        }

        protected override bool Render(Frame output, long index)
        {
            try
            {
                using (var stream = this.OpenStreamForFrame(0))
                {
                    using (var decoder = new TGADecoder(stream))
                    {
                        decoder.Initialize();
                        decoder.Decode(output);
                    }
                }
            }
            catch
            {
                return false;
            }
            
            return true;
        }
        #endregion
    }
}
