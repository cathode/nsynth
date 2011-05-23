/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */

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
