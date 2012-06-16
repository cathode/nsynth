using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace RenderNode
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Server
    {
        public void Listen(ushort port)
        {
            var listner = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.IPv6);

            
        }
    }

    public struct AnnouncePacket
    {

    }

    public struct ReplyPacket
    {

    }
}
