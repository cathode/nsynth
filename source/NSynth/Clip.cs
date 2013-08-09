/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Linq;
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

        private readonly object framePoolLock = new object();

        private readonly List<Frame> inUseFrames;

        private readonly LinkedList<Frame> freeFrames;

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
            this.navigationTracks = new ClipData<NavigationTrack>(this);
            this.subtitleTracks = new ClipData<SubtitleTrack>(this);
            this.videoTracks = new ClipData<VideoTrack>(this);

            this.inUseFrames = new List<Frame>();
            this.freeFrames = new LinkedList<Frame>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Clip"/> class.
        /// </summary>
        /// <param name="tracks">A collection of <see cref="Track"/> instances to populate the new <see cref="Clip"/> with.</param>
        public Clip(params Track[] tracks)
            : this()
        {
            Contract.Requires(tracks != null);

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
        public ClipData<SubtitleTrack> SubtitleTracks
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

            foreach (var t in this.audioTracks)
                if (t != null)
                    c.audioTracks.Add(t.DeepClone() as AudioTrack);
            foreach (var t in this.navigationTracks)
                if (t != null)
                    c.navigationTracks.Add(t.DeepClone() as NavigationTrack);
            foreach (var t in this.subtitleTracks)
                if (t != null)
                    c.subtitleTracks.Add(t.DeepClone() as SubtitleTrack);
            foreach (var t in this.videoTracks)
                if (t != null)
                    c.videoTracks.Add(t.DeepClone() as VideoTrack);

            return c;
        }

        /// <summary>
        /// Obtains a <see cref="Frame"/> relevant to the current clip.
        /// </summary>
        /// <returns>The new empty <see cref="Frame"/> instance.</returns>
        /// <remarks>
        /// Frames are pooled to reduce memory allocations, as each frame instance can be quite large (tens or even hundreds of megabytes),
        /// and expensive to (re)create.
        /// </remarks>
        public Frame IssueFrame()
        {
            Contract.Ensures(Contract.Result<Frame>() != null);

            Frame result;

            lock (this.framePoolLock)
            {
                if (this.freeFrames.Count > 0)
                {
                    result = this.freeFrames.Last.Value;
                    if (result == null)
                        throw new NotImplementedException();
                    this.freeFrames.RemoveLast();
                }
                else
                {
                    result = new Frame(this);
                    this.inUseFrames.Add(result);
                }
            }
            return result;
        }
        internal void Reclaim(Frame frame)
        {
            Contract.Requires(frame != null);
            //Contract.Requires(this.inUseFrames.Contains(frame) || this.freeFrames.Contains(frame));
            Contract.Ensures(this.freeFrames.Contains(frame));
            lock (this.framePoolLock)
            {
                frame.IsReclaimed = true;

                this.freeFrames.AddLast(frame);
            }
        }

        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(this.audioTracks != null);
            Contract.Invariant(this.navigationTracks != null);
            Contract.Invariant(this.subtitleTracks != null);
            Contract.Invariant(this.videoTracks != null);
            Contract.Invariant(this.freeFrames != null);
            Contract.Invariant(this.inUseFrames != null);

            //Contract.Invariant(Contract.ForAll(this.freeFrames, f => f != null));
            //Contract.Invariant(Contract.ForAll(this.inUseFrames, f => f != null));

            // Do we need these?
            Contract.Invariant(this.audioTracks.Clip == this);
            Contract.Invariant(this.navigationTracks.Clip == this);
            Contract.Invariant(this.subtitleTracks.Clip == this);
            Contract.Invariant(this.videoTracks.Clip == this);


        }
        #endregion
    }
}