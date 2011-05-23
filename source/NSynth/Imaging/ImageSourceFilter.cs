/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;

namespace NSynth.Imaging
{
    public abstract class ImageSourceFilter : Filter
    {
        #region Fields
        private string path;
        private bool multiFrame;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSourceFilter"/> class.
        /// </summary>
        protected ImageSourceFilter()
        {
            this.Path = string.Empty;
        }
        protected ImageSourceFilter(string path)
        {
            this.Path = path;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the path to the image file(s) to decode.
        /// </summary>
        public string Path
        {
            get
            {
                return this.path;
            }
            set
            {
                this.path = value ?? string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the current <see cref="ImageSourceFilter.Path"/> value represents a range of images or a single image.
        /// </summary>
        public bool MultiFrame
        {
            get
            {
                return this.multiFrame;
            }
            set
            {
                this.multiFrame = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of frames.
        /// </summary>
        public int FrameCount
        {
            get;
            set;
        }
        #endregion
        #region Methods
        public override Frame Render(long frameIndex)
        {

            throw new NotImplementedException();
        }
        protected Stream OpenStreamForFrame(long frameIndex)
        {
            if (this.MultiFrame)
                return File.Open(string.Format(this.Path, frameIndex), FileMode.Open, FileAccess.Read, FileShare.Read);
            else
                return File.Open(this.Path, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
        #endregion
    }
}
