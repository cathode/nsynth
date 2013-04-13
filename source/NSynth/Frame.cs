/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using NSynth.Audio;
using NSynth.Imaging;
using System.Diagnostics.Contracts;

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
        private FrameData<ISegment> audio;

        /// <summary>
        /// Backing field for the <see cref="Frame.Video"/> property.
        /// </summary>
        private FrameData<IBitmap> video;

        /// <summary>
        /// Backing field for the <see cref="Frame.Source"/> property.
        /// </summary>
        private Filter source;

        /// <summary>
        /// Backing field for the <see cref="Frame.IsReclaimed"/> property.
        /// </summary>
        private bool isReclaimed;

        private readonly Clip clip;
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
            this.video = new FrameData<IBitmap>(1);
            this.audio = new FrameData<ISegment>(1);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Frame"/> class, using the specified track structure.
        /// </summary>
        /// <param name="tracks"></param>
        public Frame(params Track[] tracks)
            : this(new Clip(tracks))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Frame"/> class.
        /// </summary>
        /// <param name="clip"></param>
        internal Frame(Clip clip)
            : this()
        {
            Contract.Requires(clip != null);

            this.clip = clip;
            this.video = new FrameData<IBitmap>(clip.VideoTracks.Count);
            this.audio = new FrameData<ISegment>(clip.AudioTracks.Count);

            for (int i = 0; i < this.video.Count; ++i)
            {
                var track = clip.VideoTracks[i];
                this.video[i] = track.Format.CreateBitmap(track.Dimensions);
            }

            for (int i = 0; i < this.audio.Count; ++i)
            {
                var track = clip.AudioTracks[i];
                this.audio[i] = null;
            }
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
            set
            {
                this.audio = value;
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
            set
            {
                this.video = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the frame was reclaimed by the frame pool for it's clip.
        /// </summary>
        public bool IsReclaimed
        {
            get
            {
                return this.isReclaimed;
            }
            internal set
            {
                this.isReclaimed = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="Filter"/> that generated the current frame's contents.
        /// </summary>
        public Filter Source
        {
            get
            {
                return this.source;
            }
            internal set
            {
                this.source = value;
            }
        }

        public Clip Owner
        {
            get
            {
                return this.clip;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Indicates that the frame is no longer being used and it's resources may be recycled (to reduce re-allocation of large bitmaps etc.).
        /// </summary>
        public void Release()
        {

        }
        #endregion
    }
}
