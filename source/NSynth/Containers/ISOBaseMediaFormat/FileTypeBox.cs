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

namespace NSynth.Containers.ISOBaseMediaFormat
{
    [BoxType(BoxTypes.FileType)]
    public class FileTypeBox : Box
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileTypeBox"/> class.
        /// </summary>
        public FileTypeBox()
            : base(BoxTypes.FileType)
        {


        }

        public FileTypeBox(int majorBrand, int minorVersion)
            : base(BoxTypes.FileType)
        {

        }
        public int MajorBrand
        {
            get;
            set;
        }

        public int MinorVersion
        {
            get;
            set;
        }

        public int[] CompatibleBrands
        {
            get;
            set;
        }
    }
}
