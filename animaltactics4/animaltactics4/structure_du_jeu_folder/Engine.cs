using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
    }
}
