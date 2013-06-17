using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaGame.Objects {
    abstract class Entity {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Size;
        public Color Color;

        public abstract void Update(GameTime t);
        public abstract void Draw(SpriteBatch s);
    }
}
