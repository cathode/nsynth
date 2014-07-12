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

        public AviStreamHeaderFlags Flags;

        public ushort Priority;
        public ushort Language;
        public uint InitialFrames;
        public uint Scale;
        public uint Rate; // rate / scale = samples per second
        public uint Start;
        public uint Length; // in samples
        public uint SuggestedBufferSize;
        public uint Quality;
        public uint SampleSize;
        public NSynth.Imaging.Rectangle FrameGeometry;
    }

    public enum AviFourCCType
    {
        Video,  // 'vids'
        Audio,  // 'auds'
        Text,   // 'txts'
    }

    [Flags]
    public enum AviStreamHeaderFlags
    {
        Disabled,               // AVISF_DISABLED
        VideoPaletteChanges,    // AVISF_VIDEO_PALCHANGES

    }

}
