/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a bitmap in the LAB color space.
    /// </summary>
    public sealed class BitmapLAB : BitmapBase<ColorLAB>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BitmapLAB"/> class.
        /// </summary>
        /// <param name="width">The width in pixels of the new bitmap.</param>
        /// <param name="height">The height in pixels of the new bitmap.</param>
        public BitmapLAB(int width, int height)
            : base(width, height)
        {
        }
        public BitmapLAB(Size size)
            : base(size.Width, size.Height)
        {
        }
        #endregion
        #region Methods
        /// <summary>
        /// Converts the specified 
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        protected override ColorLAB GetNativeColor(IColor color)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
