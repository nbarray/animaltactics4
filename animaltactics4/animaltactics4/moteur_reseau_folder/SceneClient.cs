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
        Partie partie;
        Socket sock;
        int tentative = 5;
        EtapeReseau etape;

        bool een3;

        public SceneClient()
            : base()
        {
            etape = EtapeReseau.etape1_initialisation;
            een3 = false;
        }

        public override void UpdateScene(GameTime gameTime)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(etape);
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = een3?ConsoleColor.Green:ConsoleColor.Red;
            Console.Write("Partie Initialisée ? " + een3);
            Console.ForegroundColor = ConsoleColor.Gray;

            switch (etape)
            {
                case EtapeReseau.etape1_initialisation:
                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    etape = EtapeReseau.etape2_connection;
                    break;
                case EtapeReseau.etape2_connection:
                    #region Connection
                    while (tentative > 0)
                    {
                        try
                        {
                            sock.Connect(new IPEndPoint(IPAddress.Parse(Netools.writebox.text), 4242));
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        tentative--;
                        Thread.Sleep(250);
                    }

                    if (sock.Connected)
                    {
                        etape = EtapeReseau.etape3_synchronisation;
                    }
                    else
                    {
                        Engine.scenes.Pop();
                    }
                    #endregion
                    break;
                case EtapeReseau.etape3_synchronisation:
                    if (!een3)
                    {
                        InitialiserPartie();
                        een3 = true;
                    }
                    Netools.Send(sock, "H"); // H -> en binaire sheet: 72
                    Netools.Send(sock, "i"); // i -> en binaire sheet: 105

                    etape = EtapeReseau.etape4_partie;

                    break;
                case EtapeReseau.etape4_partie:
                    partie.UpdateReseau(gameTime);
                    break;
                case EtapeReseau.etap5_fin_de_partie:
                    break;
                default:
                    break;
            }

            #region Olddies


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
            #endregion
        }

        public override void DrawScene()
        {
            switch (etape)
            {
                case EtapeReseau.etape1_initialisation:
                    Netools.DrawMessage("Initialisation ...");
                    break;
                case EtapeReseau.etape2_connection:
                    Netools.DrawMessage("Tentative de connection avec le serveur ...");
                    break;
                case EtapeReseau.etape3_synchronisation:
                    Netools.DrawMessage("Connexion effectuée, synchronisation des joueurs ...");
                    break;
                case EtapeReseau.etape4_partie:
                    partie.DrawClient(1);
                    break;
                case EtapeReseau.etap5_fin_de_partie:
                    break;
                default:
                    break;
            }

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

        public void InitialiserPartie()
        {
            partie = new Partie(32, 32);
            partie.Initialize("carte reseau",
                                  new List<string>() { "Pandawan01", "Pingvin01" },
                                  new List<int>() { 0, 0 },
                                  new List<int>() { 0, 1 },
                                  new List<Color>() { Color.Blue, Color.Red },
                                  e_typeDePartie.Joute,
                                  e_brouillardDeGuerre.Normal,
                                  42);
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
