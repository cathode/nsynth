/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using NSynth.Imaging;

namespace NSynth.Video
{
    /// <summary>
    /// Represents a <see cref="Track"/> implementation containing video content.
    /// </summary>
    public class VideoTrack : Track
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="VideoTrack.Width"/> property.
        /// </summary>
        private Size dimensions;

        /// <summary>
        /// Backing field for the <see cref="VideoTrack.Format"/> property.
        /// </summary>
        private ColorFormat format;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoTrack"/> class.
        /// </summary>
        public VideoTrack()
        {
            this.dimensions = new Size(1920, 1080);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoTrack"/> class.
        /// </summary>
        /// <param name="width">The width, in pixels, of video frames in the new <see cref="VideoTrack"/>.</param>
        /// <param name="height">The height, in pixels, of video frames in the new <see cref="VideoTrack"/>.</param>
        public VideoTrack(int width, int height)
        {
            this.dimensions = new Size(width, height);
        }
        #endregion
        #region Properties
        public Size Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }
        /// <summary>
        /// Gets or sets the width (in pixels) of video frames in the current track.
        /// </summary>
        public int Width
        {
            get
            {
                return this.dimensions.Width;
            }
            set
            {
                this.dimensions = new Size(value, this.dimensions.Height);
            }
        }

        /// <summary>
        /// Gets or sets the height in pixels) of video frames in the current track.
        /// </summary>
        public int Height
        {
            get
            {
                return this.dimensions.Height;
            }
            set
            {
                this.dimensions = new Size(this.dimensions.Width, value);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ColorFormat"/> of the video frames in the track.
        /// </summary>
        public ColorFormat Format
        {
            get
            {
                return this.format;
            }
            set
            {
                this.format = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="TrackKind"/> of the current <see cref="Track"/>.
        /// Overridden. Returns <see cref="TrackKind.Video"/>.
        /// </summary>
        public sealed override TrackKind Kind
        {
            get
            {
                return TrackKind.Video;
            }
        }
        #endregion

        
    }
}
