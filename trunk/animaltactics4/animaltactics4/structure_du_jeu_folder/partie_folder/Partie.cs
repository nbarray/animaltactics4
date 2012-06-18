using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    //Loohy
    class Partie
    {
        SystemeDeJeu gameplay;
        MoteurGraphique earthPenguin;
        private int lastUpdatesTime;
        public int time;

        //Coldman
        public Partie(int map_width, int map_height)
        {
            gameplay = new SystemeDeJeu();
            earthPenguin = new MoteurGraphique(32, 32);
            time = 0;
            lastUpdatesTime = 0;
        }

        public void Initialize(string nomDeLaMap_, List<string> nomDesArmees_, List<int> difficultes_, List<Color> couleurs_,
            e_typeDePartie conditionsDeVictoire_, HUD hud_, int limiteDeTours_ = 0)
        {
            Divers.telechargerMap(ref earthPenguin, nomDeLaMap_);
            gameplay.initializeWithListedArmies(nomDesArmees_, difficultes_, couleurs_,
                earthPenguin, conditionsDeVictoire_, hud_, limiteDeTours_);
            time = 0;
            lastUpdatesTime = 0;
        }

        public void Update(HUD hud_, GameTime gametime_)
        {
            gameplay.Update(earthPenguin, hud_);
            earthPenguin.Update(gameplay, hud_);
            if (lastUpdatesTime > gametime_.TotalGameTime.Milliseconds)
            {
                time++;
                Console.WriteLine(time);
            }
            lastUpdatesTime = gametime_.TotalGameTime.Milliseconds;
        }

        public void Draw()
        {
            earthPenguin.Draw(gameplay);
        }
    }
}
