/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth.Imaging;
using System.Diagnostics.Contracts;

namespace NSynth.Filters.Video
{
    /// <summary>
    /// Provides a simple and fast frame blur action.
    /// </summary>
    public class BlurFilter : EffectFilter
    {
        public BlurFilter(int radius = 1)
        {
            this.Radius = radius;
        }

        #region Properties
        public BlurAlgorithm Algorithm
        {
            get;
            set;
        }
        public int Radius
        {
            get;
            set;
        }
        #endregion
        #region Methods
        protected override void OnClipInitializing(FilterInitializationEventArgs e)
        {
            base.OnClipInitializing(e);

            if (this.Source.Filter == null)
                this.Clip = new Clip();
            else
                this.Clip = this.Source.Filter.Clip;

        }

        protected override void DoProcessing(FilterProcessingContext context, Frame outputFrame)
        {
            var src = context.GetFrame("source");
            var sbmp = src.Video[0];

            if (sbmp is BitmapRGB32)
                this.BoxBlurRGB32(sbmp as BitmapRGB32, outputFrame.Video[0] as BitmapRGB32);
            else if (sbmp is BitmapRGB24)
                this.BoxBlurRGB24(sbmp as BitmapRGB24, outputFrame.Video[0] as BitmapRGB24);
        }

        private void BoxBlurRGB32(BitmapRGB32 input, BitmapRGB32 output, BitmapRGB32 mask = null)
        {
            Contract.Requires(input != null);
            Contract.Requires(output != null);

        }

        private void BoxBlurRGB24(BitmapRGB24 input, BitmapRGB24 output, BitmapRGB32 mask = null)
        {
            Contract.Requires(input != null);
            Contract.Requires(output != null);
            Contract.Requires(input.Width == output.Width);
            Contract.Requires(input.Height == output.Height);

            int radius = this.Radius;
            int w = input.Width;
            int h = input.Height;
            var bmp = output;

            var pix = bmp.Pixels;
            float div = (float)Math.Pow((radius * 2 + 1), 2);

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    var tr = 0.0;
                    var tg = 0.0;
                    var tb = 0.0;

                    for (int ky = -radius; ky <= radius; ky++)
                    {
                        for (int kx = -radius; kx <= radius; kx++)
                        {
                            var px = Math.Max(Math.Min(x + kx, w - 1), 0);
                            var py = Math.Max(Math.Min(y + ky, h - 1), 0);
                            var p = input[px, py];
                            tr += p.Red;
                            tg += p.Green;
                            tb += p.Blue;
                            //div += 1;
                        }
                    }
                    //total.Alpha = 1.0f;
                    bmp[x, y] = new ColorRGB24((byte)(tr / 255.0 * (255.0 / div)),
                        (byte)(tg / 255.0 * (255.0 / div)), (byte)(tb / 255.0 * (255.0 / div)));
                }
            }
        }
        #endregion
    }
}
