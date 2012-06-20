using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Microsoft.Xna.Framework;
using System.Net;
using System.Threading;

namespace animaltactics4
{
    static class Ponk
    {
        static public Socket chaussure_de_l_archiduc;
        static /*volatile*/ public Socket chausettes_de_l_archiduchesse;
        static /*internal virtual abstract */ public WriteBox proust;
        static public bool /*volaile virtual*/ cratos;
        static public /*virtual volatile */ Thread _phantome = new Thread(_instramgram);
        static public void _sont_elles_sechent() /*initialiser*/
        {
            if (_phantome.ThreadState == ThreadState.Unstarted)
            {
                _phantome.Start();
            }
            chausettes_de_l_archiduchesse = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            chausettes_de_l_archiduchesse.Bind(new IPEndPoint(IPAddress.Any, 4242));
            chausettes_de_l_archiduchesse.Listen(2);
            chaussure_de_l_archiduc = null;
            proust = new WriteBox(new Rectangle(Divers.X / 2 - 200, Divers.Y / 2 - 75 / 2, 400, 75));
            cratos = false;
        }

        public static void _instramgram() /*lancer*/
        {
            if (!cratos)
            {
                try
                {
                    chaussure_de_l_archiduc = chausettes_de_l_archiduchesse.Accept();
                }
                catch
                {
                    Chaka._dans_ton_cul();
                }
                cratos = true;
                Console.Write(chausettes_de_l_archiduchesse.Connected);
                
            }
        }

        public static void _que_vois_tu_Louis() /*mise a jour*/
        {
            Chakaponk_tools.trolololol(chaussure_de_l_archiduc, "Bonjour client");
        }

        public static void mini_qui_vois_tu_Louis()
        {
            proust.Update();
            Chaka._quarante_deux_rue_du_marechal_bluton = proust.text;
        }

        public static bool _feu_rouge() /* stop client */
        {
            chausettes_de_l_archiduchesse.Close();
            chaussure_de_l_archiduc.Close();
            cratos = false;
            if (_phantome.ThreadState == ThreadState.Running)
            {
                _phantome.Abort();
            }
            return false;
        }

        public static void _dans_ton_cul() /* draw proust*/
        {
            proust.Draw();
        }
    }
}