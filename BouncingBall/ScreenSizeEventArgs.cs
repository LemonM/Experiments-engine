using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BouncingBall
{
    class ScreenSizeEventArgs : EventArgs
    {
        private Vector2 _previoustScreenSize;
        private Vector2 _newScreenSize;
        private float _prevRatio;
        private float _newRatio;
        public Vector2 PreviousScreenSize
        {
            get { return _previoustScreenSize; }
            private set { _previoustScreenSize = value; }
        }

        public Vector2 NewScreenSize
        {
            get { return _newScreenSize; }
            private set { _newScreenSize = value; }
        }

        public float PreviousRatio
        {
            get { return _prevRatio; }
            private set { _prevRatio = value; }
        }

        public float NewRatio
        {
            get { return _newRatio; }
            private set { _newRatio = value; }
        }

        public ScreenSizeEventArgs(Vector2 prevScrSize, Vector2 newScrSize, float prevRatio, float newRatio)
        {
            PreviousScreenSize = prevScrSize;
            NewScreenSize = newScrSize;
            PreviousRatio = prevRatio;
            NewRatio = newRatio;
        }
    }
}
