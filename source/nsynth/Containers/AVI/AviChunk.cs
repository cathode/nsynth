using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.AVI
{
    public class AviChunk
    {
        public int FourCC;
        public int Size;
        public byte[] Data;
    }
}
