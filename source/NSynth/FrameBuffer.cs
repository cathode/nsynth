using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NSynth
{
    /// <summary>
    /// Provides a buffer for frames to be temporarily stored in after rendering, before they're consumed by an upstream filter.
    /// </summary>
    public class FrameBuffer
    {
        #region Fields
        private readonly Dictionary<long, Frame> bufferedFrames;
        private readonly Queue<long> requestedFrames;
        private readonly List<FilterInputSlot> consumers;
        private readonly Mutex sync;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FrameBuffer"/> class.
        /// </summary>
        internal FrameBuffer()
        {
            this.consumers = new List<FilterInputSlot>();
            this.bufferedFrames = new Dictionary<long, Frame>();
            this.requestedFrames = new Queue<long>();
            this.sync = new Mutex();
        }
        #endregion
        #region Methods
        /// <summary>
        /// </summary>
        /// <param name="consumer"></param>
        /// <param name="frameIndex"></param>
        internal void RequestFrame(FilterInputSlot consumer, long frameIndex)
        {
            this.sync.WaitOne();

            try
            {

            }
            finally
            {
                // Thread synchronization has to work to maintain reliability.
                this.sync.ReleaseMutex();
            }
        }
        #endregion
    }
}
