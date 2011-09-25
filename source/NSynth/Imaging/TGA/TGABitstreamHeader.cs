/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Runtime.InteropServices;

namespace NSynth.Imaging.TGA
{
    public struct TGABitstreamHeader
    {
        #region Fields
        public byte IdLength;
        public TGAColorMapType ColorMapType;
        public TGAImageType ImageType;
        public ushort ColorMapOrigin;
        public ushort ColorMapLength;
        public byte ColorMapDepth;
        public ushort XOrigin;
        public ushort YOrigin;
        public ushort Width;
        public ushort Height;
        public byte BitsPerPixel;
        public TGAImageDescriptor ImageDescriptor;
        public byte AttributeBits;
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
