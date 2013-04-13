/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using NSynth.Imaging;
using System.Diagnostics.Contracts;

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
            this.format = ColorFormat.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoTrack"/> class.
        /// </summary>
        /// <param name="width">The width, in pixels, of video frames in the new <see cref="VideoTrack"/>.</param>
        /// <param name="height">The height, in pixels, of video frames in the new <see cref="VideoTrack"/>.</param>
        public VideoTrack(int width, int height)
        {
            Contract.Requires(width >= 0);
            Contract.Requires(height >= 0);

            this.dimensions = new Size(width, height);
            this.format = ColorFormat.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        public VideoTrack(IBitmap bitmap)
        {
            this.dimensions = new Size(bitmap.Width, bitmap.Height);
            this.format = bitmap.Format;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the size of video frames in the track.
        /// </summary>
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
                Contract.Requires(value >= 0);

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
                Contract.Requires(value >= 0);

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
        #region Methods
        protected override Track CreateDeepClone()
        {
            var track = new VideoTrack();
            track.Dimensions = this.Dimensions;
            track.Format = this.Format;

            return track;
        }
        [ContractInvariantMethod]
        private void _Invariants()
        {
        }
        #endregion

        
    }
}
