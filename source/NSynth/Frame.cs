/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
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
        private readonly FrameData<ISegment> audio;

        /// <summary>
        /// Backing field for the <see cref="Frame.Video"/> property.
        /// </summary>
        private readonly FrameData<IBitmap> video;
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
            this.audio = new FrameData<ISegment>(1);
            this.video = new FrameData<IBitmap>(1);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Frame"/> class.
        /// </summary>
        /// <param name="clip">A <see cref="Clip"/> that defines the track layout.</param>
        public Frame(Clip clip)
        {
            this.video = new FrameData<IBitmap>(clip.VideoTracks.Count);
            for (int i = 0; i < this.video.Count; i++)
            {
                var track = clip.VideoTracks[i];
                this.video[i] = track.Format.CreateBitmap(track.Dimensions);
            }

            this.audio = new FrameData<ISegment>(0);
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the audio data for the current frame.
        /// </summary>
        public FrameData<ISegment> Audio
        {
            get
            {
                return this.audio;
            }
        }

        /// <summary>
        /// Gets the video data for the current frame.
        /// </summary>
        public FrameData<IBitmap> Video
        {
            get
            {
                return this.video;
            }
        }
        #endregion
    }
}
