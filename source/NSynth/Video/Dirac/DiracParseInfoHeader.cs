/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2012 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Runtime.InteropServices;

namespace NSynth.Video.Dirac
{
    /// <summary>
    /// Represents a Dirac Parse Info Header.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 13)]
    public sealed class DiracParseInfoHeader
    {
        #region Fields
        [FieldOffset(0x00)]
        private uint prefix;
        [FieldOffset(0x04)]
        private DiracParseCode code;
        [FieldOffset(0x05)]
        private uint nextOffset;
        [FieldOffset(0x09)]
        private uint prevOffset;
        #endregion
        #region Constructors
        public DiracParseInfoHeader()
        {
            this.prefix = DiracCodec.ParseInfoPrefix;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Holds the <see cref="DiracParseCode"/> of the current <see cref="DiracParseInfoHeader"/>.
        /// </summary>
        public DiracParseCode Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        /// <summary>
        /// Holds the offset to the next Parse Info Header, which is the number of bytes from the first byte of the
        /// current Parse Info Header to the first byte of the next Parse Info Header, if there is one. If there is no
        /// subsequent Parse Info Header, the offset is zero.
        /// </summary>
        public uint NextOffset
        {
            get
            {
                return this.nextOffset;
            }
            set
            {
                this.nextOffset = value;
            }
        }

        /// <summary>
        /// Gets or sets the offset to the previous Parse Info Header, which is the number of bytes from the first byte
        /// of the current Parse Info Header to the first byte of the previous Parse Info Header.
        /// </summary>
        public uint PreviousOffset
        {
            get
            {
                return this.prevOffset;
            }
            set
            {
                this.prevOffset = value;
            }
        }
        #endregion
    }
}
