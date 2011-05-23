/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
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
    public class RotateFilter : ProcessFilterBase
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

        public override Clip GetClip()
        {
            throw new NotImplementedException();
        }

        protected override Frame RenderFrame(long frameIndex)
        {
            throw new NotImplementedException();
        }
    }
}
