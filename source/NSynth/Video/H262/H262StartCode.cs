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

namespace NSynth.Video.H262
{
    public enum H262StartCode : byte
    {
        Picture = 0x00,
        Slice = 0x01,
        UserData = 0xB2,
        SequenceHeader = 0xB3,
        SequenceError=0xB4,
        ExtensionStart = 0xB5,
        SequenceEnd = 0xB7,
        GroupStart = 0xB8,
    }
}
