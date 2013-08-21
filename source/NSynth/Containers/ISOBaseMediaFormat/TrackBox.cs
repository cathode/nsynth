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
    /// <summary>
    /// Provides a container box for a single track within a presentation. Typically any given presentation is made up of multiple such tracks.
    /// </summary>
    [BoxType(BoxTypes.Track)]
    public class TrackBox : Box
    {
        public TrackBox()
            : base(BoxTypes.Track)
        {

        }
    }
}
