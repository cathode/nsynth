using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.AVI
{
    public class AviStreamHeader
    {
        public AviFourCCType Type;

        public uint Handler; // Four-CC of codec contained in stream.
    }

    public enum AviFourCCType
    {
        Video,  // 'vids'
        Audio,  // 'auds'
        Text,   // 'txts'
    }
}
