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
    public sealed class BoxTypeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoxTypeAttribute"/> class.
        /// </summary>
        /// <param name="type"></param>
        public BoxTypeAttribute(uint type)
        {
            this.Type = type;
        }

        public uint Type { get; private set; }
    }
}
