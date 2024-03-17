using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    internal class SideView :RectangleShape
    {
        private Font textFont;
        private Text titleText;
        

        /*public SideView()
        {
            textFont = new Font("resources/basic_font.ttf");
            titleText = new Text("Game title", textFont);

        }

        public void Draw(RenderWindow window)
        {
            window.Draw(this); 
            titleText.Position = this.Position + new Vector2f(50f, 100f);
            window.Draw(titleText);
        }*/
    }
}
