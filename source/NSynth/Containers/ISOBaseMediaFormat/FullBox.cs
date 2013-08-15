using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    public class FullBox : Box
    {
        public FullBox(uint boxType, byte version, int flags = 0)
            : base(boxType)
        {
            this.Version = version;
            this.Flags = flags;
        }

        public byte Version
        {
            get;
            set;
        }

        public int Flags
        {
            get;
            set;
        }
    }
}
