using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class Introduction : Scene
    {
        bool een;
        Rectangle vidRectangle;
        int duree;

        public Introduction()
            : base()
        {
            een = false;
            vidRectangle = new Rectangle(0, 0, Divers.X, Divers.Y);
            duree = 0;

            //Contents.Miyazaki.Play(Contents.videos["intro"]);
        }

        public override void UpdateScene(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                duree = 42 * 42;
            }
        }

        public override void DrawScene()
        {
            Contents.Draw("px", new Rectangle(0, 0, 1200, 900), Color.Black);
            int tmax = 30;
            if (duree == 0)
            {
                Dico.current = Engine.files.currentLanguage;
                MoteurSon.setVolumeMusique(Engine.files.volumeMusique);
                MoteurSon.setVolumeFX(Engine.files.volumeFX);
            }
            if (duree < tmax)
            {
                Contents.Draw("bleuApp", new Rectangle(485, 310 - (tmax - duree) / 2, 230, 280 + (tmax - duree)),
                    new Rectangle((((duree * 4 / tmax)/* % 7 + 1*/) % 4) * 230, 0, 230, 280));
                Contents.Draw("vertApp", new Rectangle(485, 310 - (tmax - duree) / 2, 230, 280 + (tmax - duree)),
                    new Rectangle((((duree * 4 / tmax)/* % 8 + 2*/) % 4) * 230, 0, 230, 280));
                Contents.Draw("rougeApp", new Rectangle(485, 310 - (tmax - duree) / 2, 230, 280 + (tmax - duree)),
                    new Rectangle((((duree*4 / tmax)/* % 7 + 5*/) % 4) * 230, 0, 230, 280));
                Contents.Draw("jauneApp", new Rectangle(485, 310 - (tmax - duree) / 2, 230, 280 + (tmax - duree)),
                    new Rectangle((((duree * 4 / tmax)/* % 6 + 3*/) % 4) * 230, 0, 230, 280));
                Contents.Draw("blancApp", new Rectangle(485, 310 - (tmax - duree) / 2, 230, 280 + (tmax - duree)),
                    new Rectangle((((duree * 4 / tmax)/* % 6 + 1*/) % 4) * 230, 0, 230, 280));
                duree++;
            }
            else
            {
                if (duree < 100 +tmax)
                {
                    Contents.Draw("LOGO", new Rectangle(485, 310, 230, 280));
                    Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][51], new Rectangle(485, 620, 230, 100));
                    duree++;
                }
                else
                {
                    //Contents.DrawVideo("intro", vidRectangle);

                    //if (Contents.Miyazaki.PlayPosition == Contents.videos["intro"].Duration || Keyboard.GetState().IsKeyDown(Keys.Space))
                    //{
                    //    Contents.Miyazaki.Stop();
                        Engine.scenes.Pop();
                        Engine.scenes.Push(new MenuPrincipal());
                    //}
                }
            }
        }
    }
}
