/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using NSynth.Audio;
using NSynth.Video;

namespace NSynth
{
    /// <summary>
    /// Represents a series of frames and associated metadata.
    /// </summary>
    public sealed class Clip
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Clip.AudioTracks"/> property.
        /// </summary>
        private readonly ClipData<AudioTrack> audioTracks;

        /// <summary>
        /// Backing field for the <see cref="Clip.VideoTracks"/> property.
        /// </summary>
        private readonly ClipData<VideoTrack> videoTracks;

        /// <summary>
        /// Backing field for the <see cref="Clip.FrameCount"/> property.
        /// </summary>
        private long frameCount;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Clip"/> class.
        /// </summary>
        public Clip()
        {
            this.audioTracks = new ClipData<AudioTrack>(this);
            this.videoTracks = new ClipData<VideoTrack>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Clip"/> class.
        /// </summary>
        /// <param name="tracks">A collection of <see cref="Track"/> instances to populate the new <see cref="Clip"/> with.</param>
        public Clip(params Track[] tracks)
            : this()
        {
            foreach (var t in tracks)
            {
                if (t is AudioTrack)
                    this.audioTracks.Add((AudioTrack)t);
                else if (t is VideoTrack)
                    this.videoTracks.Add((VideoTrack)t);
            }
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the audio track data of the current <see cref="Clip"/>.
        /// </summary>
        public ClipData<AudioTrack> AudioTracks
        {
            get
            {
                return this.audioTracks;
            }
        }

        /// <summary>
        /// Gets the video track data of the current <see cref="Clip"/>.
        /// </summary>
        public ClipData<VideoTrack> VideoTracks
        {
            get
            {
                return this.videoTracks;
            }
        }

        /// <summary>
        /// Gets the number of frames in the current clip. If the tracks in the clip have different lengths,
        /// this property returns the number of frames in the longest track.
        /// </summary>
        public long FrameCount
        {
            get
            {
                return this.frameCount;
            }
            internal set
            {
                this.frameCount = value;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Creates and returns a new <see cref="Frame"/> instance that contains the correct configuration of tracks and track data.
        /// </summary>
        /// <returns>The new empty <see cref="Frame"/> instance.</returns>
        public Frame NewFrame()
        {
            var frame = new Frame(this);

            return frame;
        }
        #endregion
    }
}