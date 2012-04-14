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
    /// Provides a resizing filter.
    /// </summary>
    public class Resize : ProcessFilterBase
    {
        #region Fields
        /// <summary>
        /// Backing field for the <see cref="TargetSize"/> property.
        /// </summary>
        private Size targetSize;

        /// <summary>
        /// Backing field for the <see cref="Algorithm"/> property.
        /// </summary>
        private ResizeMethod method;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Resize"/> class.
        /// </summary>
        public Resize()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resize"/> class
        /// with the specified <see cref="NSynth.Imaging.Size"/>.
        /// </summary>
        /// <param name="size"></param>
        public Resize(Size targetSize)
        {
            this.targetSize = targetSize;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NSynth.Filters.Internal.Video.Resize"/> class
        /// with the specified <see cref="NSynth.Filters.Internal.Video.Algorithm"/>.
        /// </summary>
        /// <param name="method"></param>
        public Resize(ResizeMethod method)
        {
            this.method = method;
        }

        public Resize(Size targetSize, ResizeMethod method)
        {
            this.targetSize = targetSize;
            this.method = method;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the output size of resized frames.
        /// </summary>
        public Size TargetSize
        {
            get
            {
                return this.targetSize;
            }
            set
            {
                this.targetSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="NSynth.Filters.Internal.Video.Algorithm"/> that determines
        /// which resizing algorithm will be used.
        /// </summary>
        public ResizeMethod Algorithm
        {
            get
            {
                return this.method;
            }
            set
            {
                this.method = value;
            }
        }
        #endregion
        #region Methods
        public override Clip GetClip()
        {
            throw new NotImplementedException();
        }

        protected override Frame RenderFrame(long frameIndex)
        {
            if (this.IsDisposed)
                throw new ObjectDisposedException(this.GetType().Name);

            var frame = this.Input.GetFrame(frameIndex);

            

            return frame;
        }

        private IBitmap ResizeBilinear(IBitmap input)
        {
            throw new NotImplementedException();
        }

        private IBitmap ResizeTrilinear(IBitmap input)
        {
            throw new NotImplementedException();
        }

        private IBitmap ResizeBicubic(IBitmap input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs nearest-neighbor resizing.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private IBitmap ResizeNearestNeighbor(IBitmap input)
        {
            if (input is BitmapCMYK)
                return this.ResizeNearestNeighborCMYK((BitmapCMYK)input);
            else if (input is BitmapLAB)
                return this.ResizeNearestNeighborLAB((BitmapLAB)input);
            else if (input is BitmapRGB)
                return this.ResizeNearestNeighborRGB((BitmapRGB)input);
            else if (input is BitmapYCC)
                return this.ResizeNearestNeighborYCC((BitmapYCC)input);
            else
                throw new NotImplementedException();
        }

        /// <summary>
        /// Performs nearest-neighbor resizing on a CMYK bitmap.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private BitmapCMYK ResizeNearestNeighborCMYK(BitmapCMYK input)
        {
            // Calculate horizontal ratio of input:output
            double rX = input.Width / (float)Math.Max(this.TargetSize.Width, 1);
            // Calculate vertical ratio of input:output
            double rY = input.Height / (float)Math.Max(this.TargetSize.Height, 1);

            if (rX == 0.0 && rY == 0.0)
                return input; // No scaling necessary.

            BitmapCMYK output = new BitmapCMYK(this.TargetSize);

            for (int y = 0; y < this.TargetSize.Height; y++)
                for (int x = 0; x < this.TargetSize.Width; x++)
                    output[x, y] = input[(int)Math.Floor(x * rX), (int)Math.Floor(y * rY)];

            return output;
        }

        /// <summary>
        /// Performs nearest-neighbor resizing on a LAB bitmap.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private BitmapLAB ResizeNearestNeighborLAB(BitmapLAB input)
        {
            // Calculate horizontal ratio of input:output
            double rX = input.Width / (float)Math.Max(this.TargetSize.Width, 1);
            // Calculate vertical ratio of input:output
            double rY = input.Height / (float)Math.Max(this.TargetSize.Height, 1);

            if (rX == 0.0 && rY == 0.0)
                return input; // No scaling necessary.

            BitmapLAB output = new BitmapLAB(this.TargetSize);

            for (int y = 0; y < this.TargetSize.Height; y++)
                for (int x = 0; x < this.TargetSize.Width; x++)
                    output[x, y] = input[(int)Math.Floor(x * rX), (int)Math.Floor(y * rY)];

            return output;
        }

        /// <summary>
        /// Performs nearest-neighbor resizing on a RGB bitmap.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private BitmapRGB ResizeNearestNeighborRGB(BitmapRGB input)
        {
            // Calculate horizontal ratio of input:output
            double rX = input.Width / (float)Math.Max(this.TargetSize.Width, 1);
            // Calculate vertical ratio of input:output
            double rY = input.Height / (float)Math.Max(this.TargetSize.Height, 1);

            if (rX == 0.0 && rY == 0.0)
                return input; // No scaling necessary.

            BitmapRGB output = new BitmapRGB(this.TargetSize);

            for (int y = 0; y < this.TargetSize.Height; y++)
                for (int x = 0; x < this.TargetSize.Width; x++)
                    output[x, y] = input[(int)Math.Floor(x * rX), (int)Math.Floor(y * rY)];

            return output;
        }

        /// <summary>
        /// Performs nearest-neighbor resizing on a YCC bitmap.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private BitmapYCC ResizeNearestNeighborYCC(BitmapYCC input)
        {
            // Calculate horizontal ratio of input:output
            double rX = input.Width / (float)Math.Max(this.TargetSize.Width, 1);
            // Calculate vertical ratio of input:output
            double rY = input.Height / (float)Math.Max(this.TargetSize.Height, 1);

            if (rX == 0.0 && rY == 0.0)
                return input; // No scaling necessary.

            BitmapYCC output = new BitmapYCC(this.TargetSize);

            for (int y = 0; y < this.TargetSize.Height; y++)
                for (int x = 0; x < this.TargetSize.Width; x++)
                    output[x, y] = input[(int)Math.Floor(x * rX), (int)Math.Floor(y * rY)];

            return output;
        }
        #endregion
    }
}
