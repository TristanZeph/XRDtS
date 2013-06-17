using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using XnaGame.Input;

namespace XnaGame.StateManager {
    /// <summary>
    /// This class manages the game states in this game using a Stack.
    /// </summary>
    public class GameStateManager {
        /// <summary>
        /// Reference of the game
        /// </summary>
        private Game GameRef;
        /// <summary>
        /// Stack of gameStates. Top gameState will gain input.
        /// </summary>
        private Stack<GameState> gameStates;

        /// <summary>
        /// pass game, initialise gameState Stack
        /// </summary>
        /// <param name="game">the game</param>
        public GameStateManager(Game game) {
            GameRef = game;
            gameStates = new Stack<GameState>();
        }

        /// <summary>
        /// Updates all game states in the stack.
        /// Call HandleInput() top of stack
        /// </summary>
        /// <param name="t">snapshot of current time</param>
        public void Update(GameTime t) {
            if (gameStates.Count == 0) return;

            foreach (GameState state in gameStates.Reverse()) {
                state.Update(t);
            }

            gameStates.Peek().HandleInput();
        }

        /// <summary>
        /// Draws all gameStates in the stack
        /// </summary>
        /// <param name="s">the renderer</param>
        public void Draw(SpriteBatch s) {
            if (gameStates.Count == 0) return;

            GameRef.GraphicsDevice.Clear(Color.Black);

            foreach (GameState state in gameStates.Reverse()) {
                s.Begin();
                state.Draw(s);
                s.End();
            }
        }

        /// <summary>
        /// Pushes a gameState to the stack. Calls LoadContent()
        /// </summary>
        public void PushState(GameState state) {
            state.LoadContent();
            gameStates.Push(state);
        }

        /// <summary>
        /// Pops the gameState off the stack
        /// </summary>
        public void PopState() {
            if (gameStates.Count == 0) return;
            InputHandler.FlushStates();
            gameStates.Pop();
        }

        /// <summary>
        /// Pops current state and pushes the new state to the stack.
        /// </summary>
        public void ChangeState(GameState state) {
            PopState();
            PushState(state);
        }
    }
}
