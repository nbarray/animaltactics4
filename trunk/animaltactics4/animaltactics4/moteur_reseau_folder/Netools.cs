using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    enum EtapeReseau
    {
        etape1_initialisation, etape2_connection, etape3_synchronisation, etape4_partie, etap5_fin_de_partie
    }

    static class Netools
    {
        static public WriteBox writebox;

        #region Old Stuff

        public static Rectangle sub = new Rectangle(0, 0, 50, 50);

        public static void Send(Socket sock, string msg)
        {
            try
            {
                NetworkStream str = new NetworkStream(sock);
                str.Write(ASCIIEncoding.ASCII.GetBytes(msg), 0, ASCIIEncoding.ASCII.GetBytes(msg).Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("42." + e.Message);
            }
        }

        public static int Read(Socket sock)
        {
            try
            {
                NetworkStream str = new NetworkStream(sock);
                return str.ReadByte();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public static int ReadTime(Socket sock)
        {
            int i;
            if ((i = Read(sock)) == 111)
            {
                return Read(sock);
            }
            else
            {
                return -1;
            }
        }

        public static void UpdateTransition(GameTime gameTime_)
        {
            if (gameTime_.TotalGameTime.Milliseconds % 500 == 0)
            {
                sub.X += 50;
                if (sub.X >= 150)
                {
                    sub.X = 0;
                }
            }
        }

        public static void DrawTransition()
        {
            Contents.Draw("px", new Rectangle(0, 0, 1200, 900), Color.Black);
            Contents.Draw("waitforplayer", new Rectangle(600 - 75, 300 - 75, 150, 150), sub);
            Contents.DrawString("Tour de votre adversaire en cours", new Rectangle(600 - 200, 200, 1, 1), Color.White);
        }

        public static void DrawMessage(string str)
        {
            Contents.Draw("px", new Rectangle(0, 0, 1200, 900), Color.Black);
            Contents.DrawString(str, new Rectangle(600 - (int)Contents.MeasureString(str).X / 2, 200, 1, 1), Color.White);
        }

        public static void SendUpdatedMap(Socket sock, Partie p)
        {
            try
            {
                NetworkStream stream = new NetworkStream(sock);
                for (int i = 0; i < p.earthPenguin.map.GetLength(0); i++)
                {
                    for (int j = 0; j < p.earthPenguin.map.GetLength(1); j++)
                    {
                        Send(sock, p.earthPenguin.map[i, j].pointeurUnite.ToString());
                    }
                }

                int ii;
                while (Read(sock) != 111) { }// reception d'une reponse
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static string ReadUpdatedMap(Socket sock)
        {
            return "";
        }

        public static void ClearPresence(MoteurGraphique g)
        {
            for (int i = 0; i < g.map.GetLength(0); i++)
            {
                for (int j = 0; j < g.map.GetLength(1); j++)
                {
                    g.map[i, j].presence = false;
                }
            }
        }

        #endregion
    }
}
