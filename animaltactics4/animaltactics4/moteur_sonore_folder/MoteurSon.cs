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
            bankEffect.Add("clic", (content_.Load<SoundEffect>("Son\\Bruitage\\sf_os_broye_03")).CreateInstance());
            bankEffect.Add("Pandawan0", (content_.Load<SoundEffect>("Son\\Bruitage\\Chewbaka")).CreateInstance());
            bankEffect.Add("Pingvin0", (content_.Load<SoundEffect>("Son\\Bruitage\\Pingvin")).CreateInstance());
            bankEffect.Add("Fenrir0", (content_.Load<SoundEffect>("Son\\Bruitage\\fenrir")).CreateInstance());
            bankEffect.Add("Krissa0", (content_.Load<SoundEffect>("Son\\Bruitage\\sf_souris")).CreateInstance());
            bankEffect.Add("Pandawan1", (content_.Load<SoundEffect>("Son\\Bruitage\\panda")).CreateInstance());
            bankEffect.Add("Pingvin1", (content_.Load<SoundEffect>("Son\\Bruitage\\pingvin2")).CreateInstance());
            bankEffect.Add("Fenrir1", (content_.Load<SoundEffect>("Son\\Bruitage\\Meute")).CreateInstance());
            bankEffect.Add("Krissa1", (content_.Load<SoundEffect>("Son\\Bruitage\\krissa")).CreateInstance());
            bankEffect.Add("Pandawan2", (content_.Load<SoundEffect>("Son\\Bruitage\\panda2")).CreateInstance());
            bankEffect.Add("Pingvin2", (content_.Load<SoundEffect>("Son\\Bruitage\\pingvin2")).CreateInstance());
            bankEffect.Add("Fenrir2", (content_.Load<SoundEffect>("Son\\Bruitage\\fenrir2")).CreateInstance());
            bankEffect.Add("Krissa2", (content_.Load<SoundEffect>("Son\\Bruitage\\krissa2")).CreateInstance());

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
        static public void setVolumeMusique(float f_)
        {
            MediaPlayer.Volume = f_ *0.2f;
        }
        static public void setVolumeFX(float f_)
        {
            foreach (String item in bankEffect.Keys)
            {
                bankEffect[item].Volume = f_*0.2f;
            }
        }
    }
}
