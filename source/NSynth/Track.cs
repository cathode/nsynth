/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace NSynth
{
    /// <summary>
    /// Represents a track of a multimedia stream.
    /// </summary>
    public abstract class Track
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="Track.Culture"/> property.
        /// </summary>
        private CultureInfo culture;

        /// <summary>
        /// Backing field for the <see cref="Track.Delay"/> property.
        /// </summary>
        private decimal delay;

        /// <summary>
        /// Backing field for the <see cref="Track.Index"/> property.
        /// </summary>
        private int index;

        /// <summary>
        /// Backing field for the <see cref="Track.Name"/> property.
        /// </summary>
        private string name;

        /// <summary>
        /// Backing field for the <see cref="Track.Options"/> property.
        /// </summary>
        private TrackOptions options;

        /// <summary>
        /// Backing field for the <see cref="Track.FrameRate"/> property.
        /// </summary>
        private SampleRate frameRate;

        /// <summary>
        /// Backing field for the <see cref="Track.SampleCount"/> property.
        /// </summary>
        private long sampleCount;

        /// <summary>
        /// Backing field for the <see cref="Track.SamplesPerFrame"/> property.
        /// </summary>
        private int samplesPerFrame;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Track"/> class.
        /// </summary>
        protected Track()
        {
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="CultureInfo"/> of the current track.
        /// </summary>
        public CultureInfo Culture
        {
            get
            {
                return this.culture;
            }
            set
            {
                this.culture = value;
            }
        }

        /// <summary>
        /// Gets or sets the fractional number of seconds that the track is delayed relative to the clip.
        /// </summary>
        public decimal Delay
        {
            get
            {
                return this.delay;
            }
            set
            {
                this.delay = value;
            }
        }

        /// <summary>
        /// Gets the number of frames in the track.
        /// </summary>
        public long FrameCount
        {
            get
            {
                if (this.SampleCount == 0 || this.SamplesPerFrame == 0)
                    return 0;
                else
                    return (long)Math.Ceiling(this.SampleCount / (decimal)this.SamplesPerFrame);
            }
        }

        /// <summary>
        /// Gets or sets the index of the track.
        /// </summary>
        public int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="TrackKind"/> that describes the content in the current <see cref="Track"/>.
        /// </summary>
        public abstract TrackKind Kind
        {
            get;
        }

        /// <summary>
        /// Gets or sets the name of the track.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets options associated with the current <see cref="Track"/>.
        /// </summary>
        /// <see cref="NSynth.TrackOptions">For a list of available track options.</see>
        public TrackOptions Options
        {
            get
            {
                return this.options;
            }
            set
            {
                this.options = value;
            }
        }

        /// <summary>
        /// Gets or sets the frame rate of the track.
        /// </summary>
        public SampleRate FrameRate
        {
            get
            {
                return this.frameRate;
            }
            set
            {
                this.frameRate = value;
            }
        }

        /// <summary>
        /// Gets or sets the total number of data samples in the track.
        /// </summary>
        public long SampleCount
        {
            get
            {
                return this.sampleCount;
            }
            set
            {
                this.sampleCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of whole data samples in each frame.
        /// </summary>
        public int SamplesPerFrame
        {
            get
            {
                return this.samplesPerFrame;
            }
            set
            {
                this.samplesPerFrame = value;
            }
        }

        /// <summary>
        /// Gets or sets the id of the track relative to the container the track exists in (if applicable).
        /// </summary>
        public int ContainerTrackId { get; set; }
        #endregion
        #region Methods
        public virtual Track DeepClone()
        {
            Contract.Ensures(Contract.Result<Track>() != null);

            var track = this.CreateDeepClone();

            track.Culture = this.Culture;
            track.Delay = this.Delay;
            track.Name = this.Name;
            track.Options = this.Options;
            track.FrameRate = this.FrameRate;
            track.SampleCount = this.SampleCount;
            track.SamplesPerFrame = this.SamplesPerFrame;

            return track;
        }

        protected abstract Track CreateDeepClone();
        #endregion
    }

    /// <summary>
    /// Contains code contracts for the <see cref="Track"/> class. This class cannot be instantiated.
    /// </summary>
    public sealed class _ContractsForTrack : Track
    {

        internal _ContractsForTrack()
        {

        }

        public override TrackKind Kind
        {
            get
            {
                return default(TrackKind);
            }
        }

        protected override Track CreateDeepClone()
        {
            Contract.Ensures(Contract.Result<Track>() != null);

            return default(Track);
        }
    }
}
