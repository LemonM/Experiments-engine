using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall
{
    public interface IDynamicObject : IDrawableObject
    {
        event EventHandler OnDrag;
        event EventHandler OnLMBDown;
        event EventHandler OnLMBRelease;

        Vector2 Velocity { get; set; }
        Vector2 Speed    { get; }
        Vector2 MaxSpeed { get; set; }
        float Mass { get; set; }

        void Update(GameTime gameTime);
    }
}
