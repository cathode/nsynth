/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Video.H264
{
    /// <summary>
    /// Represents H.264-specific initialization options that may be supplied to an <see cref="H264SourceFilter"/> prior to initialization procedure.
    /// </summary>
    public sealed class H264SourceFilterInitializationEventArgs : FilterInitializationEventArgs
    {
        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether an index should be generated during the initialization process.
        /// Indexing an H.264 stream requires that the complete stream is available, and allows faster random access.
        /// </summary>
        public bool GenerateIndex
        {
            get;
            set;
        }
        #endregion
    }
}
