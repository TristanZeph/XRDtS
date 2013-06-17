using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace XnaGame.Input {
    /// <summary>
    /// Class manages keyboard and mouse states and updates them.
    /// </summary>
    class InputHandler : GameComponent{
        static KeyboardState keyboardCurrentState, keyboardPreviousState;
        static MouseState mouseCurrentState, mousePreviousState;

        /// <summary>
        /// Intialises keyboard and mouse states
        /// </summary>
        /// <param name="game">gamecomponent reference</param>
        public InputHandler(Game1 game)
            : base(game) {
                keyboardCurrentState = keyboardPreviousState = Keyboard.GetState();
                mouseCurrentState = mousePreviousState = Mouse.GetState();
        }

        /// <summary>
        /// Updates the keyboard and mouse states
        /// </summary>
        /// <param name="gameTime">snapshot of time</param>
        public override void Update(GameTime gameTime) {
            keyboardPreviousState = keyboardCurrentState;
            keyboardCurrentState = Keyboard.GetState();

            mousePreviousState = mouseCurrentState;
            mouseCurrentState = Mouse.GetState();

            base.Update(gameTime);
        }

        /// <summary>
        /// Make keyboard and mouse states equal to each other to prevent 
        /// input conflicts when GameStateManager transitions states.
        /// </summary>
        public static void FlushStates() {
            keyboardCurrentState = keyboardPreviousState;
            mouseCurrentState = mousePreviousState;
        }

        /// <summary>
        /// Returns bool if key is held down
        /// </summary>
        public static bool KeyDown(Keys k) {
            return keyboardCurrentState.IsKeyDown(k);
        }

        /// <summary>
        /// Returns bool if keys was previously up and currently pressed.
        /// </summary>
        public static bool KeyPressed(Keys k) {
            return keyboardPreviousState.IsKeyUp(k) &&
                keyboardCurrentState.IsKeyDown(k);
        }

        /// <summary>
        /// Returns bool if key was previously pressed and currently released.
        /// </summary>
        public static bool KeyReleased(Keys k) {
            return keyboardPreviousState.IsKeyDown(k) &&
                keyboardCurrentState.IsKeyUp(k);
        }
    }
}
