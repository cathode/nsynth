/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;

namespace NSynth
{
    internal static class EXStrings
    {
        internal const string BitmapHeightTooSmall = "The specified pixel height was too small.";
        internal const string BitmapWidthTooSmall = "The specified pixel width was too small.";
        internal const string BitmapPixelArraySizeMismatch = "The size of the specified pixel array was wrong.";
        internal const string CodecFeatureNotImplemented = "The codec has not implemented that feature.";
    }

    /// <summary>
    /// NSynth-internal exception messages.
    /// </summary>
    internal static class EX
    {
        #region Fields
        internal static readonly Dictionary<EXCode, string> messages = new Dictionary<EXCode, string>();
        #endregion
        #region Constructors
        static EX()
        {
            var m = new Dictionary<EXCode, string>();

            m[EXCode.BitmapHeightTooSmall] = EXStrings.BitmapHeightTooSmall;
            m[EXCode.BitmapPixelArraySizeMismatch] = EXStrings.BitmapPixelArraySizeMismatch;
            m[EXCode.BitmapWidthTooSmall] = EXStrings.BitmapWidthTooSmall;
            m[EXCode.EncoderFeatureNotImplemented] = EXStrings.CodecFeatureNotImplemented;

            EX.messages = m;
        }
        #endregion
        #region Methods
        internal static string Message(EXCode code, params object[] data)
        {
            switch (code)
            {
                 default:
                    return string.Format("{1:X8}: {0} - Expected: {1} - Actual: {2}", EX.messages[code], (int)code, data);
            }
        }
        internal static Exception Create(EXCode code, object expected, object actual)
        {
            return EX.Create(code, null, expected, actual);
        }
        internal static Exception Create(EXCode code, params object[] data)
        {
            return EX.Create(code, null, data);
        }

        internal static Exception Create(EXCode code, Exception innerException, params object[] data)
        {
            switch (code)
            {
                case EXCode.ArgumentNull:
                    return new ArgumentNullException(data[0] as string, EX.Message(code, data));

                case EXCode.BitmapPixelArraySizeMismatch:
                    return new ArgumentException(EX.Message(code, data), innerException);

                case EXCode.BitmapHeightTooSmall:
                case EXCode.BitmapWidthTooSmall:
                    return new ArgumentOutOfRangeException(EX.Message(code, data), innerException);
            }

            throw new Exception();
        }
        #endregion
    }
    internal enum EXCode
    {
        ArgumentNull,
        BitmapHeightTooSmall,
        BitmapWidthTooSmall,
        BitmapPixelArraySizeMismatch,
        EncoderFeatureNotImplemented,
    }
}
