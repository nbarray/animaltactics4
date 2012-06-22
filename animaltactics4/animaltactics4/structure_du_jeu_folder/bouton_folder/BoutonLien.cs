using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    //Coldman
    class BoutonLien : Bouton
    {
        bool sound;
        public Scene linkTo;
        Rectangle tuveuxvoir;
        int indexDico;
        bool inGame;
        public BoutonLien(int x, int y, Rectangle sub_, Scene linkTo_, int indexDico_, bool _inGame = false)
            : base(new Rectangle(x, y, 400, 75), sub_)
        {
            linkTo = linkTo_;
            tuveuxvoir = new Rectangle(0, base.rect.Y - 12, Divers.X, 100);
            indexDico = indexDico_;
            inGame = _inGame;
            sound = true;
        }
        public BoutonLien(int x, int y, int width, int height, Rectangle sub_, Scene linkTo_, int indexDico_)
            : base(new Rectangle(Divers.X / 2 - 200, y, width, height), sub_)
        {
            linkTo = linkTo_;
            tuveuxvoir = new Rectangle(0, base.rect.Y - 12, Divers.X, 100);
            indexDico = indexDico_;
        }

        public override void Update(GameTime gameTime)
        {
            if (Contents.contientLaSouris(base.rect))
            {
                if (!een && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    MoteurSon.PlayFX("bouton");
                    // Action !
                    if (linkTo != null)
                    {
                        Engine.scenes.Push(linkTo);
                    }
                    else
                    {
                        Engine.scenes.Pop();
                    }
                    een = true;
                }
            }

            if (Engine.scenes.Count == 0)
            {
                Game1.quitter = true;
            }
        }
        public void Update(GameTime gameTime, Func<bool> deleg = null)
        {
            if (Contents.contientLaSouris(base.rect))
            {
                if (!een && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    MoteurSon.PlayFX("bouton");
                    // Action !
                    if (linkTo != null)
                    {
                        if (deleg != null)
                        {
                            deleg.Invoke();
                        }
                        Engine.scenes.Push(linkTo);
                    }
                    else
                    {
                        Engine.scenes.Pop();
                    }
                    een = true;
                }
            }

            if (Engine.scenes.Count == 0)
            {
                Game1.quitter = true;
            }
        }
        public override void Draw()
        {
            if (!Contents.contientLaSouris(base.rect))
            {
                Contents.Draw("bouton_normal", rect);
                sound = true;
            }
            else
            {
                if (sound)
                    MoteurSon.PlayFX("clic");
                sound = false;
                //Fait la moins dure, loohy, c'est pour ton bien
                if (!inGame)
                    Contents.Draw("grosse", tuveuxvoir, Color.DeepSkyBlue);
                Contents.Draw("bouton_selected", rect);
            }
            Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][indexDico], rect);
        }
    }
}
