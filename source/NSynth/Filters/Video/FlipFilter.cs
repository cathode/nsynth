/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth;
using NSynth.Imaging;
using System.Linq;

namespace NSynth.Filters.Video
{
    /// <summary>
    /// Provides a transformation filter which flips the video horizontally, vertically, or both.
    /// </summary>
    public class FlipFilter : EffectFilter
    {
        #region Methods
        protected override bool Render(Frame output, long index)
        {
            // Grab the original frame
            var frame = this.Input.Source.GetFrame(index);

            bool h = (this.FlipDirection & FlipDirection.Horizontal) == FlipDirection.Horizontal;
            bool v = (this.FlipDirection & FlipDirection.Vertical) == FlipDirection.Vertical;

            if (!h && !v)
            {
                // No flipping required, copy input to output and return.
                for (int i = 0; i < output.Video.Count; ++i)
                {
                    var vfd = frame.Video[i];
                    var ofd = output.Video[i];

                    if (frame.Video[i] is BitmapRGB)
                    {
                        var bmp = output.Video[i] as BitmapRGB;
                        bmp.BitBlit((BitmapRGB)frame.Video[i], new Point(0, 0));
                    }
                    else
                    {
                       
                    }
                }
            }

            IEnumerable<IBitmap> bitmaps = frame.Video;
            IColor c;
            int ymin = 0;
            int ymax = output.Video[0].Height;
            int xmin = 0;
            int xmax = output.Video[1].Width;

            for (int i = 0; i < output.Video.Count; ++i)
            {
                var vfd = frame.Video[i];
                var ofd = output.Video[i];
                if (h && v)
                    for (int y1 = ymin, y2 = ymax; y1 < ymax; y1++, y2--)
                        for (int x1 = xmin, x2 = xmax; x1 < xmax; x1++, x2--)
                        {
                            ofd[x1, y1] = vfd[x2, y2];
                            ofd[x2, y2] = vfd[x1, y1];
                        }
                else if (h && !v)
                    for (int y = ymin; y < ymax; y++)
                        for (int x1 = xmin, x2 = xmax; x1 < xmax; x1++, x2--)
                        {
                            ofd[x1, y] = vfd[x2, y];
                            ofd[x2, y] = vfd[x1, y];
                        }
                else if (!h & v)
                    for (int y1 = ymin, y2 = ymax; y1 < ymax; y1++, y2--)
                        for (int x = xmin; x < xmax; x++)
                        { 
                            ofd[x, y1] = vfd[x, y2];
                            ofd[x, y2] = vfd[x, y1];
                        }
            }
            return true;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="FlipDirection"/>
        /// </summary>
        public FlipDirection FlipDirection
        {
            get;
            set;
        }
        #endregion
    }
}
