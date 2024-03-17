using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    internal class FloorTile : GameTile
    {
        public FloorTile()
        { 
            this.Texture = new Texture("resources/ground.png");
        }
    }
}
