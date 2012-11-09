using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace RenderNode
{
    class Program
    {
        private static Peer peer;

        static void Main(string[] args)
        {
            Program.peer = new Peer();

            peer.Listen(8421);
        }
    }

    public class Peer
    {
        #region Fields
        Timer announcer;
        private TimeSpan announceInterval;
        #endregion

        public void Listen(ushort port)
        {
            var listener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IPv4);

            listener.Bind(new IPEndPoint(IPAddress.Any, port));
            listener.EnableBroadcast = true;
            byte[] msgBuffer = new byte[1400];
            int recv = listener.Receive(msgBuffer);
        }

        public void Announce()
        {

        }

        public TimeSpan AnnounceInterval
        {
            get {
                return this.announceInterval;
            }
            set {
                
                this.announceInterval = value;
            }
        }
    }

    public struct AnnouncePacket
    {
        public string Name;
        public Guid UniqueID;
    }

    public struct ReplyPacket
    {

    }
}
