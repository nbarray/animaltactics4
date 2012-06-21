using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Microsoft.Xna.Framework;
using System.Net;
using System.Threading;

namespace animaltactics4
{
    static class Serveur
    {
        static public Socket client;
        static public Socket sock;
        static public WriteBox writebox;
        static public bool unique;
        static public Thread t_init = new Thread(Ecoute);

        static public bool Etape1_connection_du_client;

        static public void Initialiser()
        {
            if (t_init.ThreadState == ThreadState.Unstarted)
            {
                t_init.Start();
            }
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Bind(new IPEndPoint(IPAddress.Any, 4242));
            sock.Listen(2);
            client = null;
            writebox = new WriteBox(new Rectangle(Divers.X / 2 - 200, Divers.Y / 2 - 75 / 2, 400, 75));
            unique = false;
        }

        public static void Ecoute() /*lancer*/
        {
            if (!unique)
            {
                try
                {
                    client = sock.Accept();
                }
                catch
                {
                    Client.Draw();
                }
                unique = true;
                Console.Write(sock.Connected);
                
            }
        }

        public static void _que_vois_tu_Louis() /*mise a jour*/
        {
            // UPDATE DU RESEAU COTE SERVEUR

            Chakaponk_tools.Send(client, "Bonjour client");
        }

        public static bool ArreterLeServer() /* stop srv */
        {
            sock.Close();
            client.Close();
            unique = false;
            if (t_init.ThreadState == ThreadState.Running)
            {
                t_init.Abort();
            }
            return false;
        }

        public static void Draw() /* draw proust*/
        {

        }
    }
}