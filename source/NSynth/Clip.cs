/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using NSynth.Audio;
using NSynth.Video;

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
        private readonly ClipData<AudioTrack> audioTracks;

        /// <summary>
        /// Backing field for the <see cref="Clip.VideoTracks"/> property.
        /// </summary>
        private readonly ClipData<VideoTrack> videoTracks;

        /// <summary>
        /// Backing field for the <see cref="Clip.SubtitleTracks"/> property.
        /// </summary>
        private readonly ClipData<SubtitleTrack> subtitleTracks;

        /// <summary>
        /// Backing field for the <see cref="Clip.NavigationTracks"/> property.
        /// </summary>
        private readonly ClipData<NavigationTrack> navigationTracks;

        /// <summary>
        /// Backing field for the <see cref="Clip.FrameCount"/> property.
        /// </summary>
        private long frameCount;

        /// <summary>
        /// Backing field for the <see cref="Clip.IsLocked"/> property.
        /// </summary>
        private bool isLocked;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Clip"/> class.
        /// </summary>
        public Clip()
        {
            this.isLocked = false;
            this.audioTracks = new ClipData<AudioTrack>(this);
            this.navigationTracks = new ClipData<NavigationTrack>(this);
            this.subtitleTracks = new ClipData<SubtitleTrack>(this);
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
                else if (t is SubtitleTrack)
                    this.subtitleTracks.Add((SubtitleTrack)t);
                else if (t is NavigationTrack)
                    this.navigationTracks.Add((NavigationTrack)t);
            }
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the audio tracks in the current <see cref="Clip"/>.
        /// </summary>
        public ClipData<AudioTrack> AudioTracks
        {
            get
            {
                return this.audioTracks;
            }
        }

        /// <summary>
        /// Gets the video tracks in the current <see cref="Clip"/>.
        /// </summary>
        public ClipData<VideoTrack> VideoTracks
        {
            get
            {
                return this.videoTracks;
            }
        }

        /// <summary>
        /// Gets the navigation tracks in the current <see cref="Clip"/>.
        /// </summary>
        public ClipData<NavigationTrack> NavigationTracks
        {
            get
            {
                return this.navigationTracks;
            }
        }

        /// <summary>
        /// Gets the subtitle tracks in the current <see cref="Clip"/>.
        /// </summary>
        public ClipData<SubtitleTrack> SubtitleTrack
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
                Contract.Requires(!this.IsLocked);

                this.frameCount = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the configuration of the clip is locked. A locked clip can't have tracks added or removed, or any other metadata changed.
        /// </summary>
        public bool IsLocked
        {
            get
            {
                return this.isLocked;
            }
            internal set
            {
                this.isLocked = value;
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
        /// Obtains a <see cref="Frame"/> that reflects the current clip.
        /// </summary>
        /// <returns>The new empty <see cref="Frame"/> instance.</returns>
        /// <remarks>
        /// Frames are pooled to reduce memory allocations, as each instance can be quite large (tens or even hundreds of megabytes),
        /// and expensive to (re)create.
        /// </remarks>
        public Frame GetFrame()
        {
            throw new NotSupportedException();
        }

        public void LockConfiguration()
        {
            this.isLocked = true;
        }
        #endregion
    }
}