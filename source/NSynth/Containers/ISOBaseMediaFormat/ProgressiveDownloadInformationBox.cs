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
    [BoxType(BoxTypes.ProgressiveDownloadInformation)]
    public class ProgressiveDownloadInformationBox : FullBox
    {
        public ProgressiveDownloadInformationBox()
            : base(BoxTypes.ProgressiveDownloadInformation, 0)
        {

        }

        public ProgressiveDownloadInfoChunk[] Data
        {
            get;
            set;
        }

        public struct ProgressiveDownloadInfoChunk
        {
            public uint Rate;
            public uint InitialDelay;
        }
    }
}
