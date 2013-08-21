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
    public sealed class BoxFieldAttribute : Attribute
    {
        public BoxFieldAttribute()
        {

        }

        /// <summary>
        /// Gets or sets the version of the box that the field applies to.
        /// </summary>
        public byte Version { get; set; }



    }
}
