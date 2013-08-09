/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2013 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace NSynth
{
    /// <summary>
    /// Wraps an array of bytes and provides functionality to read, write, and manipulate binary data
    /// with a high degree of finesse.
    /// </summary>
    public class BitBuffer
    {
        public static BitBuffer Create(int byteCount)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Clears all data in the <see cref="BitBuffer"/>, resetting everything to zeroes.
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Seek(int offset)
        {

        }

        public void SeekToBitOffset(long offsetInBits)
        {

        }

        /// <summary>
        /// Invariant contracts for the <see cref="BitBuffer"/> class.
        /// </summary>
        [ContractInvariantMethod]
        private void Invariants()
        {

        }
    }
}
