using Engine.Input;
using Engine.Objects;
using Engine.Screens;
using Engine.Simulations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    class GameManager
    {

        #region Singleton

        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                _instance = _instance ?? new GameManager();
                return _instance;
            }
        }

        #endregion

        private ContentManager _content;

        public ContentManager Content
        {
            get { return _content; }
        }

        public void Initialize(ContentManager content)
        {
            _content = content;
            ScreenManager.Instance.Initialize(Content);
            ScreenManager.Instance.SetScreenSize(640, 480);
            ScreenManager.Instance.SetCurrentScreen(new SimulationScreen());
            SimulationManager.Instance.SetCurrentSimulation(new Simulation("TestSimulation", 9.8f));
            SimulationManager.Instance.GetCurrentSimulation().Initialize();
            
        }

        public void LoadContent()
        {

            SimulationManager.Instance.GetCurrentSimulation().AddDynamicObject(new DynamicBall(new Vector2(250, 100), new Vector2(50, 50), new Vector2(1, 1), new Vector2(0.1f, 0f), new Vector2(8f, 3f), 3f, 0f, "1"));
            SimulationManager.Instance.GetCurrentSimulation().AddDynamicObject(new DynamicBall(new Vector2(250, 250), new Vector2(50, 50), new Vector2(1, 1), new Vector2(0.1f, 0f), new Vector2(8f, 12f), 10f, 0f, "1"));
            SimulationManager.Instance.GetCurrentSimulation().LoadContent(ScreenManager.Instance.CurrentScreen.Content);

        }

        public void Update(GameTime gameTime, MainGameClass game)
        {
            InputManager.Instance.Update(gameTime);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                SimulationManager.Instance.GetCurrentSimulation().Stop();
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                SimulationManager.Instance.GetCurrentSimulation().Start();


            ScreenManager.Instance.CurrentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.Additive, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullNone, null);
            ScreenManager.Instance.CurrentScreen.Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }

        public void DebugDraw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
            ScreenManager.Instance.CurrentScreen.Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }
    }
}
