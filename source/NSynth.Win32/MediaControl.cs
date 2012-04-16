/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NSynth.Win32
{
    /// <summary>
    /// Provides a windows forms control that renders media content.
    /// </summary>
    public class MediaControl : Control
    {
        public IFrameSource Source { get; set; }
    }
}
