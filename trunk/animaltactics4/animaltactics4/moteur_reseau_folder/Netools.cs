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
        public static /*volatile*/ void Send(Socket sock, string msg)
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
    }
}
