/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Audio
{
    /// <summary>
    /// Represents a mapping of speaker positions to the channel numbers in an audio track.
    /// </summary>
    public class ChannelMap
    {
        #region Fields
        /// <summary>
        /// Holds the channel mapping data.
        /// </summary>
        private readonly Speaker[] speakers;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelMap"/> class.
        /// </summary>
        /// <param name="channels">The number of channels to map.</param>
        public ChannelMap(int channels)
        {
            this.speakers = new Speaker[channels];
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets a <see cref="ChannelMap"/> that describes the common channel mapping for single-channel audio.
        /// </summary>
        public static ChannelMap Mono
        {
            get
            {
                var map = new ChannelMap(1);
                map[0] = Speaker.All;

                return map;
            }
        }

        /// <summary>
        /// Gets a <see cref="ChannelMap"/> that describes the common channel mapping used for 2-channel audio.
        /// </summary>
        public static ChannelMap Stereo
        {
            get
            {
                var map = new ChannelMap(2);
                map[0] = Speaker.Left;
                map[1] = Speaker.Right;

                return map;
            }
        }

        /// <summary>
        /// Gets a <see cref="NSynth.Audio.ChannelMap"/> that describes the channel mapping used by FLAC and WMA for 5.1 (6-channel) audio.
        /// </summary>
        public static ChannelMap Surround6FLAC
        {
            get
            {
                var map = new ChannelMap(6);
                map[0] = Speaker.Front | Speaker.Left;
                map[1] = Speaker.Front | Speaker.Right;
                map[2] = Speaker.Front | Speaker.Center;
                map[3] = Speaker.Front | Speaker.LowFrequency;
                map[4] = Speaker.Rear | Speaker.Left;
                map[5] = Speaker.Rear | Speaker.Right;
                return map;
            }
        }

        /// <summary>
        /// Gets a <see cref="NSynth.Audio.ChannelMap"/> that describes the channel mapping used by DTS and AAC for 7.1 (8-channel) audio.
        /// </summary>
        public static ChannelMap Surround8DTS
        {
            get
            {
                var map = new ChannelMap(8);

                map[0] = Speaker.Center;
                map[1] = Speaker.Front | Speaker.Left;
                map[2] = Speaker.Front | Speaker.Right;
                map[3] = Speaker.Side | Speaker.Left;
                map[4] = Speaker.Side | Speaker.Right;
                map[5] = Speaker.LowFrequency;
                map[6] = Speaker.Rear | Speaker.Left;
                map[7] = Speaker.Rear | Speaker.Right;

                return map;
            }
        }

        /// <summary>
        /// Gets the number of mapped channels.
        /// </summary>
        public int ChannelCount
        {
            get
            {
                return this.speakers.Length;
            }
        }
        #endregion
        #region Indexers
        /// <summary>
        /// Gets or sets the <see cref="Speaker"/> configuration that is mapped to the specified channel index.
        /// </summary>
        /// <param name="index">The index of the channel to get or set the mapping for.</param>
        /// <returns>The <see cref="Speaker"/> configuration that is mapped to the specified channel index.</returns>
        public Speaker this[int index]
        {
            get
            {
                return this.speakers[index];
            }
            set
            {
                this.speakers[index] = value;
            }
        }
        #endregion
    }
}
