/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
namespace NSynth.Audio
{
    /// <summary>
    /// Represents an audio track comprised of one or more sound channels.
    /// </summary>
    public class AudioTrack : Track
    {
        #region Fields
        /// <summary>
        /// Holds the audio channel data.
        /// </summary>
        private AudioChannel[] channels;

        /// <summary>
        /// Backing field for the <see cref="ChannelMap"/> property.
        /// </summary>
        private ChannelMap channelMap;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AudioTrack"/> class.
        /// </summary>
        /// <remarks>
        /// Assumes a stereo (2-channel, Left and Right) speaker configuration.
        /// </remarks>
        public AudioTrack()
            : this(2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioTrack"/> class.
        /// </summary>
        /// <param name="channels">The number of audio channels in the new <see cref="AudioTrack"/>.</param>
        public AudioTrack(int channels)
        {
            this.channels = new AudioChannel[channels];
            this.channelMap = new ChannelMap(channels);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioTrack"/> class.
        /// </summary>
        /// <param name="channelMap">A <see cref="ChannelMap"/> that specifies the arrangement and
        /// quantity of audio channels in the new <see cref="AudioTrack"/>.</param>
        /// <remarks>
        /// The channel count of the audio track is set to the count of the channel map.
        /// </remarks>
        public AudioTrack(ChannelMap channelMap)
        {
            this.channelMap = channelMap;
            this.channels = new AudioChannel[channelMap.ChannelCount];
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the <see cref="ChannelMap"/> for the current <see cref="AudioTrack"/>.
        /// </summary>
        public ChannelMap ChannelMap
        {
            get
            {
                return this.channelMap;
            }
        }

        /// <summary>
        /// Gets the number of sound channels in the current <see cref="AudioTrack"/>.
        /// </summary>
        public int Channels
        {
            get
            {
                return this.channels.Length;
            }
        }

        /// <summary>
        /// Gets the <see cref="TrackKind"/> of the current <see cref="Track"/>.
        /// Overridden. Returns <see cref="TrackKind.Audio"/>.
        /// </summary>
        public sealed override TrackKind Kind
        {
            get
            {
                return TrackKind.Audio;
            }
        }
        #endregion
        #region Methods
        protected override Track CreateDeepClone()
        {
            var track = new AudioTrack();

            return track;
        }
        #endregion
    }
}
