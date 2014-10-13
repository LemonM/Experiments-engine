using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BouncingBall
{
    public class ScreenChangingEventArgs : EventArgs
    {
        public Screen PreviousScreen { get; private set; }
        public Screen NewScreen { get; private set; }

        public ScreenChangingEventArgs(Screen prevScreen, Screen newScreen)
        {
            PreviousScreen = prevScreen;
            NewScreen = newScreen;
        }
    }
}
