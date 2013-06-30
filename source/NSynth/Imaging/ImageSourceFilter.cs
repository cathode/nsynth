/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;

namespace NSynth.Imaging
{
    /// <summary>
    /// Provides a base class for source filters that yield frames from one or more image streams.
    /// </summary>
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
        /// <param name="path"></param>
        protected ImageSourceFilter(string path = "")
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
                return this.path ?? string.Empty;
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

        public long ImageCount
        {
            get
            {
                return this.Clip.VideoTracks[0].SampleCount;
            }
            set
            {
                this.Clip.VideoTracks[0].SampleCount = value;
            }
        }
        #endregion
        #region Methods
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
