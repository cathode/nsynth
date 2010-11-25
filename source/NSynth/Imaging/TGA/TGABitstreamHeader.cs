/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2010 Will 'cathode' Shelley. All Rights Reserved.         *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Runtime.InteropServices;

namespace NSynth.Imaging.TGA
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 18)]
    public struct TGABitstreamHeader
    {
        #region Fields
        [FieldOffset(0)]
        public byte IdLength;
        [FieldOffset(1)]
        public TGAColorMapType ColorMapType;
        [FieldOffset(2)]
        public TGAImageType ImageType;
        [FieldOffset(3)]
        public ushort ColorMapOrigin;
        [FieldOffset(5)]
        public ushort ColorMapLength;
        [FieldOffset(7)]
        public byte ColorMapDepth;
        [FieldOffset(8)]
        public ushort XOrigin;
        [FieldOffset(10)]
        public ushort YOrigin;
        [FieldOffset(12)]
        public ushort Width;
        [FieldOffset(14)]
        public ushort Height;
        [FieldOffset(16)]
        public byte BitsPerPixel;
        [FieldOffset(17)]
        public TGAImageDescriptor ImageDescriptor;
        #endregion
        #region Methods
        public bool Validate()
        {
            // TODO: Implement TGA header validation.
            return true;
        }
        #endregion
    }
}
