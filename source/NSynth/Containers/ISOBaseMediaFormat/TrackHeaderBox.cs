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
    [BoxType(BoxTypes.TrackHeader)]
    public class TrackHeaderBox : Box
    {
        public TrackHeaderBox()
            : base(BoxTypes.TrackHeader)
        {

        }

        // Version 1


        public ulong CreationTime
        {
            get;
            set;
        }

        public ulong ModificationTime
        {
            get;
            set;
        }

        public uint TrackId
        {
            get;
            set;
        }

        public ulong Duration
        {
            get;
            set;
        }

        public short Layer
        {
            get;
            set;
        }

        public short AlternateGroup
        {
            get;
            set;
        }

        public short Volume
        {
            get;
            set;
        }

        public ushort Reserved
        {
            get;
            set;
        }

        public int[] UnityMatrix { get; set; }

        public uint Width { get; set; }

        public uint Height { get; set; }
    }
}
