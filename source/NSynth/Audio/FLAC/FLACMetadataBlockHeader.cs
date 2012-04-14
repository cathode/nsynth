/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/

namespace NSynth.Audio.FLAC
{
    public struct FLACMetadataBlockHeader
    {
        #region Fields - Private
        private uint header;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets a value that indicates if the metadata header is the last metadata header in the bitstream.
        /// </summary>
        public bool IsLastMetadataBlock
        {
            get
            {
                return (this.header & 0x80000000) == 0x80000000;
            }
            set
            {
                this.header = (value) ? this.header | 0x80000000 : this.header & ~0x80000000;
            }
        }
        /// <summary>
        /// Gets or sets the <see cref="FLACBlockType"/> of the header.
        /// </summary>
        public FLACBlockType BlockType
        {
            get
            {
                return (FLACBlockType)(this.header & 0x7F000000);
            }
            set
            {
                this.header = (this.header & ~((uint)0x7F000000)) | ((uint)value) & 0x7F000000;
            }
        }
        /// <summary>
        /// Gets or sets the size of the metadata block. Limited to 24-bits (16,777,215).
        /// </summary>
        public int BlockSize
        {
            get
            {
                return (int)(this.header & 0x00FFFFFF);
            }
            set
            {
                this.header = (this.header & ~((uint)0x00FFFFFF)) | ((uint)value) & 0x00FFFFFF;
            }
        }
        #endregion
    }
}
