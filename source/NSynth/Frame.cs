/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
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
        private ISegment audio;

        /// <summary>
        /// Backing field for the <see cref="Frame.Video"/> property.
        /// </summary>
        private IBitmap video;

        /// <summary>
        /// Backing field for the <see cref="Frame.Origin"/> property.
        /// </summary>
        private Filter origin;

        /// <summary>
        /// Backing field for the <see cref="Frame.IsReclaimed"/> property.
        /// </summary>
        private bool isReclaimed;

        private FrameData<IBitmap> videoData;
        private FrameData<ISegment> audioData;


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
            this.videoData = new FrameData<IBitmap>(clip.VideoTracks.Count);
            this.audioData = new FrameData<ISegment>(clip.AudioTracks.Count);
        }

        internal Frame(Clip clip)
            : this()
        {
            Contract.Requires(clip != null);

            this.clip = clip;

            for (int i = 0; i < this.videoData.Count; ++i)
            {
                var track = clip.VideoTracks[i];
                this.videoData[i] = track.Format.CreateBitmap(track.Dimensions);
            }

            for (int i = 0; i < this.audioData.Count; ++i)
            {
                var track = clip.AudioTracks[i];
                this.audioData[i] = null;
            }
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

        public Filter Origin
        {
            get
            {
                return this.origin;
            }
            internal set
            {
                this.origin = value;
            }
        }
        #endregion
        #region Methods
        public void Release()
        {

        }
        #endregion
    }
}
