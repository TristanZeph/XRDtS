using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaGame.Input.Controls {
    public abstract class Control {
        public string Text;
        public bool HasFocus;
        public bool Enabled;
        public bool Visible;
        public Vector2 Position;
        public Vector2 Size;
        public Color Color;
        public Color SelectedColor;
        public SpriteFont SpriteFont;
        public Texture2D Background;

        public EventHandler Selected;

        public Control() {
            HasFocus = false;
            Visible = true;
            Enabled = true;
            Position = Vector2.Zero;
            Color = Color.White;
            SelectedColor = Color.Red;
            SpriteFont = ControlManager.SpriteFont;
        }

        public abstract void Update(GameTime t);
        public abstract void HandleInput();

        /// <summary>
        /// Draws the background 
        /// </summary>
        public virtual void Draw(SpriteBatch s) {
            if (Background != null) {
                s.Draw(
                    Background,
                    new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y),
                    Color.White);
            }
        }
        
        protected virtual void OnSelected(EventArgs e) {
            if (Selected != null) {
                Selected(this, e);
            }
        }
    }
}
