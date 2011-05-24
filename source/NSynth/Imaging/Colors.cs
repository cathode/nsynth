/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;

using System.Text;

namespace NSynth.Imaging
{
    public static class Colors
    {
        public static IColor Black
        {
            get
            {
                return new ColorRGB24(0, 0, 0);
            }
        }
        public static IColor White
        {
            get
            {
                return new ColorRGB24(255, 255, 255);
            }
        }
    }
}
