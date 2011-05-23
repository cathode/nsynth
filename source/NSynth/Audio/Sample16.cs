/* NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved. */

using System.Collections.Generic;
using System.Text;

namespace NSynth.Audio
{
    /// <summary>
    /// Represents a 16-bit integer audio sample.
    /// </summary>
    public struct Sample16
    {
        #region Fields
        private short value;
        #endregion
        #region Constructors
        public Sample16(short value)
        {
            this.value = value;
        }
        #endregion
        #region Properties
        public short Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
        #endregion
        #region Operators
        public static implicit operator Sample16(Sample8 sample)
        {
            return new Sample16((short)(sample.Value * (sample.Value / (double)sbyte.MaxValue)));
        }
        public static implicit operator Sample16(short value)
        {
            return new Sample16(value);
        }
        #endregion
    }
}
