using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BouncingBall
{
    class SimulationManager
    {
        private static SimulationManager _instance;

        public static SimulationManager Instance
        {
            get
            {
                _instance = _instance ?? new SimulationManager();
                return _instance;
            }
        }

        private Simulation currentSimulation;

        private SerializationManager<Simulation> serializer;

        public Simulation LoadSimulation(string simulationName)
        {
            return serializer.Deserialize(ScreenManager.Instance.Content.RootDirectory + @"\Simulations\" + simulationName);
        }

        public bool SaveSimulation(string simulationName)
        {
            return serializer.Serialize(currentSimulation, ScreenManager.Instance.Content.RootDirectory + @"\Simulations\" + simulationName);
        }

        public void SetCurrentSimulation(Simulation simulation)
        {
            if (currentSimulation != null)
            {
                currentSimulation.Stop();
                currentSimulation.UnloadContent();
            }
            currentSimulation = simulation;
            currentSimulation.Initialize();
            currentSimulation.LoadContent();
            currentSimulation.Start();
        }

        public void SetCurrentSimulation(string simulationName)
        {
            if (currentSimulation != null)
            {
                currentSimulation.Stop();
                currentSimulation.UnloadContent();
            }
            currentSimulation = LoadSimulation(simulationName);
            currentSimulation.LoadContent(Content);
            currentSimulation.Start();
        }

        public Simulation GetCurrentSimulation()
        {
            return currentSimulation;
        }
    }
}
