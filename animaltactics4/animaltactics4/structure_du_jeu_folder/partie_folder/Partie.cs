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
        public int time, tempsMax;
        public HUD Jackman;

        //Loohy & Coldman
        public Partie(int map_width, int map_height)
        {
            gameplay = new SystemeDeJeu();
            earthPenguin = new MoteurGraphique(32, 32);
            time = 0;
            lastUpdatesTime = 0;
        }

        //Loohy
        public void Initialize(string nomDeLaMap_, List<string> nomDesArmees_, List<int> difficultes_, List<int> camp_, List<Color> couleurs_,
            e_typeDePartie conditionsDeVictoire_, e_brouillardDeGuerre fog_, int tempsMax_, int limiteDeTours_ = 0)
        {
            Jackman = new HUD();
            Divers.telechargerMap(ref earthPenguin, nomDeLaMap_);
            earthPenguin.fog = fog_;
            earthPenguin.viderVue();
            gameplay.initializeWithListedArmies(nomDesArmees_, difficultes_, camp_, couleurs_,
                earthPenguin, conditionsDeVictoire_, Jackman, limiteDeTours_);
            time = 0;
            lastUpdatesTime = 0;
            tempsMax = tempsMax_;
        }

        //Loohy
        public void Update(GameTime gametime_)
        {
            gameplay.Update(earthPenguin, Jackman, ref time);
            earthPenguin.Update(gameplay, Jackman);
            if (lastUpdatesTime > gametime_.TotalGameTime.Milliseconds)
            {
                time++;
                Console.WriteLine(time);
                if (tempsMax-time <= 0)
                {
                    gameplay.FinDeTour(earthPenguin, Jackman, ref time);
                }
            }
            lastUpdatesTime = gametime_.TotalGameTime.Milliseconds;
        }

        //Loohy
        public void Draw()
        {
            earthPenguin.Draw(gameplay);
            Jackman.Draw(gameplay, earthPenguin, tempsMax-time);
            Contents.DrawString(gameplay.conditionsDeVictoire.ToString()+", "+earthPenguin.fog.ToString(), new Rectangle(700,5,100,100));
        }
    }
}
