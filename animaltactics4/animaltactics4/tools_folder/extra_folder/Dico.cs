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
            langues = new Dictionary<string, string[]>();

            langues.Add("Francais", new string[]{
            "Jouer", // 0
            "Editer", // 1
            "Bonus", // 2
            "Options", // 3
            "Quitter", // 4
            "Retour", // 5
            "Jeu classique", // 6
            "Campagne", // 7
            "Réseau", // 8
            "Editeur de carte", // 9
            "Editeur d'armée", // 10
            "Encyclopédie", // 11
            "Crédits", // 12
            "Graphisme", // 13
            "Jeu", // 14
            "Son",// 15
            "Créer",// 16
            "Modifier",// 17
            "Points restants : ", // 18
            "Force : ", //19
            "Dextérité : ",//20
            "Constitution : ",//21
            "Défense : ",//22
            "Esprit : ",//23
            "Chance : ",//24
            "Vitesse : ",//25
            "Mouvement : ",//26
             "Très petite",//27
                      "Petite",//28
                      "Normale",//29
                      "Moyenne",//30
                      "Grande",//31
                      "Très grande",//32
                "Plaine",//33
                "Neige",//34
                "Banquise",//35
                "Sable",//36
                "Eau",//37
                "Route",//38
                "Riviere",//39
                "Bunker",//40
                "Forêt",//41
                "Ruine",//42
                "Cratère",//43
                "Village",//44
                "Montagne",//45
                "Vallée",//46
                "Lissage",//47
                "Rien",//48
                "Pinceau",//49
                "Taille",//50
            "PRESENTE", //51
            "Histoire", //52
            "Pingvin", //53
            "Pandawan", //54
            "Fenrir", //55
            "Krissa", //56
            "Unités", //57
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
            "Strength : ", //19
            "Dexterity : ",//20
            "Constitution : ",//21
            "Defense : ",//22
            "Spirit : ",//23
            "Luck : ",//24
            "Speed : ",//25
            "Movement : ",//26
            "Extremly small",//27
            "Small",//28
            "Standart",//29
            "Medium",//30
            "Huge",//31
            "Very huge",//32
            "Plain",//33
            "Snow",//34
            "Ice",//35
            "Sand",//36
            "Water",//37
            "Road",//38
            "Riviere",//39
            "Bunker",//40
            "Forest",//41
            "Ruine",//42
            "Cratere",//43
            "Village",//44
            "HighBrush",//45
            "DownBrush",//46
            "SoftBrush",//47
            "Nothing",//48
            "Tool",//49
            "Size",//50
            "PRESENT", //51
            "History", //52
            "Pingvin", //53
            "Pandawan", //54
            "Fenrir", //55
            "Krissa", //56
            "Units", //57
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
            "Schtroumpfs en réseau",
            "Editeur de Schtroumpfs",
            "Schtroumpfeur d'armées",
            "Encyclopéschtroumpf",
            "Creditschtroumpfs",
            "Graphischtroumpf",
            "Schtroumpf",
            "Schtroumpf sonore",
            "Schtroumpfer",
            "Schtroumpfer",
            "Points schtroumpfants : ", // 18
            "Force : ", //19
            "Schtroumpferité : ",//20
            "Constituschtroumpf : ",//21
            "Défense : ",//22
            "Esprit : ",//23
            "Schtroumpf : ",//24
            "Schtroumpfesse : ",//25
            "Schtroumpfement : ",//26
             "Schtroumpf petite",//27
                      "Petite",//28
                      "Normalschtroumpf",//29
                      "Moyenne",//30
                      "Grande",//31
                      "Schtroumpf grande",//32
                "Schtroumpf",//33
                "Schtroumpf",//34
                "Schtroumpfise",//35
                "Schtroumpf",//36
                "Schtroumpf",//37
                "Schtroumpf",//38
                "Schtroumpfiere",//39
                "Schtroumpfker",//40
                "Foschtroumpf",//41
                "Ruschtroumpf",//42
                "Schtroumpfere",//43
                "Schtroumpfage",//44
                "Schtroumpfagne",//45
                "Schtroumpfee",//46
                "Schtroumpfage",//47
                "Schtroumpf",//48
                "Pinshtroumpf",//49
                "Schtroumpfaille",//50
            "SCHTROUMPFE", //51
            "Hischtroumpf", //52
            "Pingvin", //53
            "Pandawan", //54
            "Fenrir", //55
            "Krissa", //56
            "Schtroumpfités", //57
            });
        }
    }
}
