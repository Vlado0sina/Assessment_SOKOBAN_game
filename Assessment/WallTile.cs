using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    internal class WallTile : GameTile
    {
        public WallTile()
        {
            this.Texture = new Texture("resources/wall.png");
        }
    }
}
