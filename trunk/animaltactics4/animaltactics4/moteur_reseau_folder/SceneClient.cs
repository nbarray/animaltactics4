using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace animaltactics4
{
    class SceneClient : Scene
    {
        public Partie partie;
        public Socket sock;
        int tentative = 5;
        EtapeReseau etape;
        public FileReseau fileState;
        string receive;
        Thread _TFinDeTour, _TReceiveFile;

        public bool een3 = false, priorite = false;

        public SceneClient()
            : base()
        {
            _TFinDeTour = new Thread(TFinDeTour);
            _TReceiveFile = new Thread(TReceiveFile);
            etape = EtapeReseau.etape1_initialisation;
            fileState = FileReseau.sleep;
            receive = "";
        }

        public override void UpdateScene(GameTime gameTime)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(etape);
            Console.SetCursorPosition(0, 1);
            
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
                        partie.gameplay.tourencours = 0;
                        een3 = true;
                    }
                    Netools.Send(sock, "H"); // H -> en binaire sheet: 72
                    Netools.Send(sock, "i"); // i -> en binaire sheet: 105

                    etape = EtapeReseau.etape4_partie;
                    _TFinDeTour.Start();
                    break;
                case EtapeReseau.etape4_partie:
                    if (fileState == FileReseau.reception_en_cours)
                    {
                        Console.WriteLine("reception_avant");
                        Netools.ReadText(sock, (byte)'$', receive);
                        Console.WriteLine("reception_apres : " + receive);
                        try
                        {
                            Console.WriteLine("deserializer_avant");
                            StreamWriter writer = new StreamWriter(new FileStream("G.bin", FileMode.Create, FileAccess.ReadWrite));
                            partie.gameplay = (SystemeDeJeu)Divers.deserializer("G");
                            Netools.ClearPresence(partie.earthPenguin);
                            Console.WriteLine("deserializer_apres");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        fileState = FileReseau.sleep;
                        Console.WriteLine("filereseau_to_sleep");
                    }
                    else if (fileState == FileReseau.envoie_en_cours)
                    {
                        try
                        {
                            Console.WriteLine("serializer_");
                            Divers.serializer(partie.gameplay, "G");
                            Console.WriteLine("send_serializer");
                            Thread.Sleep(5000);
                            Netools.SendText(sock, "G");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine("filereseau_to_sleep");
                        fileState = FileReseau.sleep;
                    }
                    else
                    {
                        if (partie.gameplay.tourencours == 1) // Si c'est a mon tour
                        {
                            partie.UpdateReseauClient(gameTime, this);
                        }
                        else
                        {
                            Netools.UpdateTransition(gameTime);
                        }
                    }
                    break;
                case EtapeReseau.etap5_fin_de_partie:
                    break;
                default:
                    break;
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
            
        }

        public void ChangementTour()
        {
            int epitaa = 0;
            bool epitaaa = true;
            partie.gameplay.FinDeTour(partie.earthPenguin, partie.Jackman, ref epitaa, ref epitaaa);
        }

        private void TReceiveFile()
        {
            while (true)
            {
                int i;
                if ((i = Netools.Read(sock)) == 57)//9
                {
                     fileState = FileReseau.reception_en_cours;
                }
            }
        }

        private void TFinDeTour()
        {
            while (true)
            {
                int f;
                if ((f = Netools.Read(sock)) == 93)
                {
                    fileState = FileReseau.reception_en_cours;
                    ChangementTour();
                    partie.time = 0;
                }
            }
        }
    }
}
