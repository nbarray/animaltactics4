using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    static class Client
    {
        static public Socket sock;
        static public WriteBox writebox;
        static public string string_ip;
        static public bool unique;
        static public string received;

        static public bool Etape1_connection_du_client = false;
        static public bool Etape2_synchronisation_des_joueurs = false;
        static public bool Etape3_partie_en_cours = false;
        static public bool Etape3_SEtape1_partie_en_cours = false;
        static public bool Etape3_SEtape2_partie_en_cours = false;
        static public bool Etape4_fin_de_partie = false;

        public static void Initialiser()
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string_ip = "";
            writebox = new WriteBox(new Rectangle(Divers.X / 2 - 200, Divers.Y / 2 - 75 / 2, 400, 75));
            unique = false;
            received = "";
        }

        public static void Connecter() /*lancer*/
        {
            if (!unique)
            {
                try
                {
                    sock.Connect(new IPEndPoint(IPAddress.Parse(string_ip), 4242));
                }
                catch
                {
                    Client.Draw();
                }
                Console.Write(sock.Connected);
                unique = true;
            }
        }

        public static void Update(Partie p_, GameTime gameTime_) /*mise a jour*/
        {
            // UPDATE DU RESEAU COTE CLIENT
            if (!Etape1_connection_du_client)
            {
                if (Netools.Read(sock) == 49) // 1
                {
                    Netools.Send(sock, "2");
                    Etape1_connection_du_client = true;
                }   
            }
            else
            {
                if (!Etape2_synchronisation_des_joueurs)
                {
                    // Initialisation de la partie reseau
                    
                    Netools.Send(sock, "3");
                }
                else
                {
                    p_.UpdateClient(gameTime_);
                }
            }
        }

        public static void UpdateWriteBox()
        {
            writebox.Update();
            Client.string_ip = writebox.text;
        }

        public static void ArreterLeClient() /* stop client */
        {
            sock.Close();
            received = "";
            unique = false;
        }

        public static void Draw() /* draw proust*/
        {
            writebox.Draw();
        }

        
    }
}
