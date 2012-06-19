using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class BoutonCirculaire : Bouton
    {
        e_modeAction type;
        Color color;

        public BoutonCirculaire(e_modeAction type_)
            : base(new Rectangle(0, 0, 24, 24), new Rectangle(0, 0, 500, 500))
        {
            type = type_;
            switch (type_)
            {
                case e_modeAction.Attaque:
                    color = Color.Red;
                    break;
                case e_modeAction.Mouvement:
                    color = Color.Blue;
                    break;
                case e_modeAction.Pouvoir:
                    color = Color.Purple;
                    break;
                default:
                    break;
            }
        }

        public void DrawPos(int x_, int y_)
        {

            base.rect.X = x_;
            base.rect.Y = y_;
            Contents.Draw("px3", base.rect, color);
        }
        public void UpdateRef(ref e_modeAction mood_)
        {
            if (Contents.contientLaSouris(base.rect) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                mood_ = type;
            }
        }
        public override void Update(GameTime gameTime) { }
        public override void Draw() { }
    }
}
