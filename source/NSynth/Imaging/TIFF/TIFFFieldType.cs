/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved. */

namespace NSynth.Imaging.TIFF
{
    /// <summary>
    /// Represents defined TIFF field types.
    /// </summary>
    /// <remarks>
    /// The defined values in this enumeration include values newly defined in version 6.0 of the TIFF specification.
    /// TIFF files using a format prior to version 6.0 will only use the first 5 defined values (BYTE, ASCII, SHORT, LONG, RATIONAL).
    /// </remarks>
    public enum TIFFFieldType
    {
        /// <summary>
        /// Represents an invalid value.
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// 8-bit unsigned integer.
        /// </summary>
        Byte = 1,

        /// <summary>
        /// 8-bit byte that contains a 7-bit ASCII code; the last byte must be NUL (binary zero).
        /// </summary>
        Ascii = 2,

        /// <summary>
        /// 16-bit (2-byte) unsigned integer.
        /// </summary>
        Short = 3,

        /// <summary>
        /// 32-bit (4-byte) unsigned integer.
        /// </summary>
        Long = 4,

        /// <summary>
        /// 64-bit (8-byte) unsigned fractional number comprised of two 32-bit unsigned integers representing the numerator and denominator.
        /// </summary>
        Rational = 5,

        /// <summary>
        /// 8-bit signed (twos-compliment) integer.
        /// </summary>
        /// <remarks>
        /// Added in version 6.0 of the TIFF specification.
        /// </remarks>
        SignedByte = 6,

        /// <summary>
        /// 8-bit byte that may contain anything depending on the definition of the field.
        /// </summary>
        /// <remarks>
        /// Added in version 6.0 of the TIFF specification.
        /// </remarks>
        Undefined = 7,

        /// <summary>
        /// 16-bit (2-byte) signed (twos-compliment) integer.
        /// </summary>
        /// <remarks>
        /// Added in version 6.0 of the TIFF specification.
        /// </remarks>
        SignedShort = 8,

        /// <summary>
        /// 32-bit (4-byte) signed (twos-compliment) integer.
        /// </summary>
        /// <remarks>
        /// Added in version 6.0 of the TIFF specification.
        /// </remarks>
        SignedLong = 9,

        /// <summary>
        /// 64-bit (8-byte) signed (twos-compliment) fractional number comprised of two 32-bit signed integers representing the numerator and denominator.
        /// </summary>
        /// <remarks>
        /// Added in version 6.0 of the TIFF specification.
        /// </remarks>
        SignedRational = 10,

        /// <summary>
        /// Single-precision 32-bit (4-byte) IEEE floating point number.
        /// </summary>
        /// <remarks>
        /// Added in version 6.0 of the TIFF specification.
        /// </remarks>
        Single = 11,

        /// <summary>
        /// Double-preicison 64-bit (8-byte) IEEE floating point number.
        /// </summary>
        /// <remarks>
        /// Added in version 6.0 of the TIFF specification.
        /// </remarks>
        Double = 12,
    }
}