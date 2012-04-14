/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth;
using NSynth.Imaging;

namespace NSynth.Filters.Internal.Video
{
    /// <summary>
    /// A filter that enlarges the input video by an integer multiple.
    /// </summary>
    public class ScaleFilter : ProcessFilterBase
    {
        #region Fields
        private int scaleFactor = 2;
        #endregion
        #region Constructors

        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the scaling factor.
        /// </summary>
        public int ScaleFactor
        {
            get
            {
                return this.scaleFactor;
            }
            set
            {
                if (this.scaleFactor < 2)
                    throw new ArgumentOutOfRangeException("value");

                this.scaleFactor = value;
            }
        }
        #endregion
        #region Methods
        public override Clip GetClip()
        {
            throw new NotImplementedException();
        }

        protected override Frame RenderFrame(long frameIndex)
        {
            var frame = this.Input.GetFrame(frameIndex);

            for (int i = 0; i < frame.Video.Count; i++)
            {
                var bitmap = frame.Video[i];

                if (bitmap is BitmapCMYK)
                {
                    BitmapCMYK input = (BitmapCMYK)bitmap;
                    BitmapCMYK output = new BitmapCMYK((int)(input.Width * this.ScaleFactor), (int)(input.Height * this.ScaleFactor));

                    for (int y = 0; y < input.Height; y++) // Columns
                        for (int x = 0; x < input.Width; x++) // Rows
                            for (int b = (int)(y * this.ScaleFactor), j = 0; j < this.ScaleFactor; b++,j++)
                                for (int a = (int)(x * this.ScaleFactor), k = 0; i < this.ScaleFactor; a++, k++)
                                    output[a, b] = input[x, y];

                    frame.Video[i] = output;
                }
                else if (bitmap is BitmapLAB)
                {
                    BitmapLAB input = (BitmapLAB)bitmap;
                    BitmapLAB output = new BitmapLAB((int)(input.Width * this.ScaleFactor), (int)(input.Height * this.ScaleFactor));

                    for (int y = 0; y < input.Height; y++) // Columns
                        for (int x = 0; x < input.Width; x++) // Rows
                            for (int b = (int)(y * this.ScaleFactor), j = 0; j < this.ScaleFactor; b++, j++)
                                for (int a = (int)(x * this.ScaleFactor), k = 0; i < this.ScaleFactor; a++, k++)
                                    output[a, b] = input[x, y];

                    frame.Video[i] = output;
                }
                else if (bitmap is BitmapRGB)
                {
                    BitmapRGB input = (BitmapRGB)bitmap;
                    BitmapRGB output = new BitmapRGB((int)(input.Width * this.ScaleFactor), (int)(input.Height * this.ScaleFactor));

                    for (int y = 0; y < input.Height; y++) // Columns
                        for (int x = 0; x < input.Width; x++) // Rows
                            for (int b = (int)(y * this.ScaleFactor), j = 0; j < this.ScaleFactor; b++, j++)
                                for (int a = (int)(x * this.ScaleFactor), k = 0; i < this.ScaleFactor; a++, k++)
                                    output[a, b] = input[x, y];

                    frame.Video[i] = output;
                }
                else if (bitmap is BitmapYCC)
                {
                    BitmapYCC input = (BitmapYCC)bitmap;
                    BitmapYCC output = new BitmapYCC((int)(input.Width * this.ScaleFactor), (int)(input.Height * this.ScaleFactor));

                    for (int y = 0; y < input.Height; y++) // Columns
                        for (int x = 0; x < input.Width; x++) // Rows
                            for (int b = (int)(y * this.ScaleFactor), j = 0; j < this.ScaleFactor; b++, j++)
                                for (int a = (int)(x * this.ScaleFactor), k = 0; i < this.ScaleFactor; a++, k++)
                                    output[a, b] = input[x, y];

                    frame.Video[i] = output;
                }
            }
            return frame;
        }
        #endregion
    }
}
