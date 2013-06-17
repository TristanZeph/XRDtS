using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using XnaGame.StateManager;
using XnaGame.GameScreens;
using XnaGame.Input;

namespace XnaGame {
    /// <summary>
    /// The game runs here. 
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game {
        private int width = 800;
        private int height = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameStateManager stateManager;

        //screens in the game
        public TitleScreen TitleScreen;
        public BattleScreen BattleScreen;

        public Rectangle ScreenRectangle;

        public Game1() {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;

            ScreenRectangle = new Rectangle(0, 0, width, height);

            Components.Add(new InputHandler(this));
            stateManager = new GameStateManager(this);

            TitleScreen = new TitleScreen(this, stateManager);
            BattleScreen = new BattleScreen(this, stateManager);
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            stateManager.PushState(TitleScreen);
        }
        
        protected override void Update(GameTime gameTime) {
            stateManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            stateManager.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
