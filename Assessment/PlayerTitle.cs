using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    internal class PlayerTitle :GameTile
    {
        public PlayerTitle()
        {
            this.Texture = new Texture("resources/player.png");
        }
    }
}
