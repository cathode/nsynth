/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth;
using NSynth.Imaging;

namespace NSynth.Filters.Video
{
    /// <summary>
    /// Provides an effect filter to invert one or more color channels of the input clip.
    /// </summary>
    public class InvertFilter : ProcessFilterBase
    {
        #region Methods
        private void InvertBitmap(IBitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var px = bitmap[x, y];
                    px.Red = 1.0f - px.Red;
                    px.Green = 1.0f - px.Green;
                    px.Blue = 1.0f - px.Blue;
                    bitmap[x, y] = px;
                }
        }
        #endregion
    }
}
