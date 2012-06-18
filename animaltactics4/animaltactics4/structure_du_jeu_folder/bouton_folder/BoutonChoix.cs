using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class BoutonChoix : Bouton
    {
        int nbr_de_variation, current;
        string assetName;

        public BoutonChoix(Rectangle rect_, Rectangle sub_, int nbr_de_variation_, string assetName_)
            : base(rect_, sub_)
        {
            nbr_de_variation = nbr_de_variation_;
            current = 0;
            assetName = assetName_;
        }

        public override void Update(GameTime gameTime)
        {
            if (Contents.contientLaSouris(base.rect))
            {
                if (!een && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    if (current < nbr_de_variation - 1)
                    {
                        current++;
                    }
                    else
                    {
                        current = 0;
                    }

                    sub.X = sub.Width * current;
                }
                een = true;
            }
        }
        public override void UpdateD(ref e_toolSize tsize_, ref e_pinceau tstate_) { }
        public override void Draw()
        {
            Contents.Draw(assetName, rect, sub);
        }
    }
}
