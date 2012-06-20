using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    static class Input
    {
        static public string GetValueOf(Keys k)
        {

            if ((int)k >= 65 && (int)k <= 90)
            {
                return k.ToString().ToLower();
            }
            else if (k == (Keys)48 || k == (Keys)96)
            {
                return "0";
            }
            else if (k == (Keys)49 || k == (Keys)97)
            {
                return "1";
            }
            else if (k == (Keys)50 || k == (Keys)98)
            {
                return "2";
            }
            else if (k == (Keys)51 || k == (Keys)99)
            {
                return "3";
            }
            else if (k == (Keys)52 || k == (Keys)100)
            {
                return "4";
            }
            else if (k == (Keys)53 || k == (Keys)101)
            {
                return "5";
            }
            else if (k == (Keys)54 || k == (Keys)102)
            {
                return "6";
            }
            else if (k == (Keys)55 || k == (Keys)103)
            {
                return "7";
            }
            else if (k == (Keys)56 || k == (Keys)104)
            {
                return "8";
            }
            else if (k == (Keys)57 || k == (Keys)105)
            {
                return "9";
            }
            else if (k == (Keys)57 || k == (Keys)106)
            {
                return "9";
            }
            else if (k == (Keys)190)
            {
                return ".";
            }
            else
            {
                return "";
            }


        }

    }
}
