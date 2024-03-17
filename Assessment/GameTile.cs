using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    internal class GameTile : RectangleShape
    {
        public GameTile()
        {
            this.Size = new SFML.System.Vector2f(60f, 60f);
        }
    }
}
