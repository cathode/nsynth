using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NSynth
{
    public class DecoderOpeningEventArgs : EventArgs
    {
        public DecoderOpeningEventArgs(Stream bitstream)
        {
            this.Bitstream = bitstream;
            this.Result = false;
        }

        public Stream Bitstream { get; set; }
        public bool Result { get; set; }
    }
}
