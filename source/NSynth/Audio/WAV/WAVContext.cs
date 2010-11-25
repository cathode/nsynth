
namespace NSynth.Audio.WAV
{
    public sealed class WAVContext
    {
        private WAVBitstreamHeader header = new WAVBitstreamHeader();


        public WAVContext()
        {
        }

        public WAVBitstreamHeader Header
        {
            get
            {
                return this.header;
            }
        }
    }
}
