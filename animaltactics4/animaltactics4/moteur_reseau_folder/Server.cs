using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Microsoft.Xna.Framework;

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

        bool init;
        public volatile TextBox loremIpsum;

        public Func<bool> abort__;

        public Server()
        {
            clients = new List<Socket>();
            isConnected = false;
            _listeningToClients = new Thread(Listening);
            _clients = new List<Thread>();
            _manage = new ParameterizedThreadStart(Pandawork.ManagerClient);
            init = false;
            loremIpsum = new TextBox(new Rectangle(150, 100, 950, Divers.Y - 300));
            abort__ = new Func<bool>(AbortServer);
        }

        public void Start()
        {
            if (!init)
            {
                loremIpsum.Add("Initialisation du server...");
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(new IPEndPoint(IPAddress.Any, Pandawork.PORT));
                server.Listen(6);
                loremIpsum.AddConsoleMode("Server en mode écoute sur le port 4242 ...");

                _listeningToClients.Start();
                loremIpsum.AddConsoleMode("Server en attente d'un client ...");
                isConnected = true;
                init = true;
            }
            loremIpsum.Update();
        }

        private void Listening()
        {
            
            while (isConnected)
            {
                clients.Add(server.Accept());
                _clients.Add(new Thread(_manage));
               
                _clients[_clients.Count - 1].Start(_clients[_clients.Count - 1]);
                loremIpsum.AddConsoleMode("Nouveau client ! ...");
            }
        }

        public bool AbortServer()
        {
            isConnected = false;
            _listeningToClients.Abort();
            foreach (Thread item in _clients)
            {
                item.Abort();
            }
            server.Close();


            return true;
        }
    }
}
