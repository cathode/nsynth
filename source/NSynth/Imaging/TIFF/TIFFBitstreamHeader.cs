﻿/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Imaging.TIFF
{
    /// <summary>
    /// Represents the header of a TIFF bitstream.
    /// </summary>
    public sealed class TIFFBitstreamHeader
    {
        #region Fields

        /// <summary>
        /// Backing field for <see cref="ByteOrder"/> property.
        /// </summary>
        private ByteOrder byteOrder;

        /// <summary>
        /// Backing field for <see cref="Offset"/> property.
        /// </summary>
        private int offset;

        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the byte order of the TIFF bitstream.
        /// </summary>
        public ByteOrder ByteOrder
        {
            get
            {
                return this.byteOrder;
            }

            set
            {
                this.byteOrder = value;
            }
        }

        /// <summary>
        /// Gets or sets the zero-based offset into the file where the first Image File Directory begins.
        /// </summary>
        public int Offset
        {
            get
            {
                return this.offset;
            }

            set
            {
                this.offset = value;
            }
        }

        #endregion
    }
}
