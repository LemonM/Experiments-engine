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

        private static InputManager Instance
        {
            get { _instance = _instance ?? new InputManager(); return _instance; }
        }

        private KeyboardManager _kBoard = new KeyboardManager();

        public KeyboardManager KBoard { get { return _kBoard; } }

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
    }
}
