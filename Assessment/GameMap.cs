using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    internal class GameMap
    {
        public int player_x = 1;
        public int player_y = 1;

        public int crate_x = 4;
        public int crate_y = 4;


        public int crate2_x = 6;
        public int crate2_y = 4;
        int counX = 0;


        public enum MoveDirections { Left, Right, Up, Down }
        private GameTile[,] map;

        //private GameTile wall;
        private GameTile diamond;

        public GameMap()
        {
            map = new GameTile[10, 10];
            //List<Vector2u> cratePositions = new List<Vector2u>();

            for (uint y = 0; y < 10; y++)
            {
                for (uint x = 0; x < 10; x++)
                {

                    map[x, y] = new FloorTile();
                    map[x, y].Position = new Vector2f(60f * x, 60f * y);

                    /*map[crate_x, crate_y] = new CrateTile();
                    map[crate_x, crate_y].Position = new Vector2f(60f * crate_x, 60f * crate_y);*/

                    /*map[crate2_x, crate_y] = new CrateTile();
                    map[crate2_x, crate_y].Position = new Vector2f(60f * crate2_x, 60f * crate2_y);*/

                    /*if (map[x,y] is CrateTile)
                    {
                         counX++;

                        cratePositions.Add(new Vector2u(x, y));
                    }*/


                    if (x == 0 || x == 9 || y == 0 || y == 9)
                    {
                        //if (IsWall(x, y))
                        //{
                        //    map[x, y] = wall;
                        //}
                        map[x, y] = new WallTile();
                        map[x, y].Position = new Vector2f(60f * x, 60f * y);
                    }

                }
            }
            //Console.WriteLine(counX);

            map[player_x, player_y] = new PlayerTitle();
            map[player_x, player_y].Position = new Vector2f(60 * player_x, 60 * player_y);

            map[crate_x, crate_y] = new CrateTile();
            map[crate_x, crate_y].Position = new Vector2f(60f * crate_x, 60f * crate_y);

            map[crate2_x, crate2_y] = new CrateTile();
            map[crate2_x, crate2_y].Position = new Vector2f(60f * crate2_x, 60f * crate2_y);


        }


        /*private bool IsWall(uint x, uint y)
        {
            return map[x, y] != wall;
        }*/

        public void DrawMap(RenderWindow window)
        {
            for (uint y = 0; y < 10; y++)
            {
                for (uint x = 0; x < 10; x++)
                {
                    window.Draw(map[x, y]);
                }
            }
            window.Draw(map[player_x, player_y]);//here
        }

        private bool isWall(int wall_x, int wall_y)
        {
            return (map[wall_x, wall_y] is WallTile);//|| (map[wall_x, wall_y] is CrateTile)
        }
        private bool isCrate(int x, int y)
        {
            return (map[x, y] is CrateTile);
        }



        /*public (int, int, int, int, int, int) moveCrate(int lastPX, int lastPY, int lastCX, int lastCY, int coordination_x, int coordination_y)
        {
            if (!isWall(player_x, player_y - 1) && !isWall(coordination_x, coordination_y - 1) && !isCrate(coordination_x, coordination_y - 1))
            {
                Console.WriteLine("1");
                player_y--;
                if (!isWall(coordination_x, coordination_y - 1) && player_x == coordination_x && player_y == coordination_y)
                {
                    Console.WriteLine("2");
                    if (isCrate(player_x, player_y))
                    {
                        Console.WriteLine("3");
                        coordination_y--;

                        Console.WriteLine("Box");


                        map[coordination_x, coordination_y] = new CrateTile();
                        map[coordination_x, coordination_y].Position = new Vector2f(60 * coordination_x, 60 * coordination_y);
                    }
                    map[lastPX, lastPY] = new FloorTile();
                    map[lastPX, lastPY].Position = new Vector2f(60 * lastPX, 60 * lastPY);

                    map[lastCX, lastCY] = new PlayerTitle();
                    map[lastCX, lastCY].Position = new Vector2f(60 * lastCX, 60 * lastCY);
                }
            }
            else
            {
                if (!isCrate(player_x, player_y - 1) && !isWall(player_x, player_y - 1))
                {
                    Console.WriteLine("last");
                    player_y--;
                    map[lastPX, lastPY] = new FloorTile();
                    map[lastPX, lastPY].Position = new Vector2f(60 * lastPX, 60 * lastPY);

                    map[player_x, player_y] = new PlayerTitle();
                    map[player_x, player_y].Position = new Vector2f(60 * player_x, 60 * player_y);
                }
            }
            return (lastPX, lastPY, lastCX, lastCY, coordination_x, coordination_y);
        }

        public (int, int, int, int, int, int) moveCrateD(int lastPX, int lastPY, int lastCX, int lastCY, int coordination_x, int coordination_y)
        {
            if (!isWall(player_x, player_y + 1) && !isWall(coordination_x, coordination_y + 1) && !isCrate(coordination_x, coordination_y + 1))
            {
                player_y++;
                if (!isWall(coordination_x, coordination_y + 1) && player_x == coordination_x && player_y == coordination_y)
                {
                    if (isCrate(player_x, player_y))
                    {
                        coordination_y++;

                        Console.WriteLine("Box");


                        map[coordination_x, coordination_y] = new CrateTile();
                        map[coordination_x, coordination_y].Position = new Vector2f(60 * coordination_x, 60 * coordination_y);
                    }
                    map[lastPX, lastPY] = new FloorTile();
                    map[lastPX, lastPY].Position = new Vector2f(60 * lastPX, 60 * lastPY);

                    map[lastCX, lastCY] = new PlayerTitle();
                    map[lastCX, lastCY].Position = new Vector2f(60 * lastCX, 60 * lastCY);
                }
            }
            else
            {
                if (!isCrate(player_x, player_y + 1) && !isWall(player_x, player_y + 1))
                {
                    player_y++;
                    map[lastPX, lastPY] = new FloorTile();
                    map[lastPX, lastPY].Position = new Vector2f(60 * lastPX, 60 * lastPY);

                    map[player_x, player_y] = new PlayerTitle();
                    map[player_x, player_y].Position = new Vector2f(60 * player_x, 60 * player_y);
                }
            }
            return (lastPX, lastPY, lastCX, lastCY, coordination_x, coordination_y);
        }*/

        public void movePlayer(MoveDirections direction)
         {
            // calcaute where the player is trying to move to
            // is that move allowed
            // then swap texture

            //if (map[aimx, aimy].tiletype == "floor")


            /*if (map[aimx, aimy] is WallTile)
                return;

                map[aimx, aimy] = new PlayerTile();
            map[aimx, aimy].Position = //new

            map[whereplayerwasx, where playerwasy] = new FloorTile();*/



            int lastPlayerPosX = player_x;
            int lastPlayerPosY = player_y;

            int lastCratePosX = crate_x;
            int lastCratePosY = crate_y;

            int lastCratePosX2 = crate2_x;
            int lastCratePosY2 = crate2_y;

            if (direction == MoveDirections.Up)
            {

                if (!isWall(player_x, player_y - 1) && !isWall(crate_x, crate_y - 1) && !isCrate(crate_x, crate_y - 1))
                {
                        player_y--;
                        if (!isWall(crate_x, crate_y - 1) && player_x == crate_x && player_y == crate_y)
                        {
                            if (isCrate(player_x, player_y))
                            {
                                crate_y--;

                            Console.WriteLine("Box");


                                map[crate_x, crate_y] = new CrateTile();
                                map[crate_x, crate_y].Position = new Vector2f(60 * crate_x, 60 * crate_y);
                            }
                            map[lastPlayerPosX, lastPlayerPosY] = new FloorTile();
                            map[lastPlayerPosX, lastPlayerPosY].Position = new Vector2f(60 * lastPlayerPosX, 60 * lastPlayerPosY);

                            map[lastCratePosX, lastCratePosY] = new PlayerTitle();
                            map[lastCratePosX, lastCratePosY].Position = new Vector2f(60 * lastCratePosX, 60 * lastCratePosY);
                        }
                    }
                else
                {
                    if (!isCrate(player_x, player_y - 1) && !isWall(player_x, player_y - 1))
                    {
                        player_y--;
                        map[lastPlayerPosX, lastPlayerPosY] = new FloorTile();
                        map[lastPlayerPosX, lastPlayerPosY].Position = new Vector2f(60 * lastPlayerPosX, 60 * lastPlayerPosY);

                        map[player_x, player_y] = new PlayerTitle();
                        map[player_x, player_y].Position = new Vector2f(60 * player_x, 60 * player_y);
                    }
                }
                //moveCrate(lastPlayerPosX, lastPlayerPosY, lastCratePosX, lastCratePosY, crate_x, crate_y);
            }
          else if (direction == MoveDirections.Down)
          {

                if (!isWall(player_x, player_y + 1) && !isWall(crate_x, crate_y + 1) && !isCrate(crate_x, crate_y + 1))
                {
                    player_y++;
                    if (!isWall(crate_x, crate_y + 1) && player_x == crate_x && player_y == crate_y)
                    {
                        if (isCrate(player_x, player_y))
                        {
                            crate_y++;

                            Console.WriteLine("Box");


                            map[crate_x, crate_y] = new CrateTile();
                            map[crate_x, crate_y].Position = new Vector2f(60 * crate_x, 60 * crate_y);
                        }
                        map[lastPlayerPosX, lastPlayerPosY] = new FloorTile();
                        map[lastPlayerPosX, lastPlayerPosY].Position = new Vector2f(60 * lastPlayerPosX, 60 * lastPlayerPosY);

                        map[lastCratePosX, lastCratePosY] = new PlayerTitle();
                        map[lastCratePosX, lastCratePosY].Position = new Vector2f(60 * lastCratePosX, 60 * lastCratePosY);
                    }
                }
                else
                {
                    if (!isCrate(player_x, player_y + 1) && !isWall(player_x, player_y + 1))
                    {
                        player_y++;
                        map[lastPlayerPosX, lastPlayerPosY] = new FloorTile();
                        map[lastPlayerPosX, lastPlayerPosY].Position = new Vector2f(60 * lastPlayerPosX, 60 * lastPlayerPosY);

                        map[player_x, player_y] = new PlayerTitle();
                        map[player_x, player_y].Position = new Vector2f(60 * player_x, 60 * player_y);
                    }
                }
                //moveCrateD(lastPlayerPosX, lastPlayerPosY, lastCratePosX, lastCratePosY, crate_x, crate_y);
            }
          else if (direction == MoveDirections.Left)
          {

                if (!isWall(player_x - 1, player_y) && !isWall(crate_x - 1, crate_y) && !isCrate(crate_x - 1, crate_y))
                {
                    player_x--;
                    if (!isWall(crate_x + 1, crate_y) && player_x == crate_x && player_y == crate_y)
                    {
                        if (isCrate(player_x, player_y))
                        {
                            crate_x--;

                            Console.WriteLine("Box");


                            map[crate_x, crate_y] = new CrateTile();
                            map[crate_x, crate_y].Position = new Vector2f(60 * crate_x, 60 * crate_y);
                        }
                        map[lastPlayerPosX, lastPlayerPosY] = new FloorTile();
                        map[lastPlayerPosX, lastPlayerPosY].Position = new Vector2f(60 * lastPlayerPosX, 60 * lastPlayerPosY);

                        map[lastCratePosX, lastCratePosY] = new PlayerTitle();
                        map[lastCratePosX, lastCratePosY].Position = new Vector2f(60 * lastCratePosX, 60 * lastCratePosY);
                    }
                }
                else
                {
                    if (!isCrate(player_x - 1, player_y) && !isWall(player_x - 1, player_y))
                    {
                        player_x--;
                        map[lastPlayerPosX, lastPlayerPosY] = new FloorTile();
                        map[lastPlayerPosX, lastPlayerPosY].Position = new Vector2f(60 * lastPlayerPosX, 60 * lastPlayerPosY);

                        map[player_x, player_y] = new PlayerTitle();
                        map[player_x, player_y].Position = new Vector2f(60 * player_x, 60 * player_y);
                    }
                }
            }
            else if (direction == MoveDirections.Right)
            {
                if (!isWall(player_x + 1, player_y) && !isWall(crate_x + 1, crate_y) && !isCrate(crate_x + 1, crate_y))
                {
                    player_x++;
                    if (!isWall(crate_x - 1, crate_y) && player_x == crate_x && player_y == crate_y)
                    {
                        if (isCrate(player_x, player_y))
                        {
                            crate_x++;

                            Console.WriteLine("Box");


                            map[crate_x, crate_y] = new CrateTile();
                            map[crate_x, crate_y].Position = new Vector2f(60 * crate_x, 60 * crate_y);
                        }
                        map[lastPlayerPosX, lastPlayerPosY] = new FloorTile();
                        map[lastPlayerPosX, lastPlayerPosY].Position = new Vector2f(60 * lastPlayerPosX, 60 * lastPlayerPosY);

                        map[lastCratePosX, lastCratePosY] = new PlayerTitle();
                        map[lastCratePosX, lastCratePosY].Position = new Vector2f(60 * lastCratePosX, 60 * lastCratePosY);
                    }
                }
                else
                {
                    if (!isCrate(player_x + 1, player_y) && !isWall(player_x + 1, player_y))
                    {
                        player_x++;
                        map[lastPlayerPosX, lastPlayerPosY] = new FloorTile();
                        map[lastPlayerPosX, lastPlayerPosY].Position = new Vector2f(60 * lastPlayerPosX, 60 * lastPlayerPosY);

                        map[player_x, player_y] = new PlayerTitle();
                        map[player_x, player_y].Position = new Vector2f(60 * player_x, 60 * player_y);
                    }
                }
            }


            // If this is true, player cannot move to this tile
            if (isWall(player_x, player_y))
          {
              player_x = lastPlayerPosX;
              player_y = lastPlayerPosY;
                return;
          }
          else
          {
                map[lastPlayerPosX, lastPlayerPosY] = new FloorTile();
                map[lastPlayerPosX, lastPlayerPosY].Position = new Vector2f(60 * lastPlayerPosX, 60 * lastPlayerPosY);

                map[player_x, player_y] = new PlayerTitle();
                map[player_x, player_y].Position = new Vector2f(60 * player_x, 60 * player_y);

            }



          //moveCrate();


      }
        
    }
}



