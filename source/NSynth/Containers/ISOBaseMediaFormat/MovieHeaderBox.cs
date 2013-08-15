using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    [BoxType(BoxTypes.MovieHeader)]
    public class MovieHeaderBox : FullBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovieHeaderBox"/> class.
        /// </summary>
        /// <param name="version"></param>
        public MovieHeaderBox(byte version = 0)
            : base(BoxTypes.MovieHeader, version, 0)
        {
        }

        public ulong CreationTime { get; set; }

        public ulong ModificationTime { get; set; }

        public uint Timescale { get; set; }

        public ulong Duration { get; set; }

        public int Rate { get; set; }

        public short Reserved { get; set; }

        public uint Reserved2A { get; set; }

        public uint Reserved2B { get; set; }

        public uint[] UnityMatrix { get; set; }

        public int[] PreDefined { get; set; }

        public uint NextTrackId { get; set; }

    }
}
