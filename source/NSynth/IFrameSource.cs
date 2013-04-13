/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth
{
    /// <summary>
    /// Represents a source of frame data.
    /// </summary>
    public interface IFrameSource
    {
        #region Properties
        /// <summary>
        /// Gets the total number of frames, if known. For frame sources with an undetermined or infinite number of frames,
        /// this property will return -1 instead.
        /// </summary>
        long FrameCount
        {
            get;
        }

        Clip Clip
        {
            get;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Gets the frame with the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Frame GetFrame(long index);
        #endregion
    }
}
