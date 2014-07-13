/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
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
            var tgaSource = new TGASourceFilter(path);
            tgaSource.MultiFrame = false;
            tgaSource.InitializeClip();

            //var blur = new BlurFilter(1);
            //blur.Source.Bind(tgaSource);

            //var flip = new FlipFilter()
            //{
            //    FlipDirection = FlipDirection.Horizontal
            //};
            ////flip.Input.Bind(filter);
            //blur.Initialize();

            //flip.Initialize();
            //this.host.Filter = flip;
            this.host.Filter = tgaSource;
            int n = 300;


            this.host.DisplayFrame(0);


            sw.Stop();
            this.Title = string.Format("NSynth Graph Studio -- Sample displayed in {0}ms", sw.ElapsedMilliseconds);
        }

        private void ShowPNGSample(object sender, EventArgs e)
        {
            var path = ((MenuItem)sender).Tag as string;

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            var filter = new NSynth.Imaging.PNG.PNGSourceFilter(path);
            filter.InitializeClip();
            this.host.Filter = filter;

            this.host.DisplayFrame(0);
            sw.Stop();
            this.Title = string.Format("NSynth Graph Studio -- Sample displayed in {0}ms", sw.ElapsedMilliseconds);
        }

        private void MenuItemOpenItem_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.Filter = "All media files | *.*";

            var result = dlg.ShowDialog();

            if (result.Value)
            {
                var codec = Codecs.BestMatch(dlg.FileName);

                if (codec != null)
                {
                    var decoder = codec.CreateDecoder();

                    using (var stream = File.Open(dlg.FileName, FileMode.Open, FileAccess.Read))
                    {
                        decoder.Open(stream);
                    }
                }
            }
        }

        private void MenuItemFileExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        #endregion


    }
}
