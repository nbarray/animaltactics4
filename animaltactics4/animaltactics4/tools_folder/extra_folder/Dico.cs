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
            try
            {
                current = Engine.files.currentLanguage;
            }
            catch (Exception)
            {
                current = "Francais";
            }

            
            langues = new Dictionary<string, string[]>();

            #region Francais
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
            "Puissance : ", //19
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
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean lobortis, lectus quis bibendum ornare, velit urna vestibulum metus, nec molestie ligula neque nec leo. Aenean luctus hendrerit luctus. Nulla malesuada leo vel mi elementum aliquet. Aenean aliquet vehicula nisi et dapibus. Cras turpis velit, faucibus vitae adipiscing ut, posuere et justo. Praesent felis enim, bibendum id dictum placerat, hendrerit ac tortor. Vivamus posuere feugiat faucibus. Ut ultrices erat id lacus porta consectetur. Mauris molestie felis vitae sapien molestie ut facilisis justo adipiscing. Donec ut mi vel tellus semper varius eget et erat. Phasellus nec enim ante. Fusce imperdiet condimentum egestas. Curabitur scelerisque, justo sed fringilla condimentum, mi ipsum rhoncus odio, nec porta lorem enim nec leo. Curabitur convallis dui ut est tempus eu pharetra ipsum vulputate.Mauris nec velit vel sapien luctus imperdiet. Ut lacus tellus, tempus sed lobortis ut, pellentesque et magna. Vestibulum eu felis at nunc sollicitudin rutrum. Vivamus vehicula sapien ac nibh aliquet egestas nec a arcu. Vivamus id mi sed enim iaculis bibendum. Fusce mattis risus vitae leo sodales sed aliquet ipsum feugiat. Pellentesque eu orci arcu, eu tristique justo. Aliquam erat volutpat. Pellentesque congue massa eget velit condimentum dictum nec vel sapien. Vivamus vestibulum nisi eu odio volutpat facilisis. Curabitur fermentum dolor ac velit aliquam id dapibus erat pretium. Nam dui lorem, luctus vitae imperdiet a, eleifend tristique eros. Morbi at ante ut enim dapibus elementum. Nulla augue est, faucibus vel feugiat quis, iaculis et magna.Mauris vulputate dictum tincidunt. Suspendisse ac elit in nunc porttitor fermentum non nec leo. Aenean imperdiet, erat vel suscipit laoreet, nibh lectus hendrerit orci, quis ultrices nunc nulla id felis. Donec suscipit erat eu dolor gravida sollicitudin. Aliquam sed turpis turpis. Nullam tristique, libero sit amet fermentum luctus, elit felis porta ligula, vitae fermentum tortor turpis ut velit. Maecenas adipiscing ultrices tortor eu tincidunt. Vivamus dapibus ligula sed dolor sollicitudin gravida. Ut gravida metus quis velit fermentum egestas. Proin placerat metus et elit vehicula interdum. In dolor justo, hendrerit vestibulum bibendum suscipit, laoreet et magna. Ut odio ipsum, tincidunt vel mattis et, ornare eget tellus. Pellentesque gravida, massa sit amet mollis dictum, magna ligula vestibulum metus, sed pretium ipsum erat sit amet odio. Ut placerat vulputate enim gravida ultrices. Nunc posuere felis nec lectus placerat malesuada. Nam vitae risus lorem. Fusce pulvinar adipiscing sapien, eu ultrices sem sagittis porttitor. Duis vel quam diam, non molestie ante. Class aptent taciti.", //58
            "Le blabla sur la Pingvin", //59
            "Le fabuleux recit sur les Pandawans", //60
            "Le dernier Fenrir", //61
            "Le Krissa dormant", //62
            "L'explication sur les Unités pandawans", //63
            "Héberger", // 64
            "PANDAWORK.NET", // 65
            "Rejoindre", // 66
            "Plein écran", // 67
            "Pause", // 68
            "Retour au jeu", // 69
            "Walkyries",//70
            "Répurgateurs",
            "Tank",
            "Ugins",
            "Pillards",
            "Berserkers",//75
            "Thors",
            "Mugins",
            "Odin",
            "Moines",
            "Yabusames",//80
            "Bushis",
            "Chars Dragons",
            "Mercenaires",
            "Sokeis",
            "Ninjas",//85
            "Snipers",
            "Sayan",
            "Guerriers",
            "Tireurs",
            "Psykers",//90
            "Porteurs de boucliers",
            "Eclaireurs",
            "Dreadnoughts",
            "Fusils Rail",
            "Instructeurs",//95
            "Okami",
            "Chef",
            "Assassins",
            "Légionnaires",
            "Geoliers",//100
            "Maraudeurs",
            "Vermines",
            "Abominations",
            "Alvin dort tout le temps",
            "Alvin branle que dalle",//105
            "Animal Spirit",
            "Unité de base des Pingvin présente dans toutes les armées. \nElle attaque au corps-à-corps à l'aide de son épée tronconneuse, \net possède un bouclier. Très polyvalente.",//107
            "Unité utilisant un lance-flamme qui contrairement à la pensée\n commune ne fait pas très mal mais ne risque pas de manquer \nsouvent sa cible.",
            "Unité très puissante offensivement si l'on ne tient pas compte\n de sa faible précision. Elle est également très résistante \nmais ne peut pas riposter au corps-à-corps. De plus sa rapidité est \nun atout non négligeable.",
            "Mage efficace offensivement mais n'attaquant qu'au corps-à-corps.\n Utile face aux unités résistant aux attaques physiques mais \npas aux attaques magiques.",
            "Unité la moins chère et donc la moins efficace de l'armée\n Pingvin.",//111
            "Unité élite de corps-à-corps. Elle possède une grande force\n d'attaque qu'il peut booster grace à son pouvoir Rage Berserke. \nElle a un grand nombre de points de vie mais n'est pas très \nrésitante, surtout face à la magie.",
            "Unité la plus renommée chez les Pingvin. Possède un sort de\n foudre devastateur.",
            "Unité soigneur de l'armée Pingvin. Ils sont equipés d'armes\n lourdes afin d'avoir l'impression de se rendre utiles.",
            "Héros Pingvin. Il chevauche un ours a huit pattes. Il attaque\n au corps-à-corps à l'aide de sa lance divine.",
            "Unité soigneur des Pandawan. Il effectue des attaques magiques\n courtes à l'aide de son baton.",//116
            "Archer Pandawan équipé d'un Yumi, un arc asymétrique, il est \nplutôt résistant et assez efficace offensivement mais est tres \nfaible au corps-à-corps.",
            "Samourai Pandawan bien résistant et performant offensivement \nmais n'attaque qu'au contact.",//118
            "Char Pandawan équipé de faux et de lames de démolition ainsi \nque d'un lance-flamme ce qui lui permet d'être efficace à courte \nportée. Il n'est pas très réactif et surtout extrêmement vulnérable \nà la magie.",
            "Pandawans équipés d'armes modernes volées aux autres espèces. \nUnité moyenne de tir avec un bon rapport qualité-prix.",
            "Unité Pandawan très stupide donc très vulnérable à la magie. \nDispose d'une résistance et d'une efficacité moyenne.",
            "Unité d'inflitration dotée de la capacité de se rendre invisible.\n Efficace au corps-à-corps et à très courte portée mais peu \nrésistant.",
            "Unité capable d'attaquer efficacement à très longue distance \npourvu que les unités adverses soient visibles. Elle fonctionne donc \ntrès bien avec les unités d'inflitration comme le Ninja. Mais \nattention à sa faiblesse au corps-à-corps.",
            "Héros Pandawan doté d'une force supérieure et dont la fourrure \nchange de couleur lorsqu'il est en colère.",
            "Unité de corps-à-corps classique. Efficace mais peu résistante.\n",//125
            "Unité classique d'attaquant à distance. Faible au corps-à-corps.\n",//126
            "Seul mage Fenrir permettant d'être efficace contres certaines \nunités très resistantes physiques par exemple les tanks ou Odin. Il \nattaque à moyenne distance.",
            "Une sorte de chevalier Fenrir relativement défensif se \nbattant au contact.",
            "Unité rapide mais très faible attaquant au corps-à-corps.\n",//129
            "Unité d'élite extrêmement résistante même à la magie capable \nde lancer des missiles à distance et attaquant au corps-à-corps.",
            "Tireur d'élite effectuant des attaques magiques et attaquant \nà longue portée mais vulnérable.",
            "Unité  d'élite attaquant physiquement au corps-à-corps et à \ncourte distance et sont capables de lancer des salves de magie à moyenne \ndistance. Ils peuvent également utiliser Art de la Guerre afin \nde booster un Fenrir allié. Mais ils sont peu précis et quasiment incapables \nd'esquiver.",
            "Heros Fenrir de corps-à-corps se battant avec une épée géante.\nGrosse brute déchaînée.",//133
            "Héros Krissa effectuant des attaques magiques très \npuissantes au corps-à-corps et excessivement rapide mais légèrement \nvulnérable physiquement.",
            "Unité d'élite très rapide et très puissante, qui possède un \npouvoir permettant d'effectuer beaucoup de dégats d'un seul coup mais très \npeu résistante.",
            "Unité d'élite relativement polyvalente, plus défensive \nqu'offensive, son pouvoir permet d'ailleurs de booster la défense \nphysique et magique d'un Krissa allié.",
            "Unité d'élite polyvalente, effectuant des attaques magiques \net utilisant un pouvoir capable de ralentir les mouvements d'un ennemi.",
            "Unité Krissa relativement faible mais attaquant à distance \net très précise.",//138
            "Unité polyvalente, très résistante à la magie.",//139
            "Combattant de corps-à-corps très efficace physiquement mais \nextrêmement faible face à la magie.",
            "Unité Krissa d'attaque à distance, plutôt rapide mais faible\n face à la magie.",//141
            "Unité attaquant uniquement à longue et très longue portée. \nUtile dans les lignes arrières et assez résistante, elle est par contre \ninutile au corps-à-corps.",
            "Animal Spirit",//143
            "Niveau", //144
            "Attaque", //145
            "Mouvement", //146
            "Pouvoir", //147
            "Connection", // 148
            "Pseudonyme", // 149
            "Addresse IP", // 150
            "Nouvelle", // 151
            "Musique", //152
            "Sons", //153
            "Prêt ?", //154
            "Sauvegarde", //155
            }); 
            #endregion

            #region Anglais
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
            "Power : ", //19
            "Dexterity : ",//20
            "Constitution : ",//21
            "Defense : ",//22
            "Spirit : ",//23
            "Luck : ",//24
            "Speed : ",//25
            "Movement : ",//26
            "Extremly small",//27
            "Small",//28
            "Standard",//29
            "Medium",//30
            "Huge",//31
            "Extremly huge",//32
            "Plain",//33
            "Snow",//34
            "Ice",//35
            "Sand",//36
            "Water",//37
            "Road",//38
            "River",//39
            "Bunker",//40
            "Forest",//41
            "Ruin",//42
            "Hole",//43
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
            "Le blabla sur l'Histoire", //58
            "Le blabla sur la Pingvin", //59
            "Le fabuleux recit sur les Pandawans", //60
            "Le dernier Fenrir", //61
            "Le Krissa dormant", //62
            "L'explication sur les Unités pandawans", //63
            "Host", // 64
            "PANDAWORK.NET", // 65
            "Join", // 66
            "Fullscreen", // 67
            "Pause", // 68
            "Resume", // 69
            "Walkyries",//70
            "Répurgateurs",
            "Tank",
            "Ugins",
            "Pillards",
            "Berserkers",//75
            "Thors",
            "Mugins",
            "Odin",
            "Moines",
            "Yabusames",//80
            "Bushis",
            "Chars Dragons",
            "Mercenaires",
            "Sokeis",
            "Ninjas",//85
            "Snipers",
            "Sayan",
            "Guerriers",
            "Tireurs",
            "Psykers",//90
            "Porteurs de boucliers",
            "Eclaireurs",
            "Dreadnoughts",
            "Fusils Rail",
            "Instructeurs",//95
            "Okami",
            "Chef",
            "Assassins",
            "Légionnaires",
            "Geoliers",//100
            "Maraudeurs",
            "Vermines",
            "Abominations",
            "Alvin dort tout le temps",
            "Alvin branle que dalle",//105
            "Animal Spirit",
            "Basic unit which every Pingvin army has. It attacks body to body with its chainsaw sword and has a shield. Very polyvalent.",
            "Unit using a flamethrower that contrary to common thought is does not deal much damage but is not likely to miss its target often.",
            "Offensively very powerful unit if one ignores its low accuracy. It is also highly resistant but can not respond to body to body. Also its speed is an important asset.",
             "Mage effective offensively but it does not attack body to body. Useful against units resistant to physical attacks but not to magical attacks.",
            "The least expensive unit and therefore the least effective of the army Pingvin.",
            "Elite unit of body to body. It has a great attack force which it can boost thanks to Rage Berserke. It has many hit points but is not very tough, especially against magic.",
            "The most renowned unit among Pingvin. It has a devastatting lightning spell.",
            "Healing unit of the Pingvin's army. They are equipped with heavy weapons in order to feel useful.",
            "Pingvin hero. It rides a eight legs bear. It attacks body to body with its divine spear.",
            "Healing unit of the Pandawan's army. It conducts short magical attacks using his stick.",
            "Pandawan archer equipped with Yumi, an asymmetrical arc, it is quite durable and efficient enough offensively but is very weak body to body.",
            "Pandawan samurai well offensively strong and powerful but it does attack upon contact.",
            "Pandawan tank equipped with scythes and demolition blades and a flamethrower which allows it to be effective at close range. It is not very responsive and above all extremely vulnerable to magic.",
            "Pandawans equipped with modern weapons stolen from other species. Average unit firing with good value for money.",
            "A very stupid Pandawan unit and so very vulnerable to magic. It has an average resistance and efficiency.",
            "Infiltration unit with the ability to make itself invisible. Effective body to body at short and very short range but not very tough.",
            "Unit able to attack effectively over long distances as long as the enemy units are visible. It works very well with units like Ninja. But beware of his weakness to the body to body. ",
            "Pandawan hero with a superior force and whose fur changes color when angry.",
            "Classic unit of body to body. Efficient but not very tough.",
            "Classic firing unit. Weak to body to body.",
            "Only mage Fenrir effective against some resistant physical units such as tanks or Odin. It attacks at medium range. ",
            "A kind of knight relatively defensive and fighting in contact.",
            "Fast but weak unit attacking body to body.",
            "Elite unit highly resistant even to magic, capable of launching missiles from a distance and attacking body to body.",
            "Sniper performing magic attacks and attacking at long range but vulnerable.",
            "Elite unit attacking body to body and at short range. It is able of firing bursts of magic at medium range. It can also use Art of War to boost an ally. But it is imprecise and almost unable to dodge.",
            "Fenrir hero of body to body fighting with a giant sword.",
            "Krissa hero performing very powerful magical attacks at body to body and exceedingly rapid but slightly vulnerable physically.",
            "Elite unit very fast and powerful, which has a power which allows it to make a lot of damage in one go but has very little toughness.",
            "Elite unit relatively polyvalent, more defensive than offensive, its power can also boost physical and magical defense of an ally.",
            "Elite unit polyvalent, performing magic attacks and using a power capable of slowing the movement of an enemy.",
            "Unit Krissa relatively weak but ranged attacker and very precise.",
            "Polyvalent unit, very resistant to magic.",
            "Unit fighting body to body very effective physically but extremely weak against magic.",
            "Krissa unit ranged attack quite fast but weak against magic.",
            "Attacking unit only at long and very long range. Useful in the backs and strong enough, it is useless in close combat.",
            "Animal Spirit",//143
            "Level", //144
            "Attack", //145
            "Move", //146
            "Special", //147
            "Connection", // 148
            "Pseudonym", // 149
            "IP Address", // 150
            "New", // 151
            "Music", //152
            "Sound", //153
            "Ready ?", //154
            "Save", //155
            }); 
            #endregion

            #region Schtroumpf
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
            "Le schtroumpf sur l'Histoire", //58
            "Le schtroumpf sur la Pingvin", //59
            "Le schtroumpfeux recit sur les Pandawans", //60
            "Le dernier Schtroumpf", //61
            "Le Krissa schtroumpfant", //62
            "L'explicaschtroumpf sur les Unischtroumpfs pandawans", //63
            "Schtroumpft", // 64
            "SCHTROUMPFWORK.NET", // 65
            "Reschtroumpf", // 66
            "Plein schtroumpft", // 67
            "Pause", // 68
            "Retour au schtroumpf", // 69
            "Walkyries",//70
            "Répurgateurs",
            "Tank",
            "Ugins",
            "Pillards",
            "Berserkers",//75
            "Thors",
            "Mugins",
            "Odin",
            "Moines",
            "Yabusames",//80
            "Bushis",
            "Chars Dragons",
            "Mercenaires",
            "Sokeis",
            "Ninjas",//85
            "Snipers",
            "Sayan",
            "Guerriers",
            "Tireurs",
            "Psykers",//90
            "Porteurs de boucliers",
            "Eclaireurs",
            "Dreadnoughts",
            "Fusils Rail",
            "Instructeurs",//95
            "Okami",
            "Chef",
            "Assassins",
            "Légionnaires",
            "Geoliers",//100
            "Maraudeurs",
            "Vermines",
            "Abominations",
            "Alvin dort tout le temps",
            "Alvin branle que dalle",//105
            "Animal Spirit",
            "Unité de base des Pingvin présente dans toutes les armées. \nElle attaque au corps-à-corps à l'aide de son épée tronconneuse, \net possède un bouclier. Très polyvalente.",//107
            "Unité utilisant un lance-flamme qui contrairement à la pensée\n commune ne fait pas très mal mais ne risque pas de manquer \nsouvent sa cible.",
            "Unité très puissante offensivement si l'on ne tient pas compte\n de sa faible précision. Elle est également très résistante \nmais ne peut pas riposter au corps-à-corps. De plus sa rapidité est \nun atout non négligeable.",
            "Mage efficace offensivement mais n'attaquant qu'au corps-à-corps.\n Utile face aux unités résistant aux attaques physiques mais \npas aux attaques magiques.",
            "Unité la moins chère et donc la moins efficace de l'armée\n Pingvin.",//111
            "Unité élite de corps-à-corps. Elle possède une grande force\n d'attaque qu'il peut booster grace à son pouvoir Rage Berserke. \nElle a un grand nombre de points de vie mais n'est pas très \nrésitante, surtout face à la magie.",
            "Unité la plus renommée chez les Pingvin. Possède un sort de\n foudre devastateur.",
            "Unité soigneur de l'armée Pingvin. Ils sont equipés d'armes\n lourdes afin d'avoir l'impression de se rendre utiles.",
            "Héros Pingvin. Il chevauche un ours a huit pattes. Il attaque\n au corps-à-corps à l'aide de sa lance divine.",
            "Unité soigneur des Pandawan. Il effectue des attaques magiques\n courtes à l'aide de son baton.",//116
            "Archer Pandawan équipé d'un Yumi, un arc asymétrique, il est \nplutôt résistant et assez efficace offensivement mais est tres \nfaible au corps-à-corps.",
            "Samourai Pandawan bien résistant et performant offensivement \nmais n'attaque qu'au contact.",//118
            "Char Pandawan équipé de faux et de lames de démolition ainsi \nque d'un lance-flamme ce qui lui permet d'être efficace à courte \nportée. Il n'est pas très réactif et surtout extrêmement vulnérable \nà la magie.",
            "Pandawans équipés d'armes modernes volées aux autres espèces. \nUnité moyenne de tir avec un bon rapport qualité-prix.",
            "Unité Pandawan très stupide donc très vulnérable à la magie. \nDispose d'une résistance et d'une efficacité moyenne.",
            "Unité d'inflitration dotée de la capacité de se rendre invisible.\n Efficace au corps-à-corps et à très courte portée mais peu \nrésistant.",
            "Unité capable d'attaquer efficacement à très longue distance \npourvu que les unités adverses soient visibles. Elle fonctionne donc \ntrès bien avec les unités d'inflitration comme le Ninja. Mais \nattention à sa faiblesse au corps-à-corps.",
            "Héros Pandawan doté d'une force supérieure et dont la fourrure \nchange de couleur lorsqu'il est en colère.",
            "Unité de corps-à-corps classique. Efficace mais peu résistante.\n",//125
            "Unité classique d'attaquant à distance. Faible au corps-à-corps.\n",//126
            "Seul mage Fenrir permettant d'être efficace contres certaines \nunités très resistantes physiques par exemple les tanks ou Odin. Il \nattaque à moyenne distance.",
            "Une sorte de chevalier Fenrir relativement défensif se \nbattant au contact.",
            "Unité rapide mais très faible attaquant au corps-à-corps.\n",//129
            "Unité d'élite extrêmement résistante même à la magie capable \nde lancer des missiles à distance et attaquant au corps-à-corps.",
            "Tireur d'élite effectuant des attaques magiques et attaquant \nà longue portée mais vulnérable.",
            "Unité  d'élite attaquant physiquement au corps-à-corps et à \ncourte distance et sont capables de lancer des salves de magie à moyenne \ndistance. Ils peuvent également utiliser Art de la Guerre afin \nde booster un Fenrir allié. Mais ils sont peu précis et quasiment incapables \nd'esquiver.",
            "Heros Fenrir de corps-à-corps se battant avec une épée géante.\nGrosse brute déchaînée.",//133
            "Héros Krissa effectuant des attaques magiques très \npuissantes au corps-à-corps et excessivement rapide mais légèrement \nvulnérable physiquement.",
            "Unité d'élite très rapide et très puissante, qui possède un \npouvoir permettant d'effectuer beaucoup de dégats d'un seul coup mais très \npeu résistante.",
            "Unité d'élite relativement polyvalente, plus défensive \nqu'offensive, son pouvoir permet d'ailleurs de booster la défense \nphysique et magique d'un Krissa allié.",
            "Unité d'élite polyvalente, effectuant des attaques magiques \net utilisant un pouvoir capable de ralentir les mouvements d'un ennemi.",
            "Unité Krissa relativement faible mais attaquant à distance \net très précise.",//138
            "Unité polyvalente, très résistante à la magie.",//139
            "Combattant de corps-à-corps très efficace physiquement mais \nextrêmement faible face à la magie.",
            "Unité Krissa d'attaque à distance, plutôt rapide mais faible\n face à la magie.",//141
            "Unité attaquant uniquement à longue et très longue portée. \nUtile dans les lignes arrières et assez résistante, elle est par contre \ninutile au corps-à-corps.",
            "Animal Spirit",//143
            "Schtroumpf", //144
            "Attaque", //145
            "Mouvement", //146
            "Pouvoir", //147
            "Connection", // 148
            "Schtroumpfonyme", // 149
            "Schtroumpf IP", // 150
            "Nouvelle", // 151
            "Musique", //152
            "Sons", //153
            "Schtroumpf ?", //154
            "Schtroumpf", //155
            }); 
            #endregion

            #region Espagnol
            langues.Add("Espagnol", new string[]{
            "Jugar", // 0
            "Editar", // 1
            "Suplemento", // 2
            "Optiones", // 3
            "Dejar", // 4
            "Volver", // 5
            "Juego clasico", // 6
            "Campaña", // 7
            "Ligna", // 8
            "Editor de mapa", // 9
            "Editor de armada", // 10
            "Enciclopedia", // 11
            "Creditos", // 12
            "Graficos", // 13
            "Juego", // 14
            "Sonido",// 15
            "Crear",// 16
            "Modificar",// 17
            "Puntos quedantes : ", // 18
            "Fuerza : ", //19
            "Dexteridad : ",//20
            "Constitucion : ",//21
            "Defensa : ",//22
            "Espiritu : ",//23
            "Fortuna : ",//24
            "Velocidad : ",//25
            "Movimiento : ",//26
             "Muy pequeña",//27
                      "Pequeña",//28
                      "Normal",//29
                      "Medio",//30
                      "Grande",//31
                      "Muy grande",//32
                "Llanura",//33
                "Nieve",//34
                "Hielo",//35
                "Arena",//36
                "Agua",//37
                "Ruta",//38
                "Rio",//39
                "Fortificacion",//40
                "Bosque",//41
                "Ruina",//42
                "Cratér",//43
                "Pueblo",//44
                "Montaña",//45
                "Valle",//46
                "Lisar",//47
                "Nada",//48
                "Cepillar",//49
                "Tamaño",//50
            "PRESENTE", //51
            "Historia", //52
            "Pingvin", //53
            "Pandawan", //54
            "Fenrir", //55
            "Krissa", //56
            "Unidades", //57
            "Año 2014 : Raros son los escritos del tiempo pasado que hablan de la vuelta à la normalidad después de un año de cataclismo, cuando las fuerzas naturales se han ponido salvajes.Alli y alla, las rumores de un castigo divino se derraman :Hablamos de monstros gigantescos con poderes tan fuertes que son capazde destruir las ciudades. Los raros sobreviviantes no se mustran, la natura se vuelvo loca, las bestias salvages, el cielo negro, la tempesta violento. Los volcanos entran en erupcion perpetual, los vientos del norte son tan fuertes que es imposible de salir en la noche sin riscar su vida. Los mares se derraman, la humanidad disparece poco a poco. Las grandes ciudades estan destruidas y la tecnologia no fonciona mas sin milagro. La hora es sombra para los hombres. Año 2222 : La vida empieza de nuevo, la situacion se calmo. Las aldeas se forman, la raza humana no sobrevivio. Los animales retomaron una vida tranquila, sin preocuparse de otros peligros de destruccion. Es como si la natura misma intenta de ocultar los tiempos dificiles que pasaron. Algunas especias han cambiado... Año 2300 : Los primeros reinos se forman, un sistema feodal se instala. La antigua generacion disparecio totalmenta, y el saber del pasado tambien. El primer imperio Fenrir, gran pueblo de lobos guerreros, esta sacrado con la unificacion de mas de diez pequenitos reinos, mas con la fuerza y el uso de la guerra. En el norte los Pingvin construyen castillos flotantes, viven en autarcia y hacen tranquilamente sus experiencias. Los Pandawans cultivan su arroz para la cerveza tan buena. Sobre la tierra son los Krissas que cavan galerias y citadelas en donde los otros ojos no le pueden ver. Año 2314 : Los primeros juegos de Animalotopia. Quien sera el futuro protector de Blacksheep ? Las fuerzas de cada uno son diferentes. A los Fenrir le gustan el metal, las espadas y los canones. Sus lamas inspiran la confianza. Los Pingvin estan armados de equipamiento ingeniosos y sorprendientes. Pandawans usan una fuerza magica que proviene de las bebibas y de la meditacion. No le gustan la guerra pero iran si se necesita. Al fin los Krissas, imprevisibles y poco confiables. Año 2377 : En nuestros dias. ", //58
            "El Pingvin es una especia de pajaro marino que vive en la parte del sur de Animalotopia. Le gusta particularmente  el climato glacial. No pueden volar pero son demasiado rapidos en la agua. Son les reyes de los 6 mares. El Pingvin come pescados, y otros productos que encuentran en su teritorio marino tambien para hacer comercio. El animal es conocido por sur grandes descubrimientos en las implantaciones mecanicas y aumentaciones de las facultades del cuerpo. La armada Pingvin tiene su especializacion en la robotica, la gran majoria de sus soldados estanaumentados. El armamiento tiene principalmente armas nucleares y una produccion de maquinas de guerra gigantescas.", //59
            "Le fabuleux recit sur les Pandawans", //60
            "En la carne se encuentra la fuerza. Para los Fenrir la vida es combate y fiesta. Son brutales, combativos y leales. Esos lobos guerroros viven al limite de los bosques y de las montañas. El honor es muy conocido entre los Fenrirs, vale casi mas que su propia vida. coraje Fenrir es incomensurable, los generales tienen una habilitad de combate muy famosa. Solo los mejores pueden dirigir al pueblo. Porque hablamos de un pueblo que le gusta la guerra, todos viven entre los muros gigantescos de piedra y de metal que protegen sus citadelas. La iniciacion de los Fenrir al arte de la guerra empieza muy temprano. Antes de la majoria de los jovenes Fenrir se van a cazar durante un año. Los riscos, la posibilidad de morir. El placer de los combates heroicos, eso es la vida de un Fenrir. Las historias de batallas epicas animan las horas de comida, que son siempre entre une cerveza y piezas de carne. El arte Fenrir se concentra en la maestria de la fragua. Los artesanos hacen la fortuna de sus familias, porque es bueno de ser un gran guerrero pero sin una buena espada no vale la pena. El avanzamiento tecnologico interesa mucho los jefes Fenrir, que dan mucho de su dinero para mejorar siempre sus armas y armuras, para ser hasta el fin la mejora armada del mundo.", //61
            "Le Krissa dormant", //62
            "L'explication sur les Unités pandawans", //63
            "Alojar", // 64
            "PANDAWORK.NET", // 65
            "Alcanzar", // 66
            "Pantalla entera", // 67
            "Pausa", // 68
            "Vuelta al juego", // 69
            "Walkyries",//70
            "Répurgateurs",
            "Tank",
            "Ugins",
            "Pillards",
            "Berserkers",//75
            "Thors",
            "Mugins",
            "Odin",
            "Moines",
            "Yabusames",//80
            "Bushis",
            "Chars Dragons",
            "Mercenaires",
            "Sokeis",
            "Ninjas",//85
            "Snipers",
            "Sayan",
            "Guerriers",
            "Tireurs",
            "Psykers",//90
            "Porteurs de boucliers",
            "Eclaireurs",
            "Dreadnoughts",
            "Fusils Rail",
            "Instructeurs",//95
            "Okami",
            "Chef",
            "Assassins",
            "Légionnaires",
            "Geoliers",//100
            "Maraudeurs",
            "Vermines",
            "Abominations",
            "Alvin duerme todo el tiempo",
            "Alvin se hace la paja",//105
            "Animal Spirit",
            "Unidades basicas Pingvin encontradas en los ejercitos. \nAtaque cuerpo a cuerpo con una sierra electrica. \net tiene un escudo. Muy polivalente",//107
            "Unidad que ataque con una lanza de fuego que no causa estragos importantes,\n pero no va a fallar su blanco.",
            "Unidad muy poderosa ofensivamente pero con una precision muy debil.\n Muy resistante, pero no puede ripostar cuerpo a cuerpo.\nAdemas su velocidad esta muy interesante.",
            "Mago ofensivamente poderoso que ataque solo cuerpo a cuerpo.\n Demasiado util contra las unidades muy resistantes a los ataques fisicas.",
            "Unidad la mas barata del ejercito Pingvin.",//111
            "Unidad elite de cuerpo a cuerpo. Tiene una gran fuerza de ataque, \nque puede amplificarse con su poder de Rabia. \n Tiene muchos puntos de vida pero poco de defensa, sobre todo frente a la magia.",
            "Unidad la mas famosa del ejercito Pingvin. Puede liberar el poder de los rayos sobre sus enemigos.",
            "Unidad cuidador, equipada de una armadura grande.",
            "Héroe Pingvin. Monta un oso con ocho patas y ataque cuerpo a cuerpo con su lanza divina.",
            "Unidad cuidador de los Pandawan. Usa magia para atacar.",//116
            "Arquero Pandawan muy resistante y eficiente al ataque pero tiene poco de defensa.",
            "Samourai Pandawan con una buena fuerza de ataque y muy resistante, pero solo cuerpo a cuerpo.",//118
            "Carro de combate Pandawan equipado de lamas y de una lanza de fuego para ser eficiente a pequeña distancia.\n Su velocidad y su resistancia a la magia son muy debiles.",
            "Unidades Pandawan equipados de armas modernas robadas a los otros especies. \nCapacidad de tiro respectable y medio barato.",
            "Unidades Pandawan estupidas y con poco de resistancia a la magia. \nEficacia mediana.",
            "Unidades con la capacidad de invisibilidad.\n Efficientes cuerpo a cuerpo pero tienen poco de resistancia.",
            "Unidades competentes para atacar muy lejo, si los enemigos son visibles. \n Buena combinacion con el Ninja. Pero no deja que los enemigos se acercan.",
            "Héroe Pandawan con una fuerza impresionante y un piél que cambia de color cuando esta enfadado.",
            "Unidades clasicas, eficientes cuerpo a cuerpo pero poco de resistancia.",//125
            "Unidad que ataque a gran distancia, pero debil cuerpo a cuerpo.",//126
            "Unico mago Fenrir, muy eficaz contra las unidades que tienen una gran defensa. \nAtaque a media distancia.",
            "Caballero Fenrir muy defensivo que lucha cuerpo a cuerpo.",
            "Unidad rapida de cuerpo a cuerpo con pocos puntos de vida.",//129
            "Unidad elite que lucha cuerpo a cuerpo, muy resistante tanto a los ataques fisicas que magicas. \nCapaz de lanzar misiles a los enemigos mas lejos.",
            "Tirador de élite que usa ataques magicas a distancia muy largas.",
            "Unidades de elite que usa ataques fisicas cuerpo a cuerpo y a corta distancia. \nPuede lanzar salvas magicas a distancia mediana. \nCon el poder del Arte de Guerra puede aumentar un compañero Fenrir. \nPero esquivan raramente los ataques.",
            "Héroe Fenrir de cuerpo a cuerpo, equipado de una espada gigante.\nUna bruta de combate.",//133
            "Héroe Krissa usando ataques magicas muy poderas al cuerpo a cuerpo y demasiado rapido. \n Una resistancia fisica limitada.",
            "Unidad de elite muy rapida y poderosa. Tiene un poder que inflige daños importantes pero la unidad no tiene muchos puntos de vida.",
            "Unidad de elite polivalente, mas defensiva que ofensiva plus défensive. \nSu poder aumenta la defensa y la resistancia de un Krissa.",
            "Unidad de elite polivalente, usa ataques magicas y tiene un poder que reduce los movimientos de un enemigo.",
            "Unidad Krissa relativamente debil pero una precision muy corecta en las ataques de distancia.",//138
            "Unidad polivalente, muy resistante a la magia.",//139 
            "Combatante fisico de cuerpo a cuerpo, pero demasiado debil frente a la magia.",
            "Unidad Krissa que ataque a distancia, una velocidad corecta pero debil frente a la magia.",//141
            "Unidad que ataque unicamente a distancia muy larga. \nUtil atras de sus compañeros y tiene una buena resistancia. \nNo tiene ninguna utilidad al cuerpo a cuerpo.",
            "Animal Spirit",//143
            "Nivel", //144
            "Ataque", //145
            "Movimiento", //146
            "Poder", //147
            "Conexion", // 148
            "Pseudonimo", // 149
            "Addresse IP", // 150
            "Neo", // 151
            "Musica", //152
            "FX", //153
            "Ser nisto ?", //154
            "Salvar", //155
            }); 
            #endregion
        }
    }
}
