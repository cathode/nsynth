using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth
{
    public enum FourierTransformDirection
    {
        Forward,
        Backward,
    }

    public enum FourierTransformMode
    {
        Discrete1D,
        Discrete2D,
        Fast1D,
        Fast2D,
    }

    /// <summary>
    /// Represents a fourier transformation.
    /// </summary>
    public class FourierTransform
    {

        public FourierTransformDirection Direction
        {
            get;
            set;
        }

        public FourierTransformMode Mode
        {
            get;
            set;
        }
    }
}
