using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_RPG
{
    public class Hero : Sprite
    {
        //getting vector texture position spritebatch from sprite class
        public Vector2 Movement { get; set; }
        public Hero(Texture2D texture, Vector2 position, SpriteBatch spritebatch)
            : base(texture, position, spritebatch)
        {
        }
        public void Update(GameTime gameTime)
        {
            KeyboardUpdate();
            //friction
            Movement -= Movement * new Vector2(.2f, .2f);
            AdvancedMovement(gameTime);
        }
        
        private void AdvancedMovement(GameTime gameTime)
        {
            Vector2 oldPosition = Position;
            //update postion
            Position += Movement * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 30;
            if (!Board.CurrentBoard.HasRoomForRectangle(Bounds)) { Position = oldPosition; }
        }
        

        private void KeyboardUpdate()
        {
            //inputs from the keyboard to movement
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left)) { Movement += new Vector2(-2, 0); }
            if (keyboardState.IsKeyDown(Keys.Right)) { Movement += new Vector2(2, 0); }
            if (keyboardState.IsKeyDown(Keys.Up)) { Movement += new Vector2(0, -2); }
            if (keyboardState.IsKeyDown(Keys.Down)) { Movement += new Vector2(0, 2);  }
        }


    }
}
