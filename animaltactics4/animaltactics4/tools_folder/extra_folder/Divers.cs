using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
    enum brouillardDeGuerre
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
        Krissa8,//30
        Krissa9,//30
        Overlord//0
    }
    enum e_pouvoir
    {
        PandaSceau, PandaSniper, PandaNinja,
        PingvinSoin, PingvinThor, PingvinRage,
        FenrirMissiles, FenrirBoost, FenrirRailgun,
        Krissa1, Krissa2, Krissa3
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
                    return "Repurgateurs";
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
                    return "Legionnaires";
                case e_classe.KrissaGeolier:
                    return "Geoliers";
                case e_classe.KrissaMaraudeur:
                    return "Maraudeurs";
                case e_classe.KrissaVermine:
                    return "Vermines";
                case e_classe.KrissaAbomination:
                    return "Abominations";
                case e_classe.Krissa8:
                    return "Alvin dort tout le temps";
                case e_classe.Krissa9:
                    return "Alvin branle que dalle";
                default:
                    return "Animal Spirit";
            }
        }
    }
}
