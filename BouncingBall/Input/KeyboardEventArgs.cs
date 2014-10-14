using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Input
{
    class KeyboardEventArgs : EventArgs
    {
        readonly Keys[] PressedKeys;

        public KeyboardEventArgs(Keys[] pressedKs)
        {
            PressedKeys = pressedKs;
        }
    }
}
