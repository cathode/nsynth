/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth;

namespace NSynth.Filters.Internal
{
    /// <summary>
    /// Represents a source action that pulls frames from an image or series of
    /// images.
    /// </summary>
    /// <remarks>
    /// The Path parameter should be a format string
    /// with the following form: "path\to\image{0}.bmp", the
    /// {0} will be replaced with the frame number.
    /// 
    /// If a single image should be used instead of a sequence, the format
    /// parameter can be omitted, in that case, the same frame will be
    /// returned regardless of the frame index requested.
    /// </remarks>
    public class ImageSourceFilterBase : SourceFilterBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSourceFilterBase"/> class.
        /// </summary>
        public ImageSourceFilterBase()
        {

        }
        #endregion
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Path"/> property.
        /// </summary>
        private string path;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the path of the image source.
        /// </summary>
        public string Path
        {
            get
            {
                return this.path;
            }

            set
            {
                this.path = value;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Overridden. Gets the <see cref="Frame"/> with the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override Frame Render(long frameIndex)
        {
            if (this.Path == null)
                return null;
            else
                throw new NotImplementedException();

            // string framePath = string.Format(this.path, frameIndex);

            // return null;
        }
        #endregion
    }
}
