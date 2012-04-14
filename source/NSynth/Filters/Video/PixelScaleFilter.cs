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
    /// Performs high-quality bitmap scaling for bitmaps containing specific types of low-resolution pixel and line art.
    /// </summary>
    /// <remarks>
    /// Wikipedia article: http://en.wikipedia.org/wiki/Pixel_art_scaling_algorithms
    /// </remarks>
    public class PixelScaleFilter : ProcessFilterBase
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="MagnificationLevel"/> property.
        /// </summary>
        private PixelScaleAlgorithm magnificationLevel;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="PixelScaleAlgorithm"/> that indicates what level of magnification is applied to the input video/frame.
        /// </summary>
        [FilterParameter("Algorithm", Kind = FilterParameterKind.Enumeration)]
        public PixelScaleAlgorithm MagnificationLevel
        {
            get
            {
                return this.magnificationLevel;
            }
            set
            {
                this.magnificationLevel = value;
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
            if (this.IsDisposed)
                throw new ObjectDisposedException(this.GetType().Name);

            Frame input = this.Input.GetFrame(frameIndex);


            if (this.MagnificationLevel == PixelScaleAlgorithm.HQ2x)
                throw new NotImplementedException();
            //return this.Magnify2x(input);
            else if (this.MagnificationLevel == PixelScaleAlgorithm.HQ3x)
                throw new NotImplementedException();
            //return this.Magnify3x(input);
            else if (this.MagnificationLevel == PixelScaleAlgorithm.HQ4x)
                throw new NotImplementedException();
            //return this.Magnify4x(input);
            else
                throw new NotImplementedException();
        }

        /// <summary>
        /// Performs 2x magnification of the image data in the input <see cref="Frame"/>.
        /// </summary>
        /// <param name="input">The <see cref="Frame"/> containing the image data to magnify.</param>
        /// <returns>A <see cref="Frame"/> that contains the result of the magnification operaton.</returns>
        private IBitmap Magnify2x(IBitmap input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs 3x magnification of the image data in the input <see cref="Frame"/>.
        /// </summary>
        /// <param name="input">The <see cref="Frame"/> containing the image data to magnify.</param>
        /// <returns>A <see cref="Frame"/> that contains the result of the magnification operaton.</returns>
        private IBitmap Magnify3x(IBitmap input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs 4x magnification of the image data in the input <see cref="Frame"/>.
        /// </summary>
        /// <param name="input">The <see cref="Frame"/> containing the image data to magnify.</param>
        /// <returns>A <see cref="Frame"/> that contains the result of the magnification operaton.</returns>
        private IBitmap Magnify4x(IBitmap input)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
