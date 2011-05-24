/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace NSynth.Video.Dirac
{
    /// <summary>
    /// Represents supported values for the state variable "PARSE_CODE".
    /// </summary>
    [Flags]
    public enum DiracParseCode : byte
    {
        GenericSequenceHeader = 0x00,
        GenericEndOfSequence = 0x10,
        GenericAuxiliaryData = 0x20,
        GenericPaddingData = 0x30,

        CoreIntraReferencePicture = 0x0C,
        CoreIntraNonReferencePicture = 0x08,
        CoreIntraReferencePictureNonCoded = 0x4C,
        CoreIntraNonReferencePictureNonCoded = 0x48,
        CoreInterReferencePictureSingle = 0x0D,
        CoreInterReferencePictureDouble = 0x0E,
        CoreInterNonReferencePictureSingle = 0x09,
        CoreInterNonReferencePictureDouble = 0x0A,

        LowDelayIntraReferencePicture = 0xCC,
        LowDelayIntraNonReferencePicture = 0xC8,
    }
}
