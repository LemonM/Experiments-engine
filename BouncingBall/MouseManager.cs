using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BouncingBall
{
    class MouseManager
    {
        public event EventHandler OnLMBDown;
        public event EventHandler OnLMBRelease;
        public event EventHandler OnLMBClick;
    }
}
