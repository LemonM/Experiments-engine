using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine.Input
{
    class MouseManager
    {



        public event EventHandler OnLMBDown;
        public event EventHandler OnLMBClick;

        private MouseState _prevState;
        private MouseState _currState;

        Point Position
        {
            get
            {
                return Mouse.GetState().Position;
            }
            set
            {
                Mouse.SetPosition(value.X, value.Y);
            }
        }

        void Update()
        {
            _currState = Mouse.GetState();

            if (_currState.LeftButton == ButtonState.Pressed)
                if (OnLMBDown != null)
                    OnLMBDown(this, new MouseEventArgs());

            if (_prevState.LeftButton == ButtonState.Pressed && _currState.LeftButton == ButtonState.Released)
                if (OnLMBClick != null)
                    OnLMBClick(this, new MouseEventArgs());

            _prevState = _currState;

        }
    }
}
