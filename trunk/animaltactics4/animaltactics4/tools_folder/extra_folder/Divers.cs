using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    #region ENUMERATIONS
    enum TypedAura
    {
        BoostAttaque,
        BoostArmure,
        BoostPuissance,
        BoostResistance,
        BoostPrecision,
        BoostCoupCritique,
        BoostEsquive,
        BoostInitiative
    }
    enum e_EtatAnim
    {
        mouvement1, mouvement2, mouvement3,
        repos1, repos2
    }
    enum mouv
    {
        Sud, Nord, Est, Ouest
    }
    enum TypeUnite
    {
        Base,
        Elite,
        Heros,
        PNJ,
        Overlord
    }
    enum e_brouillardDeGuerre
    {
        ToutVisible, ToutVisite, Normal
    }
    enum e_menu
    {
        Principal, Jeu, Editeur, Extra, Option
    }
    enum e_race
    {
        Fenrir,
        Krissa,
        Pandawan,
        Pingvin,
        Random
    }
    enum e_classe
    {
        PingvinWalkyrie,//37
        PingvinLanceFlammes,//30
        PingvinChar,//46
        PingvinUgin,//30
        PingvinBolter,//32
        PingvinBerserker,//48
        PingvinThor,//64
        PingvinMugin,//40
        PingvinOdin,//68
        PandawanMoine,//38
        PandawanYabusame,//44
        PandawanBushi,//36
        PandawanCharDragon,//45
        PandawanMerco,//36
        PandawanSokei,//31
        PandawanNinja,//41
        PandawanSniper,//47
        PandawanSayan,//50
        FenrirWarBlade,//33
        FenrirTireur,//42
        FenrirPsyker,//39
        FenrirBouclier,//37
        FenrirEclaireur,//31
        FenrirDreadnought,//42
        FenrirRailgun,//63
        FenrirWarlord,//56
        FenrirOkami,//50
        KrissaChef,//60
        KrissaAssassin,//30
        KrissaLegionnaire,//30
        KrissaGeolier,//30
        KrissaMaraudeur,//30
        KrissaVermine,//30
        KrissaAbomination,//30
        KrissaDesperado,//30
        KrissaCanonnier,//30
        Overlord//0
    }
    enum e_pouvoir
    {
        PandaSceau, PandaSniper, PandaNinja,
        PingvinSoin, PingvinThor, PingvinRage,
        FenrirMissiles, FenrirBoost, FenrirRailgun,
        Krissa1, Legionnaire, Assassinat
    }
    enum e_typedAura
    {
        BoostAttaque,
        BoostArmure,
        BoostPuissance,
        BoostResistance,
        BoostPrecision,
        BoostCoupCritique,
        BoostEsquive,
        BoostInitiative
    }
    enum e_typeDePouvoir
    {
        Degat,
        Soin,
        Boost
    }
    enum e_typeDeBoost
    {
        BonusAttaque,
        BonusArmure,
        BonusPuissance,
        BonusResistance,
        BonusPrecision,
        BonusCoupCritique,
        BonusEsquive,
        BonusInitiative
    }
    enum e_modeAction
    {
        Attaque, Mouvement, Pouvoir
    }
    enum e_typeDePartie
    {
        Echiquier, Joute, Tresor, Colline
    }
    enum e_Typedesol
    {
        herbe,
        sable,
        neige,
        mer,
        banquise,
        desert,
        vide
    }
    enum e_Typederoute
    {
        route,
        pont,
        vide
    }
    enum e_Riviere
    {
        riviere,
        vide
    }
    enum e_Decorarriere
    {
        foret,
        bunker,
        iceBunker,
        ruine,
        villagePanda,
        villagePingvin,
        villageKrissa,
        campementFenrir,
        cratere,
        vide
    }
    enum e_Decoravant
    {
        foret,
        bunker,
        iceBunker,
        vide
    }
    enum e_Cache
    {
        Invisible, InvisibleAmi, Visible
    }
    public enum e_pinceau
    {
        Plaine, Neige, Banquise, Sable, Eau, Route, Riviere, Bunker, Foret, Ruine, Cratere, Village, Montagne, Vallee, Lissage, Rien
    }
    public enum e_toolSize
    {
        XSmall, Small, Standard, Medium, Large, XLarge
    }
    public enum e_etatDeroulant
    {
        Ouvert, Montant, Ferme, Descendant
    }
    #endregion

    static class Divers
    {
        static public readonly int X = 1200;
        static public readonly int Y = 900;

        //Loohy
        public static void serializer(object o, string file)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(file, FileMode.Create);
            formatter.Serialize(stream, o);
            stream.Close();
        }
        //Loohy
        public static object deserializer(string file)
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream filestream = new FileStream(file, FileMode.Open);
            object r = binary.Deserialize(filestream);
            filestream.Close();
            return r;
        }
        //Loohy
        public static void telechargerList(ref ListeArmee list_, string file_)
        {
            try
            {
                list_ = (ListeArmee)deserializer(file_);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Loohy
        public static ListeArmee obtenirList(string file_)
        {
            try
            {
                return (ListeArmee)deserializer(file_);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Loohy
        public static void telechargerMap(ref MoteurGraphique earthPenguin_, string file_)
        {
            try
            {
                earthPenguin_ = (MoteurGraphique)deserializer(file_);
            }
            catch (Exception)
            {
                earthPenguin_ = new MoteurGraphique(32, 32);
                earthPenguin_.mapAleaFaceToFace(32, 32, 4, 5, 4);
                throw;
            }
        }
        //Loohy
        public static string getName(e_classe c_)
        {
            switch (c_)
            {
                case e_classe.PingvinWalkyrie:
                    return "Walkyries";
                case e_classe.PingvinLanceFlammes:
                    return "Répurgateurs";
                case e_classe.PingvinChar:
                    return "Tank";
                case e_classe.PingvinUgin:
                    return "Ugins";
                case e_classe.PingvinBolter:
                    return "Pillards";
                case e_classe.PingvinBerserker:
                    return "Berserkers";
                case e_classe.PingvinThor:
                    return "Thors";
                case e_classe.PingvinMugin:
                    return "Mugins";
                case e_classe.PingvinOdin:
                    return "Odin";
                case e_classe.PandawanMoine:
                    return "Moines";
                case e_classe.PandawanYabusame:
                    return "Yabusames";
                case e_classe.PandawanBushi:
                    return "Bushis";
                case e_classe.PandawanCharDragon:
                    return "Chars Dragons";
                case e_classe.PandawanMerco:
                    return "Mercenaires";
                case e_classe.PandawanSokei:
                    return "Sokeis";
                case e_classe.PandawanNinja:
                    return "Ninjas";
                case e_classe.PandawanSniper:
                    return "Snipers";
                case e_classe.PandawanSayan:
                    return "Sayan";
                case e_classe.FenrirWarBlade:
                    return "Guerriers";
                case e_classe.FenrirTireur:
                    return "Tireurs";
                case e_classe.FenrirPsyker:
                    return "Psykers";
                case e_classe.FenrirBouclier:
                    return "Porteurs de boucliers";
                case e_classe.FenrirEclaireur:
                    return "Eclaireurs";
                case e_classe.FenrirDreadnought:
                    return "Dreadnoughts";
                case e_classe.FenrirRailgun:
                    return "Fusils Rail";
                case e_classe.FenrirWarlord:
                    return "Instructeurs";
                case e_classe.FenrirOkami:
                    return "Okami";
                case e_classe.KrissaChef:
                    return "Chef";
                case e_classe.KrissaAssassin:
                    return "Assassins";
                case e_classe.KrissaLegionnaire:
                    return "Légionnaires";
                case e_classe.KrissaGeolier:
                    return "Geoliers";
                case e_classe.KrissaMaraudeur:
                    return "Maraudeurs";
                case e_classe.KrissaVermine:
                    return "Vermines";
                case e_classe.KrissaAbomination:
                    return "Abominations";
                case e_classe.KrissaDesperado:
                    return "Alvin dort tout le temps";
                case e_classe.KrissaCanonnier:
                    return "Alvin branle que dalle";
                default:
                    return "Animal Spirit";
            }
        }
        public static string getText(e_classe c_)
        {
            switch (c_)
            {
                case e_classe.PingvinWalkyrie:
                    return "Unité de base des Pingvin présente dans toutes les armées. \nElle attaque au corps-à-corps à l'aide de son épée tronconneuse, \net possède un bouclier. Très polyvalente.";

                case e_classe.PingvinLanceFlammes:
                    return "Unité utilisant un lance-flamme qui contrairement à la pensée\n commune ne fait pas très mal mais ne risque pas de manquer \nsouvent sa cible.";

                case e_classe.PingvinChar:
                    return "Unité très puissante offensivement si l'on ne tient pas compte\n de sa faible précision. Elle est également très résistante \nmais ne peut pas riposter au corps-à-corps. De plus sa rapidité est un atout non négligeable.";

                case e_classe.PingvinUgin:
                    return "Mage efficace offensivement mais n'attaquant qu'au corps-à-corps.\n Utile face aux unités résistant aux attaques physiques mais \npas aux attaques magiques.";

                case e_classe.PingvinBolter:
                    return "Unité la moins chère et donc la moins efficace de l'armée\n Pingvin.";

                case e_classe.PingvinBerserker:
                    return "Unité élite de corps-à-corps. Elle possède une grande force\n d'attaque qu'il peut booster grace à son pouvoir Rage Berserke. \nElle a un grand nombre de points de vie mais n'est pas très résitante, surtout face à la magie.";

                case e_classe.PingvinThor:
                    return "Unité la plus renommée chez les Pingvin. Possède un sort de\n foudre devastateur.";

                case e_classe.PingvinMugin:
                    return "Unité soigneur de l'armée Pingvin. Ils sont equipés d'armes\n lourdes afin d'avoir l'impression de se rendre utiles.";

                case e_classe.PingvinOdin:
                    return "Héros Pingvin. Il chevauche un ours a huit pattes. Il attaque\n au corps-à-corps à l'aide de sa lance divine.";

                case e_classe.PandawanMoine:
                    return "Unité soigneur des Pandawan. Il effectue des attaques magiques\n courtes à l'aide de son baton.";

                case e_classe.PandawanYabusame:
                    return "Archer Pandawan équipé d'un Yumi, un arc asymétrique, il est \nplutôt résistant et assez efficace offensivement mais est tres \nfaible au corps-à-corps.";

                case e_classe.PandawanBushi:
                    return "Samourai Pandawan bien résistant et performant offensivement \nmais n'attaque qu'au contact.";

                case e_classe.PandawanCharDragon:
                    return "Char Pandawan équipé de faux et de lames de démolition ainsi \nque d'un lance-flamme ce qui lui permet d'être efficace à courte \nportée. Il n'est pas très réactif et surtout extrêmement vulnérable à la magie.";

                case e_classe.PandawanMerco:
                    return "Pandawans équipés d'armes modernes volées aux autres espèces. \nUnité moyenne de tir avec un bon rapport qualité-prix.";

                case e_classe.PandawanSokei:
                    return "Unité Pandawan très stupide donc très vulnérable à la magie. \nDispose d'une résistance et d'une efficacité moyenne.";

                case e_classe.PandawanNinja:
                    return "Unité d'inflitration dotée de la capacité de se rendre invisible.\n Efficace au corps-à-corps et à très courte portée mais peu \nrésistant.";

                case e_classe.PandawanSniper:
                    return "Unité capable d'attaquer efficacement à très longue distance \npourvu que les unités adverses soient visibles. Elle fonctionne donc \ntrès bien avec les unités d'inflitration comme le Ninja. Mais attention à sa faiblesse au corps-à-corps.";

                case e_classe.PandawanSayan:
                    return "Héros Pandawan doté d'une force supérieure et dont la fourrure \nchange de couleur lorsqu'il est en colère.";

                case e_classe.FenrirWarBlade:
                    return "Unité de corps-à-corps classique. Efficace mais peu résistante.\n";

                case e_classe.FenrirTireur:
                    return "Unité classique d'attaquant à distance. Faible au corps-à-corps.\n";

                case e_classe.FenrirPsyker:
                    return "Seul mage Fenrir permettant d'être efficace contres certaines \nunités très resistantes physiques par exemple les tanks ou Odin. Il \nattaque à moyenne distance.";

                case e_classe.FenrirBouclier:
                    return "Une sorte de chevalier Fenrir relativement défensif se \nbattant au contact.";

                case e_classe.FenrirEclaireur:
                    return "Unité rapide mais très faible attaquant au corps-à-corps.\n";

                case e_classe.FenrirDreadnought:
                    return "Unité d'élite extrêmement résistante même à la magie capable \nde lancer des missiles à distance et attaquant au corps-à-corps.";

                case e_classe.FenrirRailgun:
                    return "Tireur d'élite effectuant des attaques magiques et attaquant \nà longue portée mais vulnérable.";

                case e_classe.FenrirWarlord:
                    return "Unité  d'élite attaquant physiquement au corps-à-corps et à \ncourte distance et sont capables de lancer des salves de magie à moyenne \ndistance. Ils peuvent également utiliser Art de la Guerre afin de booster un Fenrir allié. Mais ils sont peu précis et quasiment incapables d'esquiver.";

                case e_classe.FenrirOkami:
                    return "Heros Fenrir de corps-à-corps se battant avec une épée géante.\n";

                case e_classe.KrissaChef:
                    return "Héros Krissa doté effectuant des attaques magiques très \npuissantes au corps-à-corps et excessivement rapide mais légèrement vulnérable \nphysiquement.";

                case e_classe.KrissaAssassin:
                    return "Unité d'élite très rapide et très puissante, qui possède un \npouvoir permettant d'effectuer beaucoup de dégats d'un seul coup mais très \npeu résistante.";

                case e_classe.KrissaLegionnaire:
                    return "Unité d'élite relativement polyvalente, plus défensive \nqu'offensive, son pouvoir permet d'ailleurs de booster la défense physique et \nmagique d'un Krissa allié.";

                case e_classe.KrissaGeolier:
                    return "Unité d'élite polyvalente, effectuant des attaques magiques \net utilisant un pouvoir capable de ralentir les mouvements d'un ennemi.";

                case e_classe.KrissaMaraudeur:
                    return "Unité Krissa relativement faible mais attaquant à distance \net très précise.";

                case e_classe.KrissaVermine:
                    return "Unité polyvalente, très résistante à la magie.";

                case e_classe.KrissaAbomination:
                    return "Combattant de corps-à-corps très efficace physiquement mais \nextrêmement faible face à la magie.";

                case e_classe.KrissaDesperado:
                    return "Unité Krissa d'attaque à distance, plutôt rapide mais faible\n face à la magie.";

                case e_classe.KrissaCanonnier:
                    return "Unité attaquant uniquement à longue et très longue portée. \nUtile dans les lignes arrières et assez résistante, elle est par contre \ninutile au corps-à-corps.";
                default:
                    return "Animal Spirit";
            }
        }

        public static string String_Of_Key(Keys k)
        {
            if (Keyboard.GetState() == new KeyboardState(new Keys[]{Keys.None, k}))
            {
                return k.ToString().ToLower();
            }
            else if (Keyboard.GetState() == new KeyboardState(new Keys[] { Keys.None, k, Keys.LeftShift }))
            {
                return k.ToString().ToUpper();
            }
            else
            {
                return "";
            }
            
        }
    }
}
