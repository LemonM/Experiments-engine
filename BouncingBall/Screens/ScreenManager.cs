using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Engine.Screens
{
    class ScreenManager
    {

        #region Singleton

        private static ScreenManager _instance;

        public static ScreenManager Instance
        {
            get
            {
                _instance = _instance ?? new ScreenManager();
                return _instance;
            }
        }

        #endregion

        private Vector2 _scrSize;
        private float _ratio;
        private Vector2 _scrOrigin;
        private GraphicsDeviceManager _gdm;
        private Screen _currentScreen;
        public ContentManager Content { get; private set; }

        public event EventHandler<ScreenSizeEventArgs> OnScreenSizeChanged;
        public event EventHandler<ScreenChangingEventArgs> OnScreenChangingStart;
        public event EventHandler<ScreenChangingEventArgs> OnScreenChanged;

        public GraphicsDeviceManager GDM
        {
            get { return _gdm; }
            set { _gdm = value; }
        }

        public Screen CurrentScreen
        {
            get { return _currentScreen; }
        }

        public Vector2 ScreenSize
        {
            get { return _scrSize; }
        }

        public float Ratio
        {
            get { return _ratio; }
        }

        public Vector2 ScreenOrigin
        {
            get { return _scrOrigin; }
        }

        private ScreenManager()
        {

        }

        public void Initialize(ContentManager content)
        {
            Content = content;
        }

        public void SetCurrentScreen(Screen scr)
        {
            ScreenChangingEventArgs args = new ScreenChangingEventArgs(CurrentScreen, scr);
            if (OnScreenChangingStart != null)
                OnScreenChangingStart(this, args);

            if (CurrentScreen != null)
            {
                CurrentScreen.Pause();
                CurrentScreen.UnloadContent();
            }
            _currentScreen = scr;
            CurrentScreen.LoadContent(Content);
            _currentScreen.Start();

            if (OnScreenSizeChanged != null)
                OnScreenChanged(this, args);
        }

        public void SetScreenSize(int x, int y)
        {
            if ((ScreenManager.Instance.CurrentScreen as SimulationScreen) != null && ScreenManager.Instance.CurrentScreen is SimulationScreen)
                (ScreenManager.Instance.CurrentScreen as SimulationScreen).CurrentSimulation.Pause();
            if (x < 1 || y < 1)
                throw new Exception("Screen size must be greater than zero.");

            Vector2 prevSize = ScreenSize;
            Vector2 newSize = new Vector2(x, y);
            float prevRatio = _ratio;
            _scrSize.X = x;
            _scrSize.Y = y;
            _ratio = x/y;
            _scrOrigin = new Vector2(x / 2, y / 2);
            GDM.PreferredBackBufferWidth = (int)ScreenSize.X;
            GDM.PreferredBackBufferHeight = (int)ScreenSize.Y;
            if (OnScreenSizeChanged != null)
                OnScreenSizeChanged(this, new ScreenSizeEventArgs(prevSize, newSize, prevRatio, _ratio));
            GDM.ApplyChanges();
            if ((ScreenManager.Instance.CurrentScreen as SimulationScreen) != null && ScreenManager.Instance.CurrentScreen is SimulationScreen)
                (ScreenManager.Instance.CurrentScreen as SimulationScreen).CurrentSimulation.Start();
        }

        public void ToggleFullScreen()
        {
            if (ScreenManager.Instance.CurrentScreen is SimulationScreen && (ScreenManager.Instance.CurrentScreen as SimulationScreen).CurrentSimulation != null)
                (ScreenManager.Instance.CurrentScreen as SimulationScreen).CurrentSimulation.Pause();
            GDM.ToggleFullScreen();
            GDM.ApplyChanges();
            if (ScreenManager.Instance.CurrentScreen is SimulationScreen && (ScreenManager.Instance.CurrentScreen as SimulationScreen).CurrentSimulation != null)
                (ScreenManager.Instance.CurrentScreen as SimulationScreen).CurrentSimulation.Start();
        }
    }
}
