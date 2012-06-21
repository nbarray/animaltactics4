using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace animaltactics4
{
    //Coldman & Loohy
    static class Engine
    {
        static public ListeDesFichiers files;
        static public Stack<Scene> scenes;

        //Coldman & Loohy
        static public void Initialize()
        {
            files = new ListeDesFichiers();
            scenes = new Stack<Scene>();
            scenes.Push(new Introduction());
            recharge();
        }
        //Coldman
        static public void Update(GameTime gameTime)
        {
            if (scenes.Count > 0)
            {
                scenes.Peek().UpdateScene(gameTime);
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                Bouton.een = false;
               
            }
        }
        //Coldman
        static public void Draw()
        {
            if (scenes.Count > 0)
            {
                scenes.Peek().DrawScene();
            }
            Contents.Cadre();

            Contents.DrawString("1.S : " + Serveur.Etape1_connection_du_client.ToString() + " : Connection du client", new Rectangle(0, 0, 100, 50));
            Contents.DrawString("1.C : " + Client.Etape1_connection_du_client.ToString() + " : Connection du client", new Rectangle(0, 50, 100, 50));
            Contents.DrawString("2.S : " + Serveur.Etape2_synchronisation_des_joueurs.ToString() + " : Syncho des joueurs", new Rectangle(0, 100, 100, 50));
            Contents.DrawString("2.C : " + Client.Etape2_synchronisation_des_joueurs.ToString() + " : Syncho des joueurs", new Rectangle(0, 150, 100, 50));
            Contents.DrawString("3.S : " + Serveur.Etape3_partie_en_cours.ToString() + " : Partie en cours", new Rectangle(0, 200, 100, 50));
            Contents.DrawString("3.C : " + Client.Etape3_partie_en_cours.ToString() + " : Partie en cours", new Rectangle(0, 250, 100, 50));
            Contents.DrawString("S : " + Serveur.Etape3_SEtape1_partie_en_cours.ToString(), new Rectangle(0, 300, 100, 50));
            Contents.DrawString("S : " + Serveur.Etape3_SEtape2_partie_en_cours.ToString(), new Rectangle(0, 400, 100, 50));
            Contents.DrawString("S : " + Serveur.Etape4_fin_de_partie.ToString(), new Rectangle(0, 500, 100, 50));

        }
        //Loohy
        static public void recharge()
        {
            try
            {
                files = (ListeDesFichiers)Divers.deserializer("allTheLists4242Penguin");
            }
            catch (Exception)
            {
                files = new ListeDesFichiers();
                files.ArmeesDeBase();
                files.CartesDeBase();
                Divers.serializer(files, "allTheLists4242Penguin");
            }
        }
        static public void save()
        {
            files.volumeMusique = MediaPlayer.Volume;
            files.volumeFX = MoteurSon.bankEffect["bouton"].Volume;
            Divers.serializer(files, "allTheLists4242Penguin");
        }
    }
}
