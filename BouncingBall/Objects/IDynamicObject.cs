using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Simulations;

namespace Engine.Objects
{
    public interface IDynamicObject : IDrawableObject
    {
   
        Simulation ParentSimulation { get; set; }

        Vector2 Velocity { get; set; }
        Vector2 Speed    { get; }
        Vector2 MaxSpeed { get; set; }
        float Mass { get; set; }

        void Update(GameTime gameTime);
    }
}
