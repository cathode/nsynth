/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Imaging.TIFF
{
    /// <summary>
    /// Represents an Image File Directory in a TIFF bitstream.
    /// </summary>
    public struct TIFFImageFileDirectory
    {
        public ushort DirectoryEntryCount;
        public TIFFField[] Entries;
        public int NextIFDOffset;
    }
}
