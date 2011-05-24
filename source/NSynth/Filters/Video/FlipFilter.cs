/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth;
using NSynth.Imaging;

namespace NSynth.Filters.Internal.Video
{
    /// <summary>
    /// Provides a transformation filter which flips the video horizontally, vertically, or both.
    /// </summary>
    public class FlipFilter : ProcessFilterBase
    {
        #region Methods
        public override Clip GetClip()
        {
            throw new NotImplementedException();
        }
        protected override Frame RenderFrame(long frameIndex)
        {
            // Grab the original frame
            var frame = this.Input.GetFrame(frameIndex);

            bool h = (this.FlipDirection & FlipDirection.Horizontal) == FlipDirection.Horizontal;
            bool v = (this.FlipDirection & FlipDirection.Vertical) == FlipDirection.Vertical;

            if (!h && !v)
                return frame; // No flipping required.

            IEnumerable<IBitmap> bitmaps = null;
            IColor c;
            int ymin = this.Mask.Top;
            int ymax = this.Mask.Bottom;
            int xmin = this.Mask.Left;
            int xmax = this.Mask.Right;
            foreach (var bitmap in bitmaps)
                if (h && v)
                    for (int y1 = ymin, y2 = ymax; y1 < ymax; y1++, y2--)
                        for (int x1 = xmin, x2 = xmax; x1 < xmax; x1++, x2--)
                        {
                            c = bitmap[x1, y1];
                            bitmap[x1, y1] = bitmap[x2, y2];
                            bitmap[x2, y2] = c;
                        }
                else if (h && !v)
                    for (int y = ymin; y < ymax; y++)
                        for (int x1 = xmin, x2 = xmax; x1 < xmax; x1++, x2--)
                        {
                            c = bitmap[x1, y];
                            bitmap[x1, y] = bitmap[x2, y];
                            bitmap[x2, y] = c;
                        }
                else if (!h & v)
                    for (int y1 = ymin, y2 = ymax; y1 < ymax; y1++, y2--)
                        for (int x = xmin; x < xmax; x++)
                        {
                            c = bitmap[x, y1];
                            bitmap[x, y1] = bitmap[x, y2];
                            bitmap[x, y2] = c;
                        }

            return frame;
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
        public Rectangle Mask
        {
            get;
            set;
        }
        #endregion
    }
}
