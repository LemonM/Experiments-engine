using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall
{
    interface IObject
    {
        event EventHandler OnClick;

        Vector2 Position { get; set; }
        Vector2 Size { get; set; }
        Vector2 Origin { get; set; }


        void Initialize();
        void LoadContent(ContentManager content);
    }
}
