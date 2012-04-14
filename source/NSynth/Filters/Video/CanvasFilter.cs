/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using NSynth;
using NSynth.Imaging;

namespace NSynth.Filters.Internal.Video
{
    /// <summary>
    /// Represents a process action that adjusts the frame size without
    /// resizing. This process can be used to crop the input frame, or to
    /// extend the frame size by filling the added space with the FillColor.
    /// </summary>
    public class CanvasFilter : ProcessFilterBase
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="FillColor"/> property.
        /// </summary>
        private IColor fillColor;

        /// <summary>
        /// Backing field for the <see cref="Adjustment"/> property.
        /// </summary>
        private Rectangle adjustment;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasFilter"/>
        /// class.
        /// </summary>
        public CanvasFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasFilter"/> class.
        /// </summary>
        /// <param name="fillColor">A <see cref="IColor"/> that is used to fill area created by expanding the canvas.</param>
        public CanvasFilter(IColor fillColor)
        {
            this.fillColor = fillColor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasFilter"/> class.
        /// </summary>
        /// <param name="adjustment">A <see cref="Rectangle"/> that is used to determine how the edges of the frame are modified.</param>
        public CanvasFilter(Rectangle adjustment)
        {
            this.adjustment = adjustment;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasFilter"/> class.
        /// </summary>
        /// <param name="adjustment">A <see cref="Rectangle"/> that is used to determine how the edges of the frame are modified.</param>
        /// <param name="fillColor">A <see cref="IColor"/> that is used to fill area created by expanding the canvas.</param>
        public CanvasFilter(Rectangle adjustment, IColor fillColor)
        {
            this.adjustment = adjustment;
            this.fillColor = fillColor;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets a <see cref="Rectangle"/> that determines how frames are canvassed. Negative values make the resulting frame smaller
        /// while positive values make the resulting frame larger.
        /// </summary>
        public Rectangle Adjustment
        {
            get
            {
                return this.adjustment;
            }
            set
            {
                this.adjustment = value;
            }
        }

        /// <summary>
        /// Gets or sets the color used to fill in pixels when expanding the frame size.
        /// </summary>
        public IColor FillColor
        {
            get
            {
                return this.fillColor;
            }
            set
            {
                this.fillColor = value;
            }
        }
        #endregion
        #region Methods
        public override Clip GetClip()
        {
            Clip clip = new Clip();

            return clip;
        }

        /// <summary>
        /// Overridden. Renders the frame with the specified index.
        /// </summary>
        /// <param name="frameIndex">The zero-based index of the frame to retreive.</param>
        /// <returns>The frame with the specified index.</returns>
        protected override Frame RenderFrame(long frameIndex)
        {
            if (this.Input == null)
                return null;

            var frame = this.Input.GetFrame(frameIndex);

            if (this.Adjustment == Rectangle.Empty)
                return frame; // No modification necessary.

            return frame;
        }
        #endregion
    }
}
