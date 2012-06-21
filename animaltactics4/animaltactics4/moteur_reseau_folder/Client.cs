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
        //static public Socket sock;
        static public WriteBox writebox;

        //static public bool Etape0_connection = false;
        //static public bool Etape1_connection_du_client = false;
        //static public bool Etape2_synchronisation_des_joueurs = false;
        //static public bool Etape3_partie_en_cours = false;
        //static public bool Etape3_SEtape1_partie_en_cours = false;
        //static public bool Etape3_SEtape2_partie_en_cours = false;
        //static public bool Etape4_fin_de_partie = false;

        //public static void Initialiser()
        //{
        //    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //    Etape1_connection_du_client = false;
        //    Etape2_synchronisation_des_joueurs = false;
        //    Etape3_partie_en_cours = false;
        //    Etape3_SEtape1_partie_en_cours = false;
        //    Etape3_SEtape2_partie_en_cours = false;
        //    Etape4_fin_de_partie = false;
        //}

        //public static void Connecter() /*lancer*/
        //{
        //    try
        //    {
        //        sock.Connect(new IPEndPoint(IPAddress.Parse(writebox.text), 4242));
        //        Etape0_connection = true;
        //    }
        //    catch (Exception e)
        //    {
        //        sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        Console.WriteLine(e.Message);
        //    }
        //}

        //public static void Update(Partie p_, GameTime gameTime_) /*mise a jour*/
        //{
        //    // UPDATE DU RESEAU COTE CLIENT
        //    if (!Etape1_connection_du_client)
        //    {
        //        Netools.Send(sock, "1");
        //        Etape1_connection_du_client = true;
        //    }
        //    else
        //    {
        //        if (!Etape2_synchronisation_des_joueurs)
        //        {
        //            p_.Initialize("carte reseau",
        //                          new List<string>() { "Pandawan01", "Pingvin01" },
        //                          new List<int>() { 0, 0 },
        //                          new List<int>() { 0, 1 },
        //                          new List<Color>() { Color.Blue, Color.Red },
        //                          e_typeDePartie.Joute,
        //                          e_brouillardDeGuerre.Normal,
        //                          42);
        //            Netools.Send(sock, "2");
                    
        //        }
        //        else
        //        {
        //            // Horloge
        //            p_.UpdateClient(gameTime_);
        //        }
        //    }
        //}

        //public static void ArreterLeClient() /* stop client */
        //{
        //    if (sock != null)
        //        sock.Close();
        //}
    }
}
