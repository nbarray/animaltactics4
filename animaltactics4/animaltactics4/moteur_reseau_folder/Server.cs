using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace animaltactics4
{
    class Server
    {
        Socket server;
        List<Socket> clients;
        List<Thread> _clients;
        volatile bool isConnected;

        Thread _listeningToClients;
        ParameterizedThreadStart _manage;

        public Server()
        {
            clients = new List<Socket>();
            isConnected = false;
            _listeningToClients = new Thread(Listening);
            _clients = new List<Thread>();
            _manage = new ParameterizedThreadStart(Pandawork.ManagerClient);
        }

        public void Start()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Any, Pandawork.PORT));
            server.Listen(6);
            _listeningToClients.Start();
            isConnected = true;
        }

        private void Listening()
        {
            while (isConnected)
            {
                clients.Add(server.Accept());
                _clients.Add(new Thread(_manage));
                _clients[_clients.Count - 1].Start(_clients[_clients.Count - 1]);

            }
        }


        
    }
}
