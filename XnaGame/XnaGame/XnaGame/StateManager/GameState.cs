using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using XnaGame.Input.Controls;

namespace XnaGame.StateManager {
    /// <summary>
    /// Abstract class of game states. 
    /// This class is inherited by game screens.
    /// </summary>
    public abstract class GameState {
        /// <summary>
        /// The Background texture of the state
        /// </summary>
        private Texture2D Background;
        /// <summary>
        /// Reference to the Game1 class. Used for getting ContentManager and SpriteBatch.
        /// </summary>
        protected Game1 GameRef;
        /// <summary>
        /// StateManager reference to call PushState and PopState
        /// </summary>
        protected GameStateManager StateManager;
        /// <summary>
        /// List of controls in the screen
        /// </summary>
        protected ControlManager ControlManager;

        /// <summary>
        /// Set GameRef and StateManager
        /// </summary>
        /// <param name="game">Game1 reference</param>
        /// <param name="man">StateManager that this class belongs to</param>
        public GameState(Game1 game, GameStateManager man) {
            GameRef = game;
            StateManager = man;
        }

        /// <summary>
        /// Loads the content of the game state
        /// </summary>
        public virtual void LoadContent() {
            ContentManager Content = GameRef.Content;
            SpriteFont font = Content.Load<SpriteFont>("menuFont");

            ControlManager = new ControlManager(font);
        }
      
        /// <summary>
        /// Updates the game screen
        /// </summary>
        /// <param name="t">snapshot of current time</param>
        public virtual void Update(GameTime t) {
            ControlManager.Update(t);
        }
       
        /// <summary>
        /// Draws the content of this game state.
        /// </summary>
        /// <param name="s">the renderer</param>
        public virtual void Draw(SpriteBatch s) {
            if (Background != null)
                s.Draw(Background, GameRef.ScreenRectangle, Color.White);

            ControlManager.Draw(s);
        }

        /// <summary>
        /// Handles the inputs of the game state
        /// </summary>
        public virtual void HandleInput() {
            ControlManager.HandleInput();
        }
    }
}
