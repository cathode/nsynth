/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth.Imaging;

namespace NSynth.Filters.Video
{
    /// <summary>
    /// Provides a simple and fast frame blur action.
    /// </summary>
    public class BlurFilter : EffectFilter
    {
        #region Properties
        public BlurAlgorithm Algorithm
        {
            get;
            set;
        }
        #endregion
        #region Methods
        protected override void OnInitializing(FilterInitializationEventArgs e)
        {
            base.OnInitializing(e);

            if (this.Input.Source == null)
                this.Clip = new Clip();
            else
                this.Clip = this.Input.Source.Clip;

        }

        protected override bool Render(Frame output, long index)
        {
            var frame = this.Input.Source.GetFrame(index);

            var blurred = this.BoxBlur(frame.Video[0]);
            output.Video[0] = blurred;
            return true;
        }

        private BitmapRGB BoxBlur(IBitmap source)
        {
            int radius = 1;
            int n = 0;
            ColorRGB[] pix = new ColorRGB[source.Width * source.Height];
            float div = (float)Math.Pow((radius * 2 + 1), 2);
            var bmp = new BitmapRGB(source.Width, source.Height);

            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {

                    ColorRGB total = new ColorRGB();
                    div = 0;
                    for (int ky = -radius; ky <= radius; ky++)
                    {
                        for (int kx = -radius; kx <= radius; kx++)
                        {
                            var p = source[Math.Max(Math.Min(x + kx, source.Width - 1), 0), Math.Max(Math.Min(y + ky, source.Height - 1), 0)];
                            total.Red += p.Red;
                            total.Green += p.Green;
                            total.Blue += p.Blue;
                            div += 1;
                        }
                    }
                    total.Red /= div;
                    total.Green /= div;
                    total.Blue /= div;
                    total.Alpha = 1.0f;
                    bmp[x, y] = total;
                }
            }


            return bmp;
        }
        #endregion
    }
}
