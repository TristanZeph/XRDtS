using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaGame.Input.Controls {
    public class ControlManager : List<Control> {
        int selectedControl = 0;

        static SpriteFont spriteFont;
        public static SpriteFont SpriteFont {
            get { return spriteFont; }
        }

        public ControlManager(SpriteFont s) {
            spriteFont = s;
        }

        public void Update(GameTime t) {
            if (Count == 0) return;

            foreach (Control c in this) {
                if (c.Enabled)
                    c.Update(t);
                if (c.HasFocus)
                    c.HandleInput();
            }
        }

        public void Draw(SpriteBatch s) {
            foreach (Control c in this) {
                if (c.Visible)
                    c.Draw(s);
            }
        }

        public void HandleInput() {
            if (InputHandler.KeyPressed(KeyBind.Down))
                NextControl();
            if (InputHandler.KeyPressed(KeyBind.Up))
                PreviousControl();
        }

        private void NextControl() {
            if (Count == 0) return;

            this[selectedControl].HasFocus = false;
            
            selectedControl++;
            if (selectedControl >= Count)
                selectedControl = 0;

            this[selectedControl].HasFocus = true;
        }

        private void PreviousControl() {
            if (Count == 0) return;

            this[selectedControl].HasFocus = false;

            selectedControl--;
            if (selectedControl < 0)
                selectedControl = Count - 1;

            this[selectedControl].HasFocus = true;
        }
    }
}
