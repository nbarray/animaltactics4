using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class Onglet
    {
        public Rectangle rect;
        public List<Label> labels;

        public Onglet(Rectangle rect_)
        {
            rect = rect_;
            labels = new List<Label>();
        }

        public void Add(string text)
        {
            labels.Add(new Label(new Rectangle(rect.X+5, rect.Y+5 + 50*labels.Count, rect.Width - 10, 50), text));
        }

        public void Update(TextBox box)
        {
            foreach (Label item in labels)
            {
                if (Contents.contientLaSouris(item.rect) && Mouse.GetState().LeftButton == ButtonState.Pressed) // histoire
                {
                    if (item.text == Dico.langues[Dico.current][52])
                    {
                        box.Add(Dico.langues[Dico.current][58]);
                    }
                    else if (item.text == Dico.langues[Dico.current][53])
                    {
                        box.Add(Dico.langues[Dico.current][59]);
                    }
                    else if (item.text == Dico.langues[Dico.current][54])
                    {
                        box.Add(Dico.langues[Dico.current][60]);
                    }
                    else if (item.text == Dico.langues[Dico.current][55])
                    {
                        box.Add(Dico.langues[Dico.current][61]);
                    }
                    else if (item.text == Dico.langues[Dico.current][56])
                    {
                        box.Add(Dico.langues[Dico.current][62]);
                    }
                    else if (item.text == Dico.langues[Dico.current][57])
                    {
                        box.Add(Dico.langues[Dico.current][63]);
                    }
                }
            }
        }

        public void Draw()
        {
            Contents.Draw("textbox", rect);
            foreach (Label item in labels)
            {
                item.Draw();
            }
        }
    }

    class Label
    {
        public Rectangle rect;
        public string text;

        public Label(Rectangle rect_, string text_)
        {
            rect = rect_;
            text = text_;
        }

        public void Draw()
        {
            if (!Contents.contientLaSouris(rect))
            {
                Contents.Draw("bouton_normal", rect);
            }
            else
            {
                Contents.Draw("bouton_selected", rect);
            }
            Contents.DrawStringInBoxCentered(text, rect);
        }
    }
}
