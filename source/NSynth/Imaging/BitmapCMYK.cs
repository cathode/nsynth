/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 *****************************************************************************/
using System;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a bitmap in the CMYK color space.
    /// </summary>
    public sealed class BitmapCMYK : BitmapBase<ColorCMYK>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapCMYK"/> class.
        /// </summary>
        /// <param name="width">The width in pixels of the new bitmap.</param>
        /// <param name="height">The height in pixels of the new bitmap.</param>
        public BitmapCMYK(int width, int height)
            : base(width, height)
        {

        }

        public BitmapCMYK(Size size)
            : base(size.Width, size.Height)
        {
        }
        #endregion
        protected override ColorCMYK GetNativeColor(IColor color)
        {
            throw new NotImplementedException();
        }
    }
}
