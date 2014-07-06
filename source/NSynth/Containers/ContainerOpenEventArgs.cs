using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NSynth.Containers
{
    public class ContainerOpeningEventArgs : EventArgs
    {
        public ContainerOpeningEventArgs(Stream bitstream, ContainerOpenMode mode)
        {
            this.Bitstream = bitstream;
            this.Result = false;
            this.Mode = mode;
        }

        public Stream Bitstream { get; set; }
        public ContainerOpenMode Mode { get; set; }
        public bool Result { get; set; }
    }
}
