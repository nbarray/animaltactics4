using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace animaltactics4
{
    class Client
    {
        Socket server;
        bool isConnected, init;

        public Client()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            init = false;
            isConnected = false;
        }

        public void Start()
        {
            if (!init)
            {
                server.Connect(new IPEndPoint(IPAddress.Parse("localhost"), Pandawork.PORT));
                init = true;
            }

            isConnected = server.Connected;
        }
    }
}
