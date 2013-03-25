using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;
using NSynth;

namespace RenderNode
{
    class Program
    {
        private static Worker peer;

        static void Main(string[] args)
        {
            return;
        }
    }

    public class Worker
    {
        #region Fields
        public const ushort BroadcastPort = 8421;
        private Timer announcer;
        private TimeSpan announceInterval;
        private long sequenceNumber;
        private Guid senderId;
        private int pid;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Worker"/> class.
        /// </summary>
        public Worker()
        {
            this.AnnounceInterval = TimeSpan.FromSeconds(10);
            this.senderId = Guid.NewGuid();
            this.pid = System.Diagnostics.Process.GetCurrentProcess().Id;
        }
        #endregion
        #region Properties
        public TimeSpan AnnounceInterval
        {
            get
            {
                return this.announceInterval;
            }
            set
            {

                this.announceInterval = value;
            }
        }
        #endregion
        #region Methods
        public void Listen()
        {
            var listener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            listener.Bind(new IPEndPoint(IPAddress.Any, Worker.BroadcastPort));
            listener.EnableBroadcast = true;
            byte[] msgBuffer = new byte[1024]; // fixed size for p2p broadcast packets.
            this.announcer = new Timer(this.Announce, null, 2500, 10000);

            while (true)
            {
                int recv = listener.Receive(msgBuffer);
                if (recv != 1024)
                {
                    Console.WriteLine("Bad packet length: {0}", recv);
                }
                else
                {
                    var packet = new BroadcastPacket();

                    var db = new DataBuffer(msgBuffer);
                    packet.SequenceNumber = db.ReadInt64();
                    packet.Version = db.ReadVersion();
                    packet.SenderId = db.ReadGuid();
                    packet.Flags = (NodeFlags)db.ReadInt64();

                    db.Position = 1024 - 16;
                    var hashData = db.ReadBytes(16);

                    var md5 = System.Security.Cryptography.MD5CryptoServiceProvider.Create();
                    var hashVerify = md5.ComputeHash(msgBuffer, 0, 1024 - 16);
                    var hashMatch = true;
                    for (int i = 0; i < hashData.Length; i++)
                        if (hashData[i] != hashVerify[i])
                        {
                            hashMatch = false;
                            break;
                        }
                    if (!hashMatch)
                        Console.WriteLine("Packet failed hash verification, sent: {0}, should be: {1}", hashData, hashVerify);

                    Console.WriteLine("Received broadcast #{0} from {1}", packet.SequenceNumber, packet.SenderId);
                }
                Thread.Sleep(1000);
            }
        }

        public void Announce(object state)
        {
            var packet = new BroadcastPacket();
            packet.SequenceNumber = this.sequenceNumber++;
            packet.SenderId = this.senderId;
            packet.Flags = NodeFlags.RenderOnly;
            packet.Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            var buffer = new byte[1024];
            var db = new DataBuffer(buffer);
            db.WriteInt64(packet.SequenceNumber);
            db.WriteVersion(packet.Version);
            db.WriteGuid(packet.SenderId);
            db.WriteInt64((long)packet.Flags);

            var hash = System.Security.Cryptography.MD5.Create().ComputeHash(buffer, 0, 1024 - 16);

            db.Position = 1024 - 16;
            db.WriteBytes(hash);

            var client = new UdpClient();
            client.Send(buffer, buffer.Length, new IPEndPoint(IPAddress.Broadcast, Worker.BroadcastPort));

        }
        #endregion

    }

    /// <summary>
    /// Represents a packet of data sent periodically via broadcast that announces the presence of the current node to other nodes on the network.
    /// </summary>
    public sealed class BroadcastPacket
    {
        #region Fields
        // 8
        private long sequenceNumber;
        // 16
        private Version version;
        // 16
        private Guid senderId;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BroadcastPacket"/> class.
        /// </summary>
        /// <param name="sequenceNumber"></param>
        public BroadcastPacket()
        {
        }
        #endregion
        #region Properties
        public long SequenceNumber
        {
            get
            {
                return this.sequenceNumber;
            }
            set
            {
                this.sequenceNumber = value;
            }
        }
        public Version Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }
        public Guid SenderId
        {
            get
            {
                return this.senderId;
            }
            set
            {
                this.senderId = value;
            }
        }
        public NodeFlags Flags
        {
            get;
            set;
        }
        #endregion
    }

    public enum NodeFlags : long
    {
        None = 0x00,
        RenderOnly,
    }
}
