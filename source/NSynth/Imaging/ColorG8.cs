using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging
{
    /// <summary>
    /// An 8-bit grayscale color.
    /// </summary>
    public struct ColorG8 : IColor
    {
        #region Fields
        private byte g;
        #endregion
        #region Properties
        public byte Value
        {
            get
            {
                return this.g;
            }
            set
            {
                this.g = value;
            }
        }
        float IColor.Red
        {
            get
            {
                return this.g / 255f;
            }
            set
            {
                this.g = (byte)(value * 255);
            }
        }

        float IColor.Green
        {
            get
            {
                return this.g / 255f;
            }
            set
            {
                this.g = (byte)(value * 255);
            }
        }

        float IColor.Blue
        {
            get
            {
                return this.g / 255f;
            }
            set
            {
                this.g = (byte)(value * 255);
            }
        }

        float IColor.Alpha
        {
            get
            {
                return 1f;
            }
            set
            {
            }
        }
        #endregion
    }
}
