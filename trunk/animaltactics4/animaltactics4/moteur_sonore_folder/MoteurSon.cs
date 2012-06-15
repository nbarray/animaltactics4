using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace animaltactics4
{
    static class MoteurSon
    {
        static public Dictionary<string, Song> bankSong;
        static public Dictionary<string, SoundEffect> bankEffect;

        static public void Initialize(ContentManager content_)
        {
            MediaPlayer.IsRepeating = false;
            bankSong = new Dictionary<string, Song>();
            bankSong.Add("porte", content_.Load<Song>("Son\\Bruitage\\son_porte"));
            bankSong.Add("bouton", content_.Load<Song>("Son\\Bruitage\\son_bouton"));

            bankEffect = new Dictionary<string, SoundEffect>();
            bankEffect.Add("deprimePorte", content_.Load<SoundEffect>("Son\\Bruitage\\depriemPorte"));
        }

        static public void Play(string name_)
        {
            MediaPlayer.Play(bankSong[name_]);
        }
        static public void PlayFX(string name_)
        {
            bankEffect[name_].CreateInstance().Play();
        }
    }
}
