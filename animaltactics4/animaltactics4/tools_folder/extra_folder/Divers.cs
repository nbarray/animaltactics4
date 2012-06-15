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
        ChefKrissa,//60
        Assassin,//30
        Legionnaire,//30
        Geolier,//30
        Maraudeur,//30
        Vermine,//30
        Abomination,//30
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
    #endregion

    static class Divers
    {
        static public readonly int X = 1200;
        static public readonly int Y = 900;

        public static void serializer(object o, string file)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(file, FileMode.Create);
            formatter.Serialize(stream, o);
            stream.Close();
        }
        public static object deserializer(string file)
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream filestream = new FileStream(file, FileMode.Open);
            object r = binary.Deserialize(filestream);
            filestream.Close();
            return r;
        }
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
    }
}
