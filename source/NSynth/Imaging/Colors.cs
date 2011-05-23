/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */
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
