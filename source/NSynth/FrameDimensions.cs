/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.         *
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
        private int height;

        /// <summary>
        /// Backing field for the <see cref="FrameDimensions.Width"/> property.
        /// </summary>
        private int width;

        /// <summary>
        /// Backing field for the <see cref="FrameDimensions.LeftOffset"/> property.
        /// </summary>
        private int leftOffset;

        /// <summary>
        /// Backing field for the <see cref="FrameDimensions.TopOffset"/> property.
        /// </summary>
        private int topOffset;

        /// <summary>
        /// Backing field for the <see cref="FrameDimensions.RightOffset"/> property.
        /// </summary>
        private int rightOffset;

        /// <summary>
        /// Backing field for the <see cref="FrameDimensions.BottomOffset"/> property.
        /// </summary>
        private int bottomOffset;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FrameDimensions"/> struct.
        /// </summary>
        /// <param name="width">The total and viewable width in pixels of a frame.</param>
        /// <param name="height">The total and viewable height in pixels of a frame.</param>
        public FrameDimensions(int width, int height)
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
        public FrameDimensions(int width, int height, int cleanWidth, int cleanHeight)
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
        public int Height
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
        public int Width
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
        public int CleanHeight
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
        public int CleanWidth
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
        public int LeftOffset
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
        public int RightOffset
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
        public int TopOffset
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
        public int BottomOffset
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