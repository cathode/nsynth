/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using NSynth.Imaging.TGA;
using NSynth.Filters.Video;
using NSynth.Imaging.VectorDrawing;
using NSynth;
using NSynth.Imaging;

namespace NSynthGraphStudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors
        public MainWindow()
        {
            InitializeComponent();

            if (Directory.Exists("Samples"))
            {
                var sampleMenu = new MenuItem()
                {
                    Header = "Samples"
                };
                if (Directory.Exists("./Samples/TGA"))
                {
                    var tgaMenu = new MenuItem()
                    {
                        Header = "Truevision TGA"
                    };
                    foreach (string file in Directory.GetFiles("./Samples/TGA"))
                    {
                        string fullPath = System.IO.Path.GetFullPath(file);
                        var tgaItem = new MenuItem()
                        {
                            Header = System.IO.Path.GetFileName(fullPath),
                            Tag = fullPath
                        };
                        tgaItem.Click += new RoutedEventHandler(this.ShowTGASample);
                        tgaMenu.Items.Add(tgaItem);
                    }
                    if (tgaMenu.Items.Count > 0)
                        sampleMenu.Items.Add(tgaMenu);
                }
                if (Directory.Exists("./Samples/PNG"))
                {
                    var pngMenu = new MenuItem()
                    {
                        Header = "PNG"
                    };
                    foreach (string file in Directory.GetFiles("./Samples/PNG"))
                    {
                        string fullPath = System.IO.Path.GetFullPath(file);
                        var pngItem = new MenuItem()
                        {
                            Header = System.IO.Path.GetFileName(fullPath),
                            Tag = fullPath
                        };
                        pngItem.Click += new RoutedEventHandler(this.ShowPNGSample);
                        pngMenu.Items.Add(pngItem);
                    }
                    if (pngMenu.Items.Count > 0)
                        sampleMenu.Items.Add(pngMenu);
                }
                if (Directory.Exists("./Samples/Dirac"))
                {
                    var drcMenu = new MenuItem()
                    {
                        Header = "Dirac"
                    };
                    foreach (string file in Directory.GetFiles("./Samples/Dirac"))
                    {
                        string fullPath = System.IO.Path.GetFullPath(file);
                        var drcItem = new MenuItem()
                        {
                            Header = System.IO.Path.GetFileName(fullPath),
                            Tag = fullPath
                        };
                        drcItem.Click += new RoutedEventHandler(this.ShowDiracSample);
                        drcMenu.Items.Add(drcItem);
                    }
                    if (drcMenu.Items.Count > 0)
                        sampleMenu.Items.Add(drcMenu);
                }
                if (sampleMenu.Items.Count > 0)
                    this.mainMenu.Items.Add(sampleMenu);
            }

        }


        #endregion
        #region Methods
        void ShowDiracSample(object sender, RoutedEventArgs e)
        {
            var path = ((MenuItem)sender).Tag as string;
            //var filter = new DiracSourceFilter(System.IO.Path.GetFullPath(path));
            //this.host.Filter = filter;
        }

        private void ShowTGASample(object sender, EventArgs e)
        {
            var path = ((MenuItem)sender).Tag as string;

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var filter = new TGASourceFilter(path);
            filter.Initialize();
            this.host.Filter = filter;
            sw.Stop();
            this.Title = string.Format("NSynth Graph Studio -- Sample displayed in {0}ms", sw.ElapsedMilliseconds);
        }

        private void ShowPNGSample(object sender, EventArgs e)
        {
            var path = ((MenuItem)sender).Tag as string;

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            var filter = new NSynth.Imaging.PNG.PNGSourceFilter(path);
            filter.Initialize();
            this.host.Filter = filter;

            sw.Stop();
            this.Title = string.Format("NSynth Grap Studio -- Sample displayed in {0}ms", sw.ElapsedMilliseconds);
        }
        private void MenuItemFileExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        #endregion

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.host.Filter = new SplineTestFilter();
        }

        internal sealed class SplineTestFilter : Filter
        {
            internal SplineTestFilter()
            {
                this.Clip = new Clip(new NSynth.Video.VideoTrack(512, 512)
                {
                    Format = NSynth.Imaging.ColorFormat.RGB24
                });
            }
            public override NSynth.Frame Render(long frameIndex)
            {
                var frame = this.Clip.NewFrame();
                var spline = new BCurve(new Pointf(0f, 0f),
                    new Pointf(0f, 0.8f),
                    new Pointf(1f, 0.3f),
                    new Pointf(1f, 0.4f),
                    new Pointf(.7f, 1f),
                    new Pointf(.4f, 0f),
                    new Pointf(.9f, .9f));
                var pix = new BitmapRGB24(512, 512);

                pix.Fill(new ColorRGB24(0, 0, 0));

                for (int i = 0; i < 2048; i++)
                {
                    var p = spline.Sample(i / 2047f);
                    pix[(int)(p.X * 511), (int)(p.Y * 511)] = new ColorRGB24(255, 255, 255);

                }

                frame.Video[0] = pix;

                return frame;
            }
        }
    }
}
