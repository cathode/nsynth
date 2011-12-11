/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using NSynth.Audio;
using NSynth.Video;
using System.Collections.Generic;
using System;

namespace NSynth
{
    /// <summary>
    /// Represents the format, layout, and other metadata of multimedia content.
    /// </summary>
    public sealed class Clip
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Clip.AudioTracks"/> property.
        /// </summary>
        private List<AudioTrack> audioTracks;

        /// <summary>
        /// Backing field for the <see cref="Clip.VideoTracks"/> property.
        /// </summary>
        private List<VideoTrack> videoTracks;


        private List<SubtitleTrack> subtitleTracks;

        private List<NavigationTrack> navigationTracks;
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
            this.audioTracks = new List<AudioTrack>();
            this.videoTracks = new List<VideoTrack>();
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
        /// Gets the audio tracks in the current <see cref="Clip"/>.
        /// </summary>
        public List<AudioTrack> AudioTracks
        {
            get
            {
                return this.audioTracks;
            }
        }

        /// <summary>
        /// Gets the video tracks in the current <see cref="Clip"/>.
        /// </summary>
        public List<VideoTrack> VideoTracks
        {
            get
            {
                return this.videoTracks;
            }
        }

        /// <summary>
        /// Gets the navigation tracks in the current <see cref="Clip"/>.
        /// </summary>
        public List<NavigationTrack> NavigationTracks
        {
            get
            {
                return this.navigationTracks;
            }
        }

        /// <summary>
        /// Gets the subtitle tracks in the current <see cref="Clip"/>.
        /// </summary>
        public List<SubtitleTrack> SubtitleTrack
        {
            get
            {
                return this.subtitleTracks;
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
        /// Creates a deep clone of the current <see cref="Clip"/> and the track data it contains.
        /// </summary>
        /// <returns></returns>
        public Clip DeepClone()
        {
            Clip c = new Clip();

            return c;
        }
        /// <summary>
        /// Creates and returns a new <see cref="Frame"/> instance that contains the correct configuration of tracks and track data.
        /// </summary>
        /// <returns>The new empty <see cref="Frame"/> instance.</returns>
        public Frame NewFrame()
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}