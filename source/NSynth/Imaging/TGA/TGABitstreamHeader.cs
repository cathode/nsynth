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
        public const int Length = 18;
        private const byte AttributeMask = 0xF0;
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
        public int CopyTo(byte[] buffer, int startIndex)
        {
            // "Image ID" field
            buffer[0x00] = this.IdLength;

            // Color map type
            buffer[0x01] = (byte)this.ColorMapType;
            // Image type
            buffer[0x02] = (byte)this.ImageType;

            // Color map
            buffer[0x03] = (byte)(this.ColorMapOrigin);
            buffer[0x04] = (byte)(this.ColorMapOrigin >> 8);
            buffer[0x05] = 0;
            buffer[0x06] = 0;
            buffer[0x07] = 0;

            // Image X-origin/Y-origin are obsolete/unused/unsupported.
            buffer[0x08] = 0;
            buffer[0x09] = 0;
            buffer[0x0A] = 0;
            buffer[0x0B] = 0;

            // Image width/height. 16-bits each, unsigned.
            buffer[0x0C] = (byte)(this.Width);
            buffer[0x0D] = (byte)(this.Width >> 8);
            buffer[0x0E] = (byte)(this.Height);
            buffer[0x0F] = (byte)(this.Height >> 8);

            // Pixel depth (bits per pixel).
            buffer[0x10] = this.BitsPerPixel;

            // Image descriptor.
            //buffer[0x11] = (byte)this.ImageDescriptor;
            buffer[0x11] = (byte)((int)this.ImageDescriptor | (TGABitstreamHeader.AttributeMask & this.AttributeBits));

            return TGABitstreamHeader.Length;
        }
        public byte[] ToByteArray()
        {
            // Assemble buffer
            var buffer = new byte[TGABitstreamHeader.Length];

            this.CopyTo(buffer, 0);

            return buffer;
        }
        #endregion


    }
}
