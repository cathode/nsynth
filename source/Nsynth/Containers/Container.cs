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
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Container"/> class.
        /// </summary>
        public Container()
        {

        }
        #endregion
        #region Events
        public event EventHandler Opening;
        public event EventHandler Closing;
        #endregion
        public Stream Bitstream { get; private set; }
        public bool IsOpen { get; private set; }

        public void Open(Stream stream)
        {
            if (this.IsOpen)
                if (this.Bitstream == stream)
                    return;
                else
                    throw new NotImplementedException();

            //TODO: Add validation logic to ensure stream supports the operations we need.
            
            var args = new BitstreamOpeningEventArgs(stream);

            this.OnOpening(args);

            if (args.Result)
                this.IsOpen = true;
        }

        public abstract bool CanContain(Clip clip);

        public abstract Clip GetLayout();

        public abstract ContainerStream GetStreamForTrack(int trackId);

        protected virtual void OnOpening(BitstreamOpeningEventArgs e)
        {
            if (this.Opening != null)
                this.Opening(this, e);

            if (e.Result)
                this.Bitstream = e.Bitstream;
        }
    }

    public class BitstreamOpeningEventArgs : EventArgs
    {
        public BitstreamOpeningEventArgs(Stream bitstream)
        {
            this.Bitstream = bitstream;
            this.Result = false;
        }

        public Stream Bitstream { get; set; }
        public bool Result { get; set; }
    }
}
