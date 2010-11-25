/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved. */

namespace NSynth.Imaging.TIFF
{
    /// <summary>
    /// Enumerates supported TIFF tags.
    /// </summary>
    public enum TIFFTag
    {
        /// <summary>
        /// A TIFF Field with this tag holds the artist/author of the image.
        /// </summary>
        Artist = 0x013B,

        /// <summary>
        /// A TIFF Field with this tag indicates the number of bits per color component.
        /// </summary>
        BitsPerSample = 0x0102,

        /// <summary>
        /// A TIFF Field with this tag holds the length of the dithering/halftoning matrix used to create a dithered or halftoned bilevel image.
        /// </summary>
        CellLength = 0x0109,

        /// <summary>
        /// A TIFF Field with this tag holds the width of the dithering/halftoning matrix used to create a dithered or halftoned bilevel image.
        /// </summary>
        CellWidth = 0x0108,

        /// <summary>
        /// A TIFF Field with this tag holds the color map for palette-based images.
        /// </summary>
        ColorMap = 0x0140,

        /// <summary>
        /// A TIFF Field with this tag holds the compression scheme used on the image data.
        /// </summary>
        Compression = 0x0103,

        /// <summary>
        /// A TIFF Field with this tag holds the copyright notice for the image.
        /// </summary>
        Copyright = 0x8298,

        /// <summary>
        /// A TIFF Field with this tag holds the date and time that the image was captured or created.
        /// </summary>
        DateTime = 0x0132,

        /// <summary>
        /// A TIFF Field with this tag holds a description of extra color components.
        /// </summary>
        ExtraSamples = 0x0152,

        /// <summary>
        /// A TIFF Field with this tag holds the logical order of bits within a byte.
        /// </summary>
        FillOrder = 0x010A,

        /// <summary>
        /// A TIFF Field with this tag holds, for each block of contiguous unused bytes in the TIFF bitstream, the number of bytes in that block.
        /// </summary>
        FreeByteCounts = 0x0121,

        /// <summary>
        /// A TIFF Field with this tag holds, for each block of contiguous unused bytes in the TIFF bitstream, the offset of the first byte in that block.
        /// </summary>
        FreeOffsets = 0x0120,

        /// <summary>
        /// A TIFF Field with this tag holds, for grayscale data, the optical density of each possible pixel value.
        /// </summary>
        GrayResponseCurve = 0x0123,

        /// <summary>
        /// A TIFF Field with this tag holds the precision of the information contained in a GrayResponseCurve-tagged field.
        /// </summary>
        GrayResponseUnit = 0x0122,

        /// <summary>
        /// A TIFF Field with this tag holds a description of the computer and/or operating system in use at the time of image creation.
        /// </summary>
        HostComputer = 0x013C,

        /// <summary>
        /// A TIFF Field with this tag holds a user description of the image.
        /// </summary>
        ImageDescription = 0x010E,

        /// <summary>
        /// A TIFF Field with this tag holds the number of rows of pixels in the image.
        /// </summary>
        ImageLength = 0x0101,

        /// <summary>
        /// A TIFF Field with this tag holds the number of columns of pixels in the image.
        /// </summary>
        ImageWidth = 0x0100,

        /// <summary>
        /// A TIFF Field with this tag holds the manufacturer of the hardware device that originally generated the TIFF bitstream.
        /// </summary>
        Make = 0x010F,

        /// <summary>
        /// A TIFF Field with this tag holds the maximum component value used for a color component.
        /// </summary>
        MaxSampleValue = 0x0119,

        /// <summary>
        /// A TIFF Field with this tag holds the minimum component value used for a color component.
        /// </summary>
        MinSampleValue = 0x0118,

        /// <summary>
        /// A TIFF Field with this tag holds the model name or number of the hardware device that originally generated the TIFF bitstream.
        /// </summary>
        Model = 0x0110,

        /// <summary>
        /// A TIFF Field with this tag holds a general indication of the kind of data contained in a TIFF subfile.
        /// </summary>
        NewSubfileType = 0x00FE,

        /// <summary>
        /// A TIFF Field with this tag holds the orientation of the image with respect to rows and columns.
        /// </summary>
        Orientation = 0x0112,

        /// <summary>
        /// A TIFF Field with this tag holds the color space of the image data.
        /// </summary>
        PhotometricInterpretation = 0x0106,

        /// <summary>
        /// A TIFF Field with this tag describes how the components of each pixel are stored.
        /// </summary>
        PlanarConfiguration = 0x011C,
       
        /// <summary>
        /// A TIFF Field with this tag describes the relationship between pixel dimensions of the image and print/display dimensions.
        /// </summary>
        ResolutionUnit = 0x0128,

        /// <summary>
        /// A TIFF Field with this tag holds the number of rows per strip.
        /// </summary>
        RowsPerStrip = 0x0116,

        /// <summary>
        /// A TIFF Field with this tag holds the number of components per pixel.
        /// </summary>
        SamplesPerPixel = 0x0115,

        /// <summary>
        /// A TIFF Field with this tag holds the name and version number of the software used to create the image.
        /// </summary>
        Software = 0x0131,

        /// <summary>
        /// A TIFF Field with this tag holds, for each strip, the number of bytes in the strip (after compression is applied).
        /// </summary>
        StripByteCounts = 0x0117,

        /// <summary>
        /// A TIFF Field with this tag holds, for each strip, the byte offset of the strip.
        /// </summary>
        StripOffsets = 0x0111,

        /// <summary>
        /// A TIFF Field with this tag holds a general indication of the kind of data contained in a TIFF subfile.
        /// </summary>
        SubfileType = 0x00FF,

        /// <summary>
        /// A TIFF Field with this tag holds, for bilevel TIFF images that represent shades of gray, the technique that was
        /// used to downsample from gray to bilevel.
        /// </summary>
        Threshholding = 0x0107,

        /// <summary>
        /// The number of pixels per resolution unit, horizontally.
        /// </summary>
        XResolution = 0x011A,

        /// <summary>
        /// The number of pixels per resolution unit, vertically.
        /// </summary>
        YResolution = 0x011B,
    }
}
