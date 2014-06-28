using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NSynth.Containers
{
    public abstract class Container
    {
        public Stream Stream { get; private set; }
        public bool IsOpen { get; private set; }

        public void Open(Stream stream)
        {
            //TODO: Add validation logic to ensure stream supports the operations we need.
            this.Stream = stream;

            this.OpenUnderlyingStream();

            this.IsOpen = true;
        }

        public abstract bool CanContain(Clip clip);

        public abstract Clip GetLayout();

        public abstract ContainerStream GetStreamForTrack(int trackId);

        protected abstract void OpenUnderlyingStream();
    }
}
