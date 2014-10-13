using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BouncingBall
{
    class GameManager
    {
        public void Update(GameTime gameTime, MainGameClass game)
        {
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
