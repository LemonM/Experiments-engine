using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Input
{
    class InputManager
    {
        private static InputManager _instance;

        public static InputManager Instance
        {
            get { _instance = _instance ?? new InputManager(); return _instance; }
        }

        private KeyboardManager _kBoard = new KeyboardManager();
        private MouseManager _mouse = new MouseManager();

        public KeyboardManager KBoard { get { return _kBoard; } }
        public MouseManager MouseM { get { return _mouse; } }

        public void Update(GameTime gameTime)
        {
            _kBoard.Update();
            _mouse.Update();
        }

        public class KeyboardManager
        {

            event EventHandler<KeyboardEventArgs> OnKeyPress;
            event EventHandler<KeyboardEventArgs> OnKeyClick;

            KeyboardState kBoardCurrentState;
            KeyboardState kBoardPrevState;

            public void Update()
            {
                kBoardCurrentState = Keyboard.GetState();

                if (kBoardCurrentState.GetPressedKeys().Count() != 0)
                    if (OnKeyPress != null)
                        OnKeyPress(this, new KeyboardEventArgs(kBoardCurrentState.GetPressedKeys()));
                Keys[] ks = new Keys[kBoardPrevState.GetPressedKeys().Count()];

                for (int i = 0; i < kBoardPrevState.GetPressedKeys().Count(); i++)
                {
                    if (kBoardCurrentState.IsKeyUp( kBoardPrevState.GetPressedKeys()[i]))
                    {
                        ks[i] =  kBoardPrevState.GetPressedKeys()[i];                     
                    }
                }
                if (OnKeyClick != null)
                    OnKeyClick(this, new KeyboardEventArgs(ks));

                ks = null;
                kBoardPrevState = kBoardCurrentState;
            }

            public bool IsKeyPressed(Keys key)
            {
                return kBoardCurrentState.IsKeyDown(key);
            }
        }

        public class MouseManager
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

            public void Update()
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
}
