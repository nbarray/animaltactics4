using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace animaltactics4
{
    static class Dico
    {
        //Coldman : Dictionary<"langue","mots"[]>
        static public Dictionary<string, string[]> langues;
        static public string current;

        //Coldman & Loohy
        static public void Initialize()
        {
            current = "Francais";
            langues = new Dictionary<string,string[]>();

            langues.Add("Francais", new string[]{
            "Jouer", // 0
            "Editer", // 1
            "Bonus", // 2
            "Options", // 3
            "Quitter", // 4
            "Retour", // 5
            "Jeu classique", // 6
            "Campagne", // 7
            "Reseau", // 8
            "Editeur de carte", // 9
            "Editeur d'armee", // 10
            "Encyclopedie", // 11
            "Credits", // 12
            "Graphisme", // 13
            "Jeu", // 14
            "Son",// 15
            "Creer",// 16
            "Modifier",// 17
            "Points restants : ", // 18
            "Force : ", //19
            "Dexterite : ",//20
            "Constitution : ",//21
            "Defense : ",//22
            "Esprit : ",//23
            "Chance : ",//24
            "Vitesse : ",//25
            "Mouvement : ",//26
            });

            langues.Add("English", new string[]{
            "Play",
            "Edit",
            "Bonus",
            "Options",
            "Quit",
            "Back",
            "Classic match",
            "Campain",
            "Network games",
            "Map editor",
            "Army editor",
            "Encyclopedia",
            "Credits",
            "Graphism",
            "Game",
            "Sound",
            "Create",
            "Modify",
            "Remaining points : ",
            "Strenght : ", //19
            "DexteritY : ",//20
            "Constitution : ",//21
            "Defense : ",//22
            "Brain : ",//23
            "Luck : ",//24
            "Rapidity : ",//25
            "Movement : ",//26
            });

            langues.Add("Schtroumpf", new string[]{
            "Schtroumpfer",
            "Schtroumpfer",
            "Bonuschtroumpfs",
            "Schtroumpfs",
            "Schtroumpfer",
            "Schtroumpf",
            "Schtroumpf classique",
            "Schtroumpf",
            "Schtroumpfs en reseau",
            "Editeur de Schtroumpfs",
            "Schtroumpfeur d'armees",
            "Encyclopeschtroumpf",
            "Creditschtroumpfs",
            "Graphischtroumpf",
            "Schtroumpf",
            "Schtroumpf sonore",
            "Schtroumpfer",
            "Schtroumpfer",
            "Points schtroumpfants : ", // 18
            "Force : ", //19
            "Dexterite : ",//20
            "Constitution : ",//21
            "Defense : ",//22
            "Esprit : ",//23
            "Chance : ",//24
            "Vitesse : ",//25
            "Mouvement : ",//26
            });
        }
    }
}
