using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth
{
    /// <summary>
    /// Provides a buffer for frames to be temporarily stored in after rendering, before they're consumed by an upstream filter.
    /// </summary>
    public class FrameBuffer
    {
        #region Fields
        private readonly Dictionary<long, Frame> bufferedFrames;
        #endregion
        #region Methods
        public void PopulateBuffer(long index)
        {

        }
        #endregion
    }
}
