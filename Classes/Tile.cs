using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_RPG
{
    public class Tile : Sprite
    {

        public bool IsBlocked { get; set; }

        //adding bool variable to textures
        public Tile(Texture2D texture, Vector2 position, SpriteBatch batch, bool isBlocked)
            : base(texture, position, batch)
        {
            IsBlocked = isBlocked;
        }

        // drawing only if true
        public override void Draw()
        {
            if (IsBlocked) { base.Draw(); }
        }
    }
}
