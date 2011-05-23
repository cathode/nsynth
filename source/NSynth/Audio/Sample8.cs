/**************************************************************************** 
 * NSynth - A Managed Multimedia API. http://nsynth.codeplex.com/    *
 * Copyright © 2009-2011 Will 'cathode' Shelley. All Rights Reserved.       *
 *--------------------------------------------------------------------------*
 * Contributors:                                                            *
 * - Will 'cathode' Shelley <cathode@live.com>                              *
 ****************************************************************************/
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
