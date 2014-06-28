using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.AVI
{
    public class AviHeader
    {
        public uint MicroSecPerFrame;
        public uint MaxBytesPerSec;
        public uint PaddingGranularity;
        public AviHeaderFlags Flags;
        public uint TotalFrames;
        public uint InitialFrames;

        public uint Streams;
        public uint SuggestedBufferSize;

        public uint Width;
        public uint Height;

        public uint Reserved;
    }
}
