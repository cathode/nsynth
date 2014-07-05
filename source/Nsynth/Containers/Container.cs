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
        /// <summary>
        /// Raised when the container is opened and has it's header and/or other metadata read.
        /// </summary>
        public event EventHandler Opening;

        /// <summary>
        /// Raised when the container is closed.
        /// </summary>
        public event EventHandler<ContainerClosingEventArgs> Closing;
        #endregion
        public Stream Bitstream { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Container"/> has been opened.
        /// </summary>
        public bool IsOpen { get; private set; }

        public ContainerOpenMode Mode { get; private set; }

        /// <summary>
        /// Opens the container and associated multimedia content which is encoded in the specified stream.
        /// </summary>
        /// <param name="stream"></param>
        public void Open(Stream stream, ContainerOpenMode mode)
        {
            if (this.IsOpen)
                if (this.Bitstream == stream)
                    return;
                else
                    throw new NotImplementedException();

            //TODO: Add validation logic to ensure stream supports the operations we need.

            var args = new ContainerOpeningEventArgs(stream, mode);

            this.OnOpening(args);

            if (args.Result)
                this.IsOpen = true;
        }

        public abstract bool CanContain(Clip clip);

        public abstract Clip GetLayout();

        public abstract ContainerStream GetStreamForTrack(int trackId);

        protected virtual void OnOpening(ContainerOpeningEventArgs e)
        {
            if (this.Opening != null)
                this.Opening(this, e);

            if (e.Result)
            {
                this.Bitstream = e.Bitstream;
                this.Mode = e.Mode;
            }
        }
    }

    public class ContainerClosingEventArgs : EventArgs
    {
        public ContainerClosingEventArgs()
        {

        }
    }

    public class ContainerOpeningEventArgs : EventArgs
    {
        public ContainerOpeningEventArgs(Stream bitstream, ContainerOpenMode mode)
        {
            this.Bitstream = bitstream;
            this.Result = false;
            this.Mode = mode;
        }

        public Stream Bitstream { get; set; }
        public ContainerOpenMode Mode { get; set; }
        public bool Result { get; set; }
    }

    public enum ContainerOpenMode
    {
        Read,
        Write,
        MetadataOnly,
    }
}
