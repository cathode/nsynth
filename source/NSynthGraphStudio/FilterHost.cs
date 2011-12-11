/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using NSynth;
using NSynth.Imaging;
using NSynth.Video;

namespace NSynthGraphStudio
{
    /// <summary>
    /// Hosts an NSynth video filter.
    /// </summary>
    public sealed class FilterHost : System.Windows.Controls.Image
    {
        #region Fields
        private Filter filter;
        private WriteableBitmap bitmap;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterHost"/> class.
        /// </summary>
        public FilterHost()
        {
        }
        static FilterHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FilterHost), new FrameworkPropertyMetadata(typeof(FilterHost)));
        }
        #endregion
        #region Properties
        internal Filter Filter
        {
            get
            {
                return this.filter;
            }
            set
            {
                if (this.filter != value)
                {
                    this.filter = value;
                    this.OnFilterChanged(EventArgs.Empty);
                }
            }
        }
        #endregion
        #region Methods
        private void OnFilterChanged(EventArgs e)
        {
            if (this.filter == null)
                return;

            // TODO: Fix this!!!
            //if (this.filter.Clip.VideoTracks.Count == 0)
            //    return;

            // TODO: Fix this!!!
            VideoTrack track = null; //this.filter.Clip.VideoTracks[0];

            double dpi = 96.0;

            if (track.Format == ColorFormat.RGB24)
                this.bitmap = new WriteableBitmap(track.Width, track.Height, dpi, dpi, PixelFormats.Bgr24, null);
            else if (track.Format == ColorFormat.RGB32)
                this.bitmap = new WriteableBitmap(track.Width, track.Height, dpi, dpi, PixelFormats.Bgra32, null);
            else if (track.Format == ColorFormat.RGB)
                this.bitmap = new WriteableBitmap(track.Width, track.Height, dpi, dpi, PixelFormats.Bgra32, null);
            else
                throw new NotImplementedException();

            this.Source = this.bitmap;

            this.DisplayFrame(0);
        }
        public void DisplayFrame(long frameIndex)
        {
            if (this.filter == null)
                return;

            //if (this.cachedBitmap != null)
            //    throw new NotImplementedException();

            //var frame = this.filter.GetFrame(frameIndex);
            //var frameBitmap = frame.Video;

            //this.RefreshCachedBitmap(frameBitmap);
        }

        private unsafe void RefreshCachedBitmap(IBitmap frameBitmap)
        {
            this.bitmap.Lock();
            
            if (frameBitmap is BitmapRGB24)
            {
                var bmp24 = frameBitmap as BitmapRGB24;
                
                fixed (void* ptr = &bmp24.Pixels[0])
                {
                    IntPtr buffer = new IntPtr(ptr);
                    this.bitmap.WritePixels(new Int32Rect(0, 0, bmp24.Width, bmp24.Height), buffer, bmp24.Pixels.Length * 3, bmp24.Width * 3);
                }
               
            }
            else if (frameBitmap is BitmapRGB32)
            {
                var bmp32 = frameBitmap as BitmapRGB32;
                
                fixed (void* ptr = &bmp32.Pixels[0])
                {
                    IntPtr buffer = new IntPtr(ptr);
                    this.bitmap.WritePixels(new Int32Rect(0, 0, bmp32.Width, bmp32.Height), buffer, bmp32.Pixels.Length * sizeof(ColorRGB32), bmp32.Width * 4);
                }
            }
            else
            {
                var bmp = frameBitmap as BitmapRGB;
                var src = bmp.Pixels;
                var pix = new ColorRGB32[bmp.Size.Elements];

                for (int i = 0; i < pix.Length; i++)
                {
                    var p = src[i];
                    pix[i] = new ColorRGB32(p.Red, p.Green, p.Blue, p.Alpha);
                }

                fixed (void* ptr = &pix[0])
                {
                    IntPtr buffer = new IntPtr(ptr);
                    this.bitmap.WritePixels(new Int32Rect(0, 0, bmp.Width, bmp.Height), buffer, bmp.Pixels.Length * sizeof(ColorRGB32), bmp.Width * sizeof(ColorRGB32));
                }
            }

            this.bitmap.AddDirtyRect(new Int32Rect(0, 0, this.bitmap.PixelWidth, this.bitmap.PixelHeight));
            this.bitmap.Unlock();
            this.Dispatcher.Invoke(DispatcherPriority.Render, EmptyAction);
        }

        private static Action EmptyAction = delegate()
        {
        };
        #endregion
    }
}
