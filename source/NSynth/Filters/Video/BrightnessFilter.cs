/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;
using NSynth;
using NSynth.Imaging;

namespace NSynth.Filters.Internal.Video
{
    public class BrightnessFilter : ProcessFilterBase
    {
        #region Fields
        private float adjustment;
        #endregion
        #region Constructors
        public BrightnessFilter()
        {

        }
        public BrightnessFilter(float adjustment)
        {
            this.adjustment = adjustment;
        }
        #endregion
        #region Properties
        public float Adjustment
        {
            get
            {
                return this.adjustment;
            }
            set
            {
                this.adjustment = value;
            }
        }
        #endregion
        #region Methods
        protected override Frame RenderFrame(long frameIndex)
        {
            Frame frame = this.Input.GetFrame(frameIndex);

            foreach (var bitmap in frame.Video)
                for (int y = 0; y < bitmap.Height; y++)
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        var px = bitmap[x, y];
                        px.Red += this.adjustment;
                        px.Green += this.adjustment;
                        px.Blue += this.adjustment;
                        bitmap[x, y] = px;
                    }


            return frame;
        }
        #endregion
    }
}
