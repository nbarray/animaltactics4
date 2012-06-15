using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuOptionJeu : Scene
    {
        public MenuOptionJeu()
            : base()
        {
            boutons.Add(new BoutonLangage(new Rectangle(Divers.X / 2 - 200, 600, 400, 75)));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
        }
    }
}
