using Engine.Simulations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Screens
{
    public class SimulationScreen : Screen
    {

        #region Simulation Screen

        public Simulation CurrentSimulation { get { return SimulationManager.Instance.GetCurrentSimulation(); } }

        private SerializationManager<Simulation> serializer;

        public SimulationScreen()
        {
            
        }

        public void Initialize()
        {
            serializer = new SerializationManager<Simulation>();
            CurrentSimulation.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            if (CurrentSimulation != null)
                CurrentSimulation.LoadContent(Content);
        }

        public override void Update(GameTime gameTime)
        {
            CurrentSimulation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            CurrentSimulation.Draw(spriteBatch, gameTime);
        }

        #endregion
    }
}
