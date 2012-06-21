using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    static class Netools
    {
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
                Console.WriteLine(e.Message);
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
            Contents.DrawString("En attente de votre adversaire", new Rectangle(600 - 200, 200, 1, 1), Color.White);
        }

        public static void DrawTentativeDeConnection()
        {
            Contents.Draw("px", new Rectangle(0, 0, 1200, 900), Color.Black);
            Contents.DrawString("Tentative...(5 sec d'attente)", new Rectangle(600 - 200, 200, 1, 1), Color.White);
        }
    }
}
