using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    static class Chakaponk_tools
    {
        public static /*volatile*/ void trolololol(Socket sock, string msg)
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
    }
}
