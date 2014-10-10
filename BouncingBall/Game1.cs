#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace BouncingBall
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            ScreenManager.Instance.GDM = graphics;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenManager.Instance.Initialize(Content);
            ScreenManager.Instance.SetScreenSize(640, 480);
            ScreenManager.Instance.SetCurrentScreen(new SimulationScreen());
            SimulationManager.Instance.SetCurrentSimulation(new Simulation("TestSimulation", 9.8f));
            SimulationManager.Instance.GetCurrentSimulation().Initialize();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            SimulationManager.Instance.GetCurrentSimulation().AddDynamicObject(new DynamicBall(new Vector2(250, 100), new Vector2(50, 50), new Vector2(1, 1), new Vector2(0.1f, 0f), new Vector2(8f, 3f), 1f, 0f, "1", SimulationManager.Instance.GetCurrentSimulation()));
            SimulationManager.Instance.GetCurrentSimulation().AddDynamicObject(new DynamicBall(new Vector2(250, 250), new Vector2(50, 50), new Vector2(1, 1), new Vector2(0.1f, 0f), new Vector2(8f, 3f), 1f, 0f, "1", SimulationManager.Instance.GetCurrentSimulation()));
            SimulationManager.Instance.GetCurrentSimulation().LoadContent(ScreenManager.Instance.CurrentScreen.Content);
            

            
     
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            ScreenManager.Instance.CurrentScreen.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                SimulationManager.Instance.GetCurrentSimulation().Stop();
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                SimulationManager.Instance.GetCurrentSimulation().Start();

            ScreenManager.Instance.CurrentScreen.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.Additive, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullNone, null);

            // TODO: Add your drawing code here

            ScreenManager.Instance.CurrentScreen.Draw(spriteBatch, gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
