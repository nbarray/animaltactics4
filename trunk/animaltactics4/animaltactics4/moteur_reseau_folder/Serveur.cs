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
        static public bool unique;
        static public Thread t_init = new Thread(Ecoute);

        static public bool Etape1_connection_du_client = false;
        static public bool Etape2_synchronisation_des_joueurs = false;
        static public bool Etape3_partie_en_cours = false;
        static public bool Etape3_SEtape1_partie_en_cours = false;
        static public bool Etape3_SEtape2_partie_en_cours = false;
        static public bool Etape4_fin_de_partie = false;

        static public void Initialiser(Partie p)
        {
            if (t_init.ThreadState == ThreadState.Unstarted)
            {
                t_init.Start();
            }
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client = null;

            Etape1_connection_du_client = false;
            Etape2_synchronisation_des_joueurs = false;
            Etape3_partie_en_cours = false;
            Etape3_SEtape1_partie_en_cours = false;
            Etape3_SEtape2_partie_en_cours = false;
            Etape4_fin_de_partie = false;
            p = new Partie(32, 32);
            p.Initialize("carte reseau",
                                  new List<string>() { "Pandawan01", "Pingvin01" },
                                  new List<int>() { 0, 0 },
                                  new List<int>() { 0, 1 },
                                  new List<Color>() { Color.Blue, Color.Red },
                                  e_typeDePartie.Joute,
                                  e_brouillardDeGuerre.Normal,
                                  42);
        }

        public static void Ecoute()
        {
            try
            {
                sock.Bind(new IPEndPoint(IPAddress.Any, 4242));
                sock.Listen(20);
                client = sock.Accept();
            }
            catch(Exception e)
            {
                Console.WriteLine("Ecoute: " + e.Message);
            }
        }

        public static void UpdateServer(Partie p, GameTime gameTime)
        {
            // UPDATE DU RESEAU COTE SERVEUR
            if (!Etape1_connection_du_client)
            {
                if (Netools.Read(client) == 49) // 1
                {
                    Etape1_connection_du_client = true;
                }
            }
            else
            {
                if (!Etape2_synchronisation_des_joueurs)
                {
                    if (Netools.Read(client) == 51) // 3
                    {
                        Etape2_synchronisation_des_joueurs = true;
                    }
                }
                else
                {
                    Etape3_partie_en_cours = true;
                    // Partie lancée
                    p.UpdateServeur(gameTime);
                    Netools.Send(client, "o"); // Synch de l'horloge : "o+temps"
                    Netools.Send(client, p.Jackman.tempsRestant + "");
                }
            }
        }

        public static bool ArreterLeServer()
        {
            if (sock != null)
                sock.Close();
            if (client != null)
                client.Close();
            unique = false;
            if (t_init.ThreadState == ThreadState.Running)
            {
                t_init.Abort();
            }
            Etape1_connection_du_client = false;
            Etape2_synchronisation_des_joueurs = false;
            Etape3_partie_en_cours = false;
            Etape3_SEtape1_partie_en_cours = false;
            Etape3_SEtape2_partie_en_cours = false;
            Etape4_fin_de_partie = false;

            return false;
        }
    }
}