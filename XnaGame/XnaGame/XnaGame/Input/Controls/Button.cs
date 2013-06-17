using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaGame.Input.Controls {
    class Button : Control {

        public override void Update(GameTime t) {
        }

        public override void Draw(SpriteBatch s) {
            base.Draw(s);

            if (SpriteFont != null) {
                if (HasFocus)
                    s.DrawString(SpriteFont, Text, Position, SelectedColor);
                else
                    s.DrawString(SpriteFont, Text, Position, Color);
            }
        }

        public override void HandleInput() {
            if (InputHandler.KeyReleased(KeyBind.Select)) {
                base.OnSelected(null);
            }
        }
    }
}
