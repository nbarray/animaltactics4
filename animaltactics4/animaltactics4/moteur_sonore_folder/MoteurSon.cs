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
        static public Dictionary<string, SoundEffectInstance> bankEffect;

        static public void Initialize(ContentManager content_)
        {
            MediaPlayer.IsRepeating = false;
            MediaPlayer.Volume = 0.1f;
            bankSong = new Dictionary<string, Song>();

            bankEffect = new Dictionary<string, SoundEffectInstance>();
            bankEffect.Add("bouton", (content_.Load<SoundEffect>("Son\\Bruitage\\son_bouton")).CreateInstance());

            foreach (String item in bankEffect.Keys)
            {
                bankEffect[item].Volume = 0.1f;
            }
        }

        static public void Play(string name_)
        {
            MediaPlayer.Play(bankSong[name_]);
        }
        static public void PlayFX(string name_)
        {
            bankEffect[name_].Play();
        }
    }
}
