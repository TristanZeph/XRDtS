using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaGame.Input.Controls {
    class Panel : Control {
        private List<Control> childControls;
        private int selectedControl = 0;

        public Panel() {
            childControls = new List<Control>();
        }

        public Panel(Vector2 pos, Vector2 size) {
            Position = pos;
            Size = size;
            childControls = new List<Control>();
        }

        public void AddControl(Control c) {
            childControls.Add(c);
        }

        public override void Update(GameTime t) {
            if (childControls.Count == 0) return;

            foreach (Control c in childControls) {
                if (c.Enabled)
                    c.Update(t);
                if (c.HasFocus)
                    c.HandleInput();
            }
        }

        public override void Draw(SpriteBatch s) {
            base.Draw(s);

            foreach (Control c in childControls)
                c.Draw(s);
        }

        public override void HandleInput() {
            if (InputHandler.KeyPressed(KeyBind.Down))
                NextControl();
            if (InputHandler.KeyPressed(KeyBind.Up))
                PreviousControl();
        }

        private void NextControl() {
            if (childControls.Count == 0) return;

            childControls[selectedControl].HasFocus = false;

            selectedControl++;
            if (selectedControl >= childControls.Count)
                selectedControl = 0;

            childControls[selectedControl].HasFocus = true;
        }

        private void PreviousControl() {
            if (childControls.Count == 0) return;

            childControls[selectedControl].HasFocus = false;

            selectedControl--;
            if (selectedControl < 0)
                selectedControl = childControls.Count - 1;

            childControls[selectedControl].HasFocus = true;
        }
    }
}
