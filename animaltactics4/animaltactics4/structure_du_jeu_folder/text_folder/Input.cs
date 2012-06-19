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
            int i = (int)k;

            if (i >= 65 && i <= 90)
            {
                return k.ToString().ToLower();
            }
            else if (i >= 48 && i <= 57)
            {
                return k.ToString();
            }
            else
            {
                return "";
            }


        }

    }
}
