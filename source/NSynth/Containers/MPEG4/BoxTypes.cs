using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.MPEG4
{
    public static class BoxTypes
    {
        public const int FileType = 'f' << 24 | 't' << 16 | 'y' << 8 | 'p';
        public const int Track = 't' << 24 | 'r' << 16 | 'a' << 8 | 'k';
        public const int Movie = 'm' << 24 | 'o' << 16 | 'o' << 8 | 'v';
        //public const int Track = 't' | 
    }
}
