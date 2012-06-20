using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace animaltactics4
{
    static class Server
    {
        static List<Socket> sock;
        static Socket serv;

        public static void Init()
        {
            serv = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public static bool ListenTo()
        {
            
                try
                {
                    serv.Bind(new IPEndPoint(IPAddress.Any, 4242));
                    serv.Listen(8);
                    sock.Add(serv.Accept());
                }
                catch { }

                return true;

        }

        public static void SendTo(char c, Socket s)
        {
            try
            {
                //taille 8 octets
                byte[] buffer = ASCIIEncoding.ASCII.GetBytes(c.ToString());

                if (s.Connected)
                {
                    s.Send(buffer);
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

                if (serv.Connected)
                {
                    int i;
                    if ((i = serv.Receive(buffer)) != 0)
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

            foreach (Socket item in sock)
            {
                item.Close();
            }
            sock.Clear();
            serv.Close();
        }
    }
}
