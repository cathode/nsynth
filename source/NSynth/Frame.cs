/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using NSynth.Audio;
using NSynth.Imaging;

namespace NSynth
{
    /// <summary>
    /// Represents multimedia data associated with a single frame in a multimedia clip.
    /// </summary>
    public sealed class Frame
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Frame.Audio"/> property.
        /// </summary>
        private ISegment audio;

        /// <summary>
        /// Backing field for the <see cref="Frame.Video"/> property.
        /// </summary>
        private IBitmap video;

        private Filter owner;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Frame"/> class.
        /// </summary>
        /// <remarks>
        /// The new frame supports only one track of each kind.
        /// </remarks>
        public Frame()
        {
        }

        internal Frame(Filter owner)
        {
            this.owner = owner;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the audio data for the current frame.
        /// </summary>
        public ISegment Audio
        {
            get
            {
                return this.audio;
            }
            set
            {
                this.audio = value;
            }
        }

        /// <summary>
        /// Gets the video data for the current frame.
        /// </summary>
        public IBitmap Video
        {
            get
            {
                return this.video;
            }
            set
            {
                this.video = value;
            }
        }
        #endregion
        #region Methods
        public Frame CreateEmptyClone()
        {
            var frame = new Frame();


            return frame;
        }
        #endregion
    }
}
