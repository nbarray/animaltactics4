using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace animaltactics4
{
    static class Client
    {
        /*
         TODO:
         * Socket sock;
         * Fct de connection
         * Fct d'envoie du pseudo au server
         * Fct de reception du message de bienvenue du serveur
         */

        static Socket sock;

        static bool phaseDeConnection;

        public static void Init()
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            phaseDeConnection = false;
        }

        public static bool ConnectTo(string ip)
        {
            if (!phaseDeConnection)
            {
                try
                {
                    sock.Connect(new IPEndPoint(IPAddress.Parse(ip), 4242));
                    phaseDeConnection = sock.Connected;
                }
                catch { }
            }

            return phaseDeConnection;
        }

        public static void SendTo(char c)
        {
            try
            {
                //taille 8 octets
                byte[] buffer = ASCIIEncoding.ASCII.GetBytes(c.ToString());

                if (phaseDeConnection)
                {
                    sock.Send(buffer);
                }
            }
            catch { }
        }

        public static char ReceiveFrom()
        {
            try
            {
                //taille 8 octets
                byte[] buffer = new byte[8];

                if (phaseDeConnection)
                {
                    int i;
                    if ((i = sock.Receive(buffer)) != 0)
                    {
                        return ASCIIEncoding.ASCII.GetString(buffer)[0];
                    }
                    else
                    {
                        return '\0';
                    }
                }
                else
                { 
                    return '\0';
                }
            }
            catch { return '\0'; }
        }

        public static void Stop()
        {
            phaseDeConnection = false;
            sock.Close();
        }
    }
}
