/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth;

namespace NSynth.Filters.Internal.Video
{
    /// <summary>
    /// Provides a filter that allows the video to be rotated.
    /// </summary>
    public class RotateFilter : EffectFilter
    {
        #region Methods - Protected



        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the angle of rotation.
        /// </summary>
        public RotateAngle Angle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the direction of rotation.
        /// </summary>
        public RotateDirection Direction
        {
            get;
            set;
        }

        #endregion

        public  Clip GetClip()
        {
            throw new NotImplementedException();
        }

        protected  Frame RenderFrame(long frameIndex)
        {
            var frame = this.Input.Filter.GetFrame(frameIndex);

            var bitmap = frame.Video[0];
            var output = new NSynth.Imaging.BitmapRGB(bitmap.Height, bitmap.Width); // invert order of width and height.

            // simple clockwise rotation 90 degrees.
            for (int y = 0; y < bitmap.Height; ++y)
                for (int x = 0; x < bitmap.Width; ++x)
                    output[y, x] = new NSynth.Imaging.ColorRGB(bitmap[x, y]);

            return null; // some other stuff to do before returning a real frame.
        }
    }
}
