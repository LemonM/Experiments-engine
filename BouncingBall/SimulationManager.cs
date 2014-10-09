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
            if (ScreenManager.Instance.CurrentScreen != null && ScreenManager.Instance.CurrentScreen is SimulationScreen && Instance.currentSimulation != null)
            {
                if (Instance.currentSimulation != null)
                {
                    Instance.currentSimulation.Stop();
                    Instance.currentSimulation.UnloadContent();
                }
                Instance.currentSimulation = simulation;
                Instance.currentSimulation.Initialize();
                Instance.currentSimulation.LoadContent((ScreenManager.Instance.CurrentScreen as SimulationScreen).Content);
                Instance.currentSimulation.Start();
            }
            else
                throw new Exception("Current screen must be Simulation screen to load the simulation");
        }

        public void SetCurrentSimulation(string simulationName)
        {
            if (ScreenManager.Instance.CurrentScreen != null && ScreenManager.Instance.CurrentScreen is SimulationScreen)
            {
                if (Instance.currentSimulation != null)
                {
                    Instance.currentSimulation.Stop();
                    Instance.currentSimulation.UnloadContent();
                }
                currentSimulation = LoadSimulation(simulationName);
                Instance.currentSimulation.Initialize();
                Instance.currentSimulation.LoadContent((ScreenManager.Instance.CurrentScreen as SimulationScreen).Content);
                Instance.currentSimulation.Start();
            }
            else
                throw new Exception("Current screen must be Simulation screen to load the simulation");
        }

        public Simulation GetCurrentSimulation()
        {
            return currentSimulation;
        }
    }
}
