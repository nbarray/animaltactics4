using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace animaltactics4
{
    class SceneClient : Scene
    {
        Partie p;
        public Socket sock;
        public int tentative = 10;
        //trol
        public SceneClient()
            : base()
        {
            p = new Partie(32, 32);
            p.Initialize("carte reseau",
                                  new List<string>() { "Pandawan01", "Pingvin01" },
                                  new List<int>() { 0, 0 },
                                  new List<int>() { 0, 1 },
                                  new List<Color>() { Color.Blue, Color.Red },
                                  e_typeDePartie.Joute,
                                  e_brouillardDeGuerre.Normal,
                                  42);

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        public override void UpdateScene(GameTime gameTime)
        {

            //if (!Etape0_connection)
            //{
            //    if (tentative > 0)
            //    {
            //        Connecter();
            //        Console.WriteLine(tentative);
            //        tentative--;
            //        Thread.Sleep(500);
            //    }
            //    else
            //    {
            //        ArreterLeClient();
            //        Engine.scenes.Pop();
            //    }
            //}
            //else
            //{
            //    if (!Etape1_connection_du_client)
            //    {
            //        Netools.Send(sock, "1");
            //        Etape1_connection_du_client = true;
            //    }
            //    else
            //    {
            //        if (!Etape2_synchronisation_des_joueurs)
            //        {
            //            p.Initialize("carte reseau",
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
            //            p.UpdateReseau(gameTime);
            //        }
            //    }
                
            //    base.UpdateScene(gameTime);
            //}
        }
        
        public override void DrawScene()
        {
            //base.DrawScene();
            //if (Etape3_partie_en_cours)
            //{
            //    p.DrawClient();
            //}
            //else
            //{
            //    if (sock != null)
            //    {
            //        if (!sock.Connected)
            //        {
            //            Netools.DrawTentativeDeConnection();
            //        }
            //        else
            //        {
            //            Netools.DrawTransition();
            //        }
            //    }
               
            //}
        }

        public void Connecter()
        {
            try
            {
                sock.Connect(new IPEndPoint(IPAddress.Parse(Netools.writebox.text), 4242));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ArreterLeClient()
        {
            //Etape1_connection_du_client = false;
            //Etape2_synchronisation_des_joueurs = false;
            //Etape3_partie_en_cours = false;
            //Etape3_SEtape1_partie_en_cours = false;
            //Etape3_SEtape2_partie_en_cours = false;
            //Etape4_fin_de_partie = false;
        }
    }
}
