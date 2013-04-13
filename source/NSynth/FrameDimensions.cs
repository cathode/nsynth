/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;

namespace NSynth
{
    /// <summary>
    /// Represents dimensions of a video frame.
    /// </summary>
    public struct FrameDimensions
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="FrameDimensions.Height"/> property.
        /// </summary>
        private uint height;

        /// <summary>
        /// Backing field for the <see cref="FrameDimensions.Width"/> property.
        /// </summary>
        private uint width;

        /// <summary>
        /// Backing field for the <see cref="FrameDimensions.LeftOffset"/> property.
        /// </summary>
        private uint leftOffset;

        /// <summary>
        /// Backing field for the <see cref="FrameDimensions.TopOffset"/> property.
        /// </summary>
        private uint topOffset;

        /// <summary>
        /// Backing field for the <see cref="FrameDimensions.RightOffset"/> property.
        /// </summary>
        private uint rightOffset;

        /// <summary>
        /// Backing field for the <see cref="FrameDimensions.BottomOffset"/> property.
        /// </summary>
        private uint bottomOffset;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FrameDimensions"/> struct.
        /// </summary>
        /// <param name="width">The total and viewable width in pixels of a frame.</param>
        /// <param name="height">The total and viewable height in pixels of a frame.</param>
        public FrameDimensions(uint width, uint height)
        {
            this.width = width;
            this.height = height;
            this.leftOffset = 0;
            this.topOffset = 0;
            this.rightOffset = 0;
            this.bottomOffset = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameDimensions"/> struct.
        /// </summary>
        /// <param name="width">The total width in pixels of a frame.</param>
        /// <param name="height">The total height in pixels of a frame.</param>
        /// <param name="cleanWidth">The viewable width in pixels of a frame.</param>
        /// <param name="cleanHeight">The viewable height in pixels of a frame.</param>
        public FrameDimensions(uint width, uint height, uint cleanWidth, uint cleanHeight)
        {
            if (cleanWidth > width)
                throw new ArgumentException();
            else if (cleanHeight > height)
                throw new ArgumentException();

            this.width = width;
            this.height = height;

            var xd = width - cleanWidth;
            var yd = height - cleanHeight;

            this.rightOffset = xd / 2;
            this.leftOffset = xd - this.rightOffset;
            this.bottomOffset = yd / 2;
            this.topOffset = yd - this.bottomOffset;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the total height in pixels of a frame.
        /// </summary>
        public uint Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        /// <summary>
        /// Gets or sets the total width in pixels of a frame.
        /// </summary>
        public uint Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets the viewable height in pixels of a frame.
        /// </summary>
        public uint CleanHeight
        {
            get
            {
                return this.height - this.topOffset - this.bottomOffset;
            }
            set
            {
                if (value > this.Height)
                    throw new ArgumentException();

                var yd = this.Height - value;
                this.bottomOffset = yd / 2;
                this.topOffset = yd - this.bottomOffset;
            }
        }

        /// <summary>
        /// Gets or sets the viewable width in pixels of a frame.
        /// </summary>
        public uint CleanWidth
        {
            get
            {
                return this.width - this.leftOffset - this.rightOffset;
            }
            set
            {
                if (value > this.Width)
                    throw new ArgumentException();

                var xd = this.Width - value;
                this.rightOffset = xd / 2;
                this.leftOffset = xd - this.RightOffset;
            }
        }

        /// <summary>
        /// Gets or sets the number of pixels on the left edge that are not part of the clean frame.
        /// </summary>
        public uint LeftOffset
        {
            get
            {
                return this.leftOffset;
            }
            set
            {
                if (value > (this.Width - this.RightOffset))
                    throw new ArgumentException();

                this.leftOffset = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of pixels on the right edge that are not part of the clean frame.
        /// </summary>
        public uint RightOffset
        {
            get
            {
                return this.rightOffset;
            }
            set
            {
                if (value > (this.Width - this.LeftOffset))
                    throw new ArgumentException();

                this.rightOffset = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of pixels on the top edge that are not part of the clean frame size.
        /// </summary>
        public uint TopOffset
        {
            get
            {
                return this.topOffset;
            }
            set
            {
                if (value > (this.Height - this.BottomOffset))
                    throw new ArgumentException();

                this.topOffset = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of pixels on the bottom edge that are not part of the clean frame size.
        /// </summary>
        public uint BottomOffset
        {
            get
            {
                return this.bottomOffset;
            }
            set
            {
                if (value > (this.Height - this.TopOffset))
                    throw new ArgumentException();

                this.bottomOffset = value;
            }
        }
        #endregion
    }
}