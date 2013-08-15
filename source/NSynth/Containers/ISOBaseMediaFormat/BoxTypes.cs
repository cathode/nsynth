using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.ISOBaseMediaFormat
{
    public static class BoxTypes
    {
        /// <summary>
        /// 'ftyp'
        /// </summary>
        public const uint FileType = 'f' << 24 | 't' << 16 | 'y' << 8 | 'p';

      

        /// <summary>
        /// 'trak'
        /// </summary>
        public const uint Track = 't' << 24 | 'r' << 16 | 'a' << 8 | 'k';

        /// <summary>
        /// 'moov'
        /// </summary>
        public const uint Movie = 'm' << 24 | 'o' << 16 | 'o' << 8 | 'v';

        /// <summary>
        /// 'mhdr'
        /// </summary>
        public const uint MovieHeader = 'm' << 24 | 'h' << 16 | 'd' << 8 | 'r';

        /// <summary>
        /// 'tkhd'
        /// </summary>
        public const uint TrackHeader = 't' << 24 | 'k' << 16 | 'h' << 8 | 'd';

        /// <summary>
        /// 'tref'
        /// </summary>
        public const uint TrackReference = 0x74725666; // 'tref'

        /// <summary>
        /// 'trgr'
        /// </summary>
        public const uint TrackGrouping = 0x74726772; // 'trgr'

        /// <summary>
        /// 'edts'
        /// </summary>
        public const uint EditListContainer = 0x65647473; // 'edts'

        /// <summary>
        /// 'elst'
        /// </summary>
        public const uint EditList = 0x656C7374; // 'elst'
        public const uint TrackMediaInformationContainer = 0x6D646961; // 'mdia'
        public const uint MediaHeader = 0x6D646864; // 'mdhd'
        public const uint MediaHandler = 0x68646c72; // 'hdlr'
        public const uint MediaInformationContainer = 'm' << 24 | 'i' << 16 | 'n' << 8 | 'f';
        public const uint VideoMediaHeader = 'v' << 24 | 'm' << 16 | 'h' << 8 | 'd';
        public const uint SoundMediaHeader = 's' << 24 | 'm' << 16 | 'h' << 8 | 'd';
        public const uint HintMediaHeader = 'h' << 24 | 'm' << 16 | 'h' << 8 | 'd';
        public const uint NullMediaHeader = 'n' << 24 | 'm' << 16 | 'h' << 8 | 'd';
        public const uint DataInformation = 'd' << 24 | 'i' << 16 | 'n' << 8 | 'f';
        public const uint DataReference = 'd' << 24 | 'r' << 16 | 'e' << 8 | 'f';
        public const uint SampleTable = 's' << 24 | 't' << 16 | 'b' << 8 | 'l';


        public const uint MediaData = 'm' << 24 | 'd' << 16 | 'a' << 8 | 't';
        public const uint FreeBox = 'f' << 24 | 'r' << 16 | 'e' << 8 | 'e';

        /// <summary>
        /// 'pdin'
        /// </summary>
        public const uint ProgressiveDownloadInformation = 'p' << 24 | 'd' << 16 | 'i' << 8 | 'n';


    }
}
