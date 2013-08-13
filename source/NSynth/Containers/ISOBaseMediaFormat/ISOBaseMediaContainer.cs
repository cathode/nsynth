/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    /// <summary>
    /// Provides an implementation of the ISO Base Media Format
    /// </summary>
    public class ISOBaseMediaContainer
    {
        private string path;
        public ISOBaseMediaContainer(string path)
        {
            this.path = path;
        }

        public void ExtractBoxes(string outputPath)
        {
            using (var inStream = File.OpenRead(this.path))
            {
                using (var outStream = File.Open(outputPath, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    var rbuf = new byte[4096];
                    int position = 0;




                }
            }
        }
    }
}
