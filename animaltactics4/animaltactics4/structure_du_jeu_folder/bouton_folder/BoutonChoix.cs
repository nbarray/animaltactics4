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
        public int nbr_de_variation, current;
        string assetName;

        public BoutonChoix(Rectangle rect_, Rectangle sub_, int nbr_de_variation_, string assetName_)
            : base(rect_, sub_)
        {
            nbr_de_variation = nbr_de_variation_;
            current = 0;
            assetName = assetName_; 
            if (current < nbr_de_variation - 1)
            {
                current++;
            }
            else
            {
                current = 0;
            }
            if (assetName == "fog")
            {
                switch (current)
                {
                    case 0:
                        sub.X = sub.Width * 2;
                        break;
                    case 1:
                        sub.X = sub.Width;
                        break;
                    default:
                        sub.X = 0;
                        break;
                }
            }
            else
            {
                switch (current)
                {
                    case 0:
                        sub.X = sub.Width * 2;
                        break;
                    case 1:
                        sub.X = sub.Width * 3;
                        break;
                    case 2:
                        sub.X = sub.Width;
                        break;
                    default:
                        sub.X = 0;
                        break;
                }
            }
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
                    if (assetName == "fog")
                    {
                        switch (current)
                        {
                            case 0:
                                sub.X = sub.Width * 2;
                                break;
                            case 1:
                                sub.X = sub.Width;
                                break;
                            default:
                                sub.X = 0;
                                break;
                        }
                    }
                    else
                    {
                        switch (current)
                        {
                            case 0:
                                sub.X = sub.Width * 2;
                                break;
                            case 1:
                                sub.X = sub.Width * 3;
                                break;
                            case 2:
                                sub.X = sub.Width;
                                break;
                            default:
                                sub.X = 0;
                                break;
                        }
                    }
                }
                een = true;
            }
        }
        public override void Draw()
        {
            Contents.Draw(assetName, rect, sub);
        }
    }
}
