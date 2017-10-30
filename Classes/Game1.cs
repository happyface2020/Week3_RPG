using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Week3_RPG
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D _background, _tileTexture, _heroTexture;
        private Hero _hero;
        private Board _board;
        Rectangle mainFrame;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // used to load a high def content photo for the background
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
        }
        
      
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //background texture and mainframe measuring current game widow length and applying it to mainFrame
            _background = Content.Load<Texture2D>("Grasslands");
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            //loading hero texture and positioning at 100, 160 pixels
            _heroTexture = Content.Load<Texture2D>("Hero");
            _hero = new Hero(_heroTexture, new Vector2(100, 160), spriteBatch);
            // loading house texture 
            _tileTexture = Content.Load<Texture2D>("House");
            _board = new Board(spriteBatch, _tileTexture);

        }

       
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // updating for hero movement
            _hero.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            base.Draw(gameTime);
            //loading in background
            spriteBatch.Draw(_background, mainFrame, Color.WhiteSmoke);
            //loading textures: hero, house
            _hero.Draw();
            _board.Draw();
            spriteBatch.End();
        }
    }
}
