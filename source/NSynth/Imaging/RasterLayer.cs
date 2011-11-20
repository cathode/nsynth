/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents an layer of visual data in an image, described by a grid of color values.
    /// </summary>
    public class RasterLayer : Layer
    {
        #region Fields
        private IBitmap content;
        #endregion
    }
}
