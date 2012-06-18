using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuEncyclopedie : Scene
    {
        TextBox textbox;

        public MenuEncyclopedie()
            : base()
        {
            textbox = new TextBox(new Rectangle(100, 100, Divers.X - 200, Divers.Y - 300));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));

            textbox.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ligula massa, ultrices at pharetra at, interdum ac nulla. Duis lacinia ultricies sem et semper. Aenean porttitor enim sit amet sem molestie ornare. Phasellus facilisis quam sed odio consequat ut sollicitudin purus vestibulum. Donec ut neque eu mauris hendrerit posuere. Sed nibh sem, elementum venenatis interdum ac, vestibulum vitae risus. Curabitur egestas, nunc at ultrices sodales, magna ante sagittis purus, quis dictum velit lectus aliquam elit. Morbi vel augue venenatis orci pharetra fringilla et vitae nisi. Nam suscipit nisl sed mauris gravida euismod. Pellentesque aliquam tincidunt ligula vitae vehicula. Fusce velit sapien, fringilla tristique sollicitudin in, tristique sit amet arcu. Fusce id felis orci. Nulla id tellus et dolor pulvinar pulvinar. Donec eleifend, ligula et posuere malesuada, erat orci ultricies tortor, commodo consectetur purus odio vitae enim. Praesent eget mi nibh, eget commodo diam. Suspendisse potenti. Mauris dui elit, mollis ac gravida eget, accumsan non ante. Quisque rutrum sollicitudin mauris, eget fringilla leo porttitor sit amet. Fusce aliquet, urna vel scelerisque ornare, ligula risus varius libero, sed congue metus arcu in sapien. Donec nec laoreet purus. Curabitur quam velit, accumsan non aliquam sed, mollis non neque. Etiam tempus, ipsum ut accumsan egestas, odio lacus faucibus ante, id consectetur mi tortor nec odio. Mauris felis urna, viverra nec tincidunt at, vehicula at mauris. Nullam sed tortor pharetra sapien elementum feugiat. Donec nisl elit, venenatis id facilisis quis, luctus nec ligula. Integer fermentum nisi et metus scelerisque at placerat ligula ornare. Duis congue est sit amet nisl elementum pretium. Donec cursus, dui vitae adipiscing iaculis, est magna porta magna, a posuere nulla sem at justo. Pellentesque tristique, nisi vitae aliquet auctor, elit dui molestie odio, at hendrerit turpis mi eu turpis. Fusce eget turpis et nulla aliquet vehicula. Phasellus rutrum augue ullamcorper odio dignissim at molestie tellus fermentum. Mauris feugiat condimentum urna ac pretium. Nunc faucibus, sem ut elementum rhoncus, sapien nibh dapibus turpis, eget viverra massa ipsum at tellus. Nulla id semper lorem. Fusce ut diam a mi aliquet lacinia et ut leo. Pellentesque volutpat consequat eros id viverra. Fusce dapibus leo ut justo rhoncus malesuada at in risus. Etiam quis ipsum nibh, at tristique nunc. Aliquam purus lorem, fringilla in congue vel, lobortis et quam. Nulla facilisi. In id tempus tortor. Nam suscipit pulvinar dignissim. Nulla pellentesque suscipit quam, a rhoncus felis tincidunt et. Vestibulum in tellus tempor nisl semper varius. Aenean convallis nisi eu nisi imperdiet nec ornare mauris egestas. Sed mollis felis odio, vitae ultricies metus. Proin ut erat quam, sed pellentesque ante. Nunc elementum nisl vel metus tincidunt pulvinar. Sed volutpat imperdiet metus sed viverra. Proin at ante tellus. Vestibulum bibendum risus sed ante fermentum quis laoreet neque sagittis. Vivamus vehicula auctor porta. Nam auctor est a lectus pretium at pellentesque magna auctor. Nam velit ligula, ullamcorper eu adipiscing et, sodales sed urna. Nulla faucibus rhoncus nulla. Aenean volutpat lacinia faucibus. Aliquam sed felis ipsum, at vehicula justo. Cras faucibus suscipit tincidunt. Proin tincidunt ipsum quis tellus tempor dapibus. Curabitur mollis nulla sed nunc bibendum viverra. Sed ac consequat nulla. Nunc eu mauris pulvinar mi tempor imperdiet convallis in lorem. Nullam molestie dignissim felis quis faucibus. Nullam convallis, eros id malesuada fermentum, enim mi volutpat leo, at tristique odio metus et urna. Nam dictum, nulla dictum fermentum sollicitudin, massa lectus aliquam dolor, nec pretium arcu nisi non eros. Nunc dapibus dignissim sodales. Cras condimentum leo mauris. In luctus imperdiet vehicula. Nulla cursus dictum odio. Phasellus scelerisque pharetra lorem, a condimentum ligula tincidunt a. Donec accumsan est non dui ornare ut pharetra velit porttitor.");
       
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
        }

        public override void DrawScene()
        {
            base.DrawScene();
            textbox.Draw();
        }
    }
}
