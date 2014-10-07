using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall
{
    interface IDynamicObject : IDrawableObject, IUpdateable, IDrawable
    {
        event EventHandler OnDrag;
        event EventHandler OnLMBDown;
        event EventHandler OnLMBRelease;
    }
}
