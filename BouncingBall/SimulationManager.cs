using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall
{
    class SimulationManager
    {
        private Simulation currentSimulation;

        private SerializationManager<Simulation> serializer;

        protected static SimulationManager _instance;

        private Vector2 _screenSize;

        public ContentManager Content { get; private set; }

        public Vector2 ScreenSize
        {
            get { return _screenSize; }
            set { _screenSize = new Vector2(value.X < 1 ? 1 : value.X, value.Y < 1 ? 1 : value.Y);}
        }

        public static SimulationManager Instance 
        {
            get
            {
                if (_instance == null)
                    _instance = new SimulationManager();
                return _instance;
            } 
        }

        private SimulationManager()
        {

        }

        public void Initialize()
        {
            serializer = new SerializationManager<Simulation>();
            currentSimulation.Initialize();
        }

        public void LoadContent(ContentManager content)
        {
            Content = new ContentManager(content.ServiceProvider, content.RootDirectory);
        }

        public void Update(GameTime gameTime)
        {
            currentSimulation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            currentSimulation.Draw(spriteBatch, gameTime);
        }

        private Simulation LoadSimulation(string simulationName)
        {
            return serializer.Deserialize(Content.RootDirectory + @"\Simulations\" + simulationName);       
        }

        public bool SaveSimulation(string simulationName)
        {
            return serializer.Serialize(currentSimulation, Content.RootDirectory + @"\Simulations\" + simulationName);
        }

        public void SetCurrentSimulation(Simulation simulation)
        {
            if (currentSimulation != null)
                currentSimulation.Stop();
            currentSimulation = simulation;
            currentSimulation.Start(Content);
        }

        public void SetCurrentSimulation(string simulationName)
        {
            if (currentSimulation != null)
            currentSimulation.Stop();
            currentSimulation = LoadSimulation(simulationName);
            currentSimulation.Start(Content);
        }

        public Simulation GetCurrentSimulation()
        {
            return currentSimulation;
        }
    }
}
