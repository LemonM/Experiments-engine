using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Objects
{
    public interface IObject
    {
        event EventHandler OnDrag;
        event EventHandler OnLMBDown;
        event EventHandler OnLMBClick;

        Vector2 Position { get; set; }
        Vector2 Size { get; set; }
        Vector2 Origin { get; set; }

        string Name { get; set; }


        void Initialize();
        void LoadContent(ContentManager content);
    }
}
