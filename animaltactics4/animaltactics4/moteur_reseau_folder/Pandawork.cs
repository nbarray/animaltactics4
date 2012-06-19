using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace animaltactics4
{
    static class Pandawork
    {
        public const int PORT = 4242;

        static public void ManagerClient(object sock)
        {
            while (((Socket)sock).Connected)
            {
                //TODO
            }
        }

        static public void Read(Socket sock)
        {
            
        }
    }
}
