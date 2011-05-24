/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using NSynth.Imaging.TGA;

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

            var filter = new TGASourceFilter();

            this.host.Filter = filter;
        }
        private void MenuItemFileExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        #endregion
    }
}
