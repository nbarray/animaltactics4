using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using Microsoft.Xna.Framework;
using System.Threading;

namespace animaltactics4
{
    static class Client
    {
        static public Socket sock;
        static public WriteBox writebox;
        static public string string_ip;

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

            Etape1_connection_du_client = false;
            Etape2_synchronisation_des_joueurs = false;
            Etape3_partie_en_cours = false;
            Etape3_SEtape1_partie_en_cours = false;
            Etape3_SEtape2_partie_en_cours = false;
            Etape4_fin_de_partie = false;
        }

        public static void Connecter() /*lancer*/
        {
            try
            {
                sock.Connect(new IPEndPoint(IPAddress.Parse(writebox.text), 4242));
            }
            catch (Exception e)
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Console.WriteLine(e.Message);
            }

        }

        public static void Update(Partie p_, GameTime gameTime_) /*mise a jour*/
        {
            // UPDATE DU RESEAU COTE CLIENT
            if (!Etape1_connection_du_client)
            {
                Console.WriteLine("connection en cours ... envoie du message de conn");
                Netools.Send(sock, "1");
                Etape1_connection_du_client = true;

            }
            else
            {
                if (!Etape2_synchronisation_des_joueurs)
                {
                    Console.WriteLine("initialisation !!! envoie du message de validation");
                    // Initialisation de la partie reseau
                    
                    Netools.Send(sock, "2");
                }
                else
                {
                    Console.Write(Netools.Read(sock));
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
            if (sock != null)
                sock.Close();
            received = "";

        }

        public static void Draw() /* draw proust*/
        {
            writebox.Draw();
        }
    }
}
