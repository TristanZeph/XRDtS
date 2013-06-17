using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using XnaGame.StateManager;
using XnaGame.Input;
using XnaGame.Input.Controls;

namespace XnaGame.GameScreens {
    /// <summary>
    /// The titlescreen of the game
    /// </summary>
    public class TitleScreen : GameState {
        private const int cmdPosX = 350;
        private const int cmdPosY = 400;
        private const int spacing = 25;

        /// <summary>
        /// pass game and stateManager reference
        /// </summary>
        public TitleScreen(Game1 game, GameStateManager man)
            : base(game, man) {
        }

        /// <summary>
        /// Loads the screens contents
        /// </summary>
        public override void LoadContent() {
            base.LoadContent();

            ContentManager Content = GameRef.Content;

            // debug map screen
            Button mapDebug = new Button();
            mapDebug.Text = "Debug Map";
            mapDebug.Position = new Vector2(cmdPosX, cmdPosY);

            ControlManager.Add(mapDebug);

            // debug BattleScreen button
            Button battleDebug = new Button();
            battleDebug.Text = "Debug Battle";
            battleDebug.Position = new Vector2(cmdPosX, cmdPosY + spacing);
            battleDebug.HasFocus = true;
            battleDebug.Selected += new EventHandler(battleDebug_Selected);

            ControlManager.Add(battleDebug);
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

        /// <summary>
        /// Push BattleScreen to stateManager stack.
        /// pop this screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void battleDebug_Selected(object sender, EventArgs e) {
            StateManager.ChangeState(GameRef.BattleScreen);
        }
    }
}
