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
    public class HandlerBox : FullBox
    {
        
        public HandlerBox()
            : base(BoxTypes.Handler, 0, 0)
        {
            
        }


        public uint PreDefined { get; set; }

        public uint HandlerType { get; set; }

        // Reserve 12 bytes here.

        public string Name { get; set; }
    }
}
