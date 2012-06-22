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
    class SceneServer : Scene
    {
        public Partie partie;
        public EtapeReseau etape;
        public Socket client;
        public Socket sock;

        Thread _TFinDeTour;

        public bool een3 = false, een4 = false;

        public SceneServer()
            : base()
        {
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));

            _TFinDeTour = new Thread(TFinDeTour);
            etape = EtapeReseau.etape1_initialisation;
            client = null;
        }

        public void Ecoute()
        {
            try
            {
                sock.Bind(new IPEndPoint(IPAddress.Any, 4242));
                sock.Listen(20);
                client = sock.Accept();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ecoute: " + e.Message);
            }
        }

        public override void DrawScene()
        {
            switch (etape)
            {
                case EtapeReseau.etape1_initialisation:
                    Netools.DrawMessage("Initialisation ...");
                    break;
                case EtapeReseau.etape2_connection:
                    Netools.DrawMessage("En attente de la connexion de l'adversaire ...");
                    break;
                case EtapeReseau.etape3_synchronisation:
                    Netools.DrawMessage("Connexion effectuée, synchronisation des joueurs ...");
                    break;
                case EtapeReseau.etape4_partie:
                    partie.DrawClient(0);
                    break;
                case EtapeReseau.etap5_fin_de_partie:
                    break;
                default:
                    break;
            }
        }

        public override void UpdateScene(GameTime gameTime)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(etape);
            Console.SetCursorPosition(0, 1);
            Console.Write("Partie initialisée ? " + een3);
            Console.SetCursorPosition(0, 2);
            if (etape == EtapeReseau.etape4_partie)
            {
                Console.Write("Tour en cours : " + partie.gameplay.tourencours);
            }

            switch (etape)
            {
                case EtapeReseau.etape1_initialisation:
                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    etape = EtapeReseau.etape2_connection;
                    break;
                case EtapeReseau.etape2_connection:
                    Ecoute();
                    etape = EtapeReseau.etape3_synchronisation;
                    break;
                case EtapeReseau.etape3_synchronisation:
                    if (!een3)
                    {
                        InitialiserPartie();
                        een3 = true;
                    }
                    int i;
                    if ((i = Netools.Read(client)) == 72)// h
                    {
                        int j;
                        if ((j = Netools.Read(client)) == 105)// i
                        {
                            Console.SetCursorPosition(0, 2);
                            Console.WriteLine((char)i + " " + (char)j);
                            etape = EtapeReseau.etape4_partie;
                        }
                    }
                    _TFinDeTour.Start();
                    break;
                case EtapeReseau.etape4_partie:
                    if (partie.gameplay.tourencours == 0)
                    {
                        //if (_TFinDeTour.ThreadState == ThreadState.Running)
                        //{
                        //    _TFinDeTour.Suspend(); // VA TE FAIRE METTRE PAR DES LUTTINS
                        //}
                        //if (partie.time > 41)
                        //{
                        //    ChangementTour();
                        //    Netools.Send(client, "]"); // => fin du tour : 93
                        //    Console.WriteLine("Ordre de changement de tour envoyé !");
                        //}

                        partie.UpdateReseauServer(gameTime, this);
                    }
                    else
                    {
                        //if (_TFinDeTour.ThreadState == ThreadState.Suspended)
                        //{
                        //    _TFinDeTour.Resume();
                        //}
                        Netools.UpdateTransition(gameTime);
                    }
                    
                    break;
                case EtapeReseau.etap5_fin_de_partie:
                    break;
                default:
                    break;
            }

        }

        public bool ArreterLeServer()
        {
            if (sock != null)
                sock.Close();
            if (client != null)
                client.Close();
            return false;
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

        public void ChangementTour()
        {
            int epita42epita = 0;
            bool epita41epita = true;
            partie.gameplay.FinDeTour(partie.earthPenguin, partie.Jackman, ref epita42epita, ref epita41epita);
            Divers.serializer(partie.gameplay, "g s");
            Divers.serializer(partie.earthPenguin, "e s");
            client.SendFile("g s");
            client.SendFile("e s");
        }
        public void TFinDeTour()
        {
            while (true)
            {
                Console.SetCursorPosition(0, 6);
                Console.Write("Thread: " + new Random().Next(42));
                int f;
                if ((f = Netools.Read(client)) == 93)
                {
                    ChangementTour();
                    partie.time = 0;
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("Ordre de changementde tour reçu !");
                }
            }

        }
    }
}
