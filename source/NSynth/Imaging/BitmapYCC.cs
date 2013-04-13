/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a bitmap in the YCbCr color space.
    /// </summary>
    public sealed class BitmapYCC : BitmapBase<ColorYCC>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapYCC"/> class.
        /// </summary>
        /// <param name="width">The width in pixels of the new bitmap.</param>
        /// <param name="height">The height in pixels of the new bitmap.</param>
        public BitmapYCC(int width, int height)
            : base(width, height)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapYCC"/> class.
        /// </summary>
        /// <param name="size">A <see cref="Size"/> that indicates the width and height in pixels of the new bitmap.</param>
        public BitmapYCC(Size size)
            : base(size.Width, size.Height)
        {
        }
        protected override ColorYCC GetNativeColor(IColor color)
        {
            throw new NotImplementedException();
        }
    }
}
