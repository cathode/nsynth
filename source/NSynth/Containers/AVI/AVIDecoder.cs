using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSynth.Containers.AVI
{
    public class AVIDecoder : ContainerDecoder
    {
        public override Codec Codec
        {
            get { return Codecs.AVI; }
        }

        protected override void OnOpen(EventArgs e)
        {
            base.OnOpen(e);

            // Read RIFF header

            uint fourCCExpected = (uint)('R' << 24) | (uint)('I' << 16) | (uint)('F' << 8) | (uint)'F';

            var buffer = new DataBuffer(12, ByteOrder.LittleEndian);

            this.Bitstream.Read(buffer.GetUnderlyingByteArray(), 0, 12);

            var fourCC = buffer.ReadUInt32(ByteOrder.BigEndian);

            if (fourCC != fourCCExpected)
            {
                throw new NotImplementedException();
            }

            var dataLength = buffer.ReadUInt32();

            var avitype = buffer.ReadUInt32();


            //var buffer = this.Bitstream.Read()
        }

        public override Clip GetContents()
        {
            throw new NotImplementedException();
        }
    }
}
