using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    internal class GameController
    {
        private RenderWindow renderWindow;
        private GameMap gameMap;
        private SideView sideView;

        public GameController()
        {
            renderWindow = new RenderWindow(new VideoMode(600, 600), "Assessment Program", Styles.Close);//900 600
            renderWindow.Closed += new EventHandler(OnClosePressed);
            renderWindow.Closed += OnClosePressed;
            //renderWindow.KeyReleased += new EventHandler<KeyEventArgs>(OnKeyInteraction);
            renderWindow.KeyReleased += OnKeyInteraction;
            gameMap = new GameMap();
            /*sideView = new SideView();
            sideView.Size = new Vector2f(200, 600);
            sideView.Position = new Vector2f(600f, 0f);
            sideView.FillColor = Color.Blue;*/

        }

        public void Run()
        {
            while(renderWindow.IsOpen)
            {
                renderWindow.DispatchEvents();

                Update();
                Render();
                
            }
        }

        private void Update()
        {
            
            
        }
        private void Render()
        {
            renderWindow.Clear(new Color(128, 128, 128));//255 128 0
            gameMap.DrawMap(renderWindow);
            //sideView.Draw(renderWindow);
            renderWindow.Display();
        }

        private void OnClosePressed(object? sender, EventArgs e)
        {
            renderWindow.Close();
            
        }

        private void OnKeyInteraction(object? sender, KeyEventArgs e)
        {

            switch (e.Code)
            {
                case Keyboard.Key.Up:
                    Console.WriteLine("up");
                    gameMap.movePlayer(GameMap.MoveDirections.Up);
                    break;
                case Keyboard.Key.Down:
                    Console.WriteLine("down");
                    gameMap.movePlayer(GameMap.MoveDirections.Down);
                    break;
                case Keyboard.Key.Left:
                    Console.WriteLine("left");
                    gameMap.movePlayer(GameMap.MoveDirections.Left);
                    break;
                case Keyboard.Key.Right:
                    Console.WriteLine("right");
                    gameMap.movePlayer(GameMap.MoveDirections.Right);
                    break;
            }
        }

        




    }
}
