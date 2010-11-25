/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth;

namespace NSynth.Filters.Internal.Video
{
    /// <summary>
    /// Provides a simple, uniform blurring filter based on the box algorithm.
    /// </summary>
    public class BoxBlur : ProcessFilterBase
    {
        #region Properties
        /// <summary>
        /// Gets or sets the horizontal blur radius in pixels.
        /// </summary>
        [FilterParameter("RadiusX")]
        public int RadiusX
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the vertical blur radius in pixels.
        /// </summary>
        [FilterParameter("RadiusY")]
        public int RadiusY
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of times the blur will be performed. Multiple passes will operate on the output of the previous pass.
        /// </summary>
        [FilterParameter("Iterations")]
        public int Iterations
        {
            get;
            set;
        }

        #endregion
        #region Methods
        public override Clip GetClip()
        {
            throw new NotImplementedException();
        }

        protected Kernel<double> CreateKernel()
        {
            int a = this.RadiusX * 2 + 1;
            int b = this.RadiusY * 2 + 1;
            double c = 1 / (a * b);

            return new Kernel<double>(a, b, c);
        }

        protected override Frame RenderFrame(long index)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
