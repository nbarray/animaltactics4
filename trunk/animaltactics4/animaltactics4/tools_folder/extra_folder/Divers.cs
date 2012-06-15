using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace animaltactics4
{
    public enum TypedAura
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
    public enum e_EtatAnim
    {
        mouvement1, mouvement2, mouvement3,
        repos1, repos2
    }
    public enum mouv
    {
        Sud, Nord, Est, Ouest
    }
    public enum TypeUnite
    {
        Base,
        Elite,
        Heros,
        PNJ,
        Overlord
    }
    public enum brouillardDeGuerre
    {
        ToutVisible, ToutVisite, Normal
    }
    public enum e_menu
    {
        Principal, Jeu, Editeur, Extra, Option
    }
    public enum e_race
    {
        Fenrir,
        Krissa,
        Pandawan,
        Pingvin,
        Random
    }
    public enum e_classe
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
    public enum e_pouvoir
    {
        PandaSceau, PandaSniper, PandaNinja,
        PingvinSoin, PingvinThor, PingvinRage,
        FenrirMissiles, FenrirBoost, FenrirRailgun,
        Krissa1, Krissa2, Krissa3
    }
    public enum e_typedAura
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
    public enum e_typeDePouvoir
    {
        Degat,
        Soin,
        Boost
    }
    public enum e_typeDeBoost
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
    public enum e_modeAction
    {
        Attaque, Mouvement, Pouvoir
    }
    public enum e_typeDePartie
    {
        Echiquier, Joute, Tresor, Colline
    }
    public enum e_Typedesol
    {
        herbe,
        sable,
        neige,
        mer,
        banquise,
        desert,
        vide
    }
    public enum e_Typederoute
    {
        route,
        pont,
        vide
    }
    public enum e_Riviere
    {
        riviere,
        vide
    }
    public enum e_Decorarriere
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
    public enum e_Decoravant
    {
        foret,
        bunker,
        iceBunker,
        vide
    }
    public enum e_Cache
    {
        Invisible, InvisibleAmi, Visible
    }

    static class Divers
    {
        static public readonly int X = 1200;
        static public readonly int Y = 900;
    }
}
