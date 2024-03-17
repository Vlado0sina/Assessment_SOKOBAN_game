using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    internal class CrateTile : GameTile
    {
        public CrateTile()
        {
            this.Texture = new Texture("resources/crate_42.png");
        }
    }
}
