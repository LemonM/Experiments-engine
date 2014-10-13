#region Using Statements
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace BouncingBall
{
    /// <summary>
    /// This is the main type for game
    /// </summary>
    public class MainGameClass : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Forms.ObjectExplorer objExplorer = new Forms.ObjectExplorer();

        public MainGameClass()
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

            SimulationManager.Instance.GetCurrentSimulation().AddDynamicObject(new DynamicBall(new Vector2(250, 100), new Vector2(50, 50), new Vector2(1, 1), new Vector2(0.1f, 0f), new Vector2(8f, 3f), 3f, 0f, "1"));
            SimulationManager.Instance.GetCurrentSimulation().AddDynamicObject(new DynamicBall(new Vector2(250, 250), new Vector2(50, 50), new Vector2(1, 1), new Vector2(0.1f, 0f), new Vector2(8f, 12f), 10f, 0f, "1"));
            SimulationManager.Instance.GetCurrentSimulation().LoadContent(ScreenManager.Instance.CurrentScreen.Content);
            objExplorer.Show();
            objExplorer.ResumeLayout();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            ScreenManager.Instance.CurrentScreen.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }
    }
}
