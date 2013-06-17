using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XnaGame.StateManager;
using XnaGame.Input.Controls;

namespace XnaGame.GameScreens {
    public class BattleScreen : GameState {
        private const int cmdPosX = 30;
        private const int cmdPosY = 500;
        private const int spacing = 25;

        /// <summary>
        /// pass game and stateManager reference
        /// </summary>
        public BattleScreen(Game1 game, GameStateManager man)
            : base(game, man) {
        }

        /// <summary>
        /// Loads the screens contents
        /// </summary>
        public override void LoadContent() {
            base.LoadContent();

            ContentManager Content = GameRef.Content;

            Button btnAttack = new Button();
            btnAttack.Text = "Attack";
            btnAttack.Position = new Vector2(cmdPosX, cmdPosY);
            btnAttack.HasFocus = true;

            ControlManager.Add(btnAttack);

            Button btnDefend = new Button();
            btnDefend.Text = "Defend";
            btnDefend.Position = new Vector2(cmdPosX, cmdPosY + spacing);

            ControlManager.Add(btnDefend);

            Button btnRun = new Button();
            btnRun.Text = "Run";
            btnRun.Position = new Vector2(cmdPosX, cmdPosY + spacing *2);

            ControlManager.Add(btnRun);

            Button test = new Button();
            test.Text = "TEst";
            test.Position = new Vector2(cmdPosX, cmdPosY + spacing * 3);

            ControlManager.Add(test);
        }

        /// <summary>
        /// Updates the screen
        /// </summary>
        /// <param name="t">snapshot of current time</param>
        public override void Update(GameTime t) {
            base.Update(t);
        }

        /// <summary>
        /// Draws the background on screen.
        /// </summary>
        /// <param name="s">the renderer</param>
        public override void Draw(SpriteBatch s) {
            base.Draw(s);
        }

        /// <summary>
        /// Handles the input of this screen
        /// </summary>
        public override void HandleInput() {
            base.HandleInput();
        }
    }
}
