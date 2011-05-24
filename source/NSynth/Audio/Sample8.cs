/******************************************************************************
 * NSynth - A Managed Multimedia API - http://nsynth.gearedstudios.com/       *
 * Copyright © 2009-2011 William 'cathode' Shelley. All Rights Reserved.      *
 * This software is released under the terms and conditions of the MIT/X11    *
 * license; see the included 'license.txt' file for the full text.            *
 *****************************************************************************/
using System.Collections.Generic;
using System.Text;

namespace NSynth.Audio
{
    public struct Sample8
    {
        #region Fields
        private sbyte value;
        #endregion
        #region Constructors
        public Sample8(sbyte value)
        {
            this.value = value;
        }
        #endregion
        #region Properties
        public sbyte Value
        {
            get
            {
                return this.value;
            }
        }
        #endregion
        #region Operators
        public static implicit operator Sample8(sbyte value)
        {
            return new Sample8(value);
        }
        #endregion
    }
}
