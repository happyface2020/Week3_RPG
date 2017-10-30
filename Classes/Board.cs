using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_RPG
{
    public class Board
    {
        public Tile[,] Tiles { get; set; }
        public int Columns = 10;
        public int Rows = 5;
        public Texture2D TileTexture { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public static Board CurrentBoard { get; private set; }
        public Rectangle Box = new Rectangle(0, 0, 100, 100);


        public bool HasRoomForRectangle(Rectangle rectangleToCheck)
        {

            //sets false or true value for hasroomrectangle, if intersects false
            foreach (var tile in Tiles)
            {
                if (tile.IsBlocked && tile.Bounds.Intersects(rectangleToCheck))
                {
                    return false;
                }
            }
            return true;
        }


        public Board(SpriteBatch spritebatch, Texture2D tileTexture)
        {
            TileTexture = tileTexture;
            SpriteBatch = spritebatch;
            Tiles = new Tile[Columns, Rows];
            Board.CurrentBoard = this;

            //makes an array with the width/height of box
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    Vector2 tilePosition =
                        new Vector2(x * Box.Width, y * Box.Height);
                    
                        Tiles[x, y] =
                        new Tile(tileTexture, tilePosition, spritebatch, false);    
                }
            }
            //adding houses
            Tiles[2, 3] =
                        new Tile(tileTexture, new Vector2(2 * Box.Width, 3 * Box.Height), spritebatch, true);
            Tiles[5, 2] =
                        new Tile(tileTexture, new Vector2(5 * Box.Width, 2 * Box.Height), spritebatch, true);

        }

        //command to draw all true values
        public void Draw()
        {
            foreach (var tile in Tiles)
            {
                tile.Draw();
            }
        }
    }
}
