using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BouncingBall
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

        private int _width;
        private int _height;
        private float _ratio;
        private Vector2 _scrOrigin;

        public event EventHandler<EventArgs> OnScreenSizeChanged; 

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public float Ratio
        {
            get { return _ratio; }
        }

        public Vector2 ScreenOrigin
        {
            get { return _scrOrigin; }
        }

        public void SetScreenSize(int x, int y)
        {
            if (x < 1 || y < 1)
                throw new Exception("Screen size must be greater than zero.");

            Vector2 prevSize = new Vector2(_width, _height);
            Vector2 newSize = new Vector2(x, y);
            float prevRatio = _ratio;
            _width = x;
            _height = y;
            _ratio = x/y;
            _scrOrigin = new Vector2(x / 2, y / 2);
            if (OnScreenSizeChanged != null)
                OnScreenSizeChanged(this, new ScreenSizeEventArgs(prevSize, newSize, prevRatio, _ratio));
        }
    }
}
