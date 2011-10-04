using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSynth.Imaging
{
    /// <summary>
    /// Represents a 32-bit grayscale color.
    /// </summary>
    public struct ColorG32 : IColor
    {
        private float value;

        float IColor.Red
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

        float IColor.Green
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

        float IColor.Blue
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

        float IColor.Alpha
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
    }
}
