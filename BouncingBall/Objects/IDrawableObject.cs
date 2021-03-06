﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Objects
{
    public interface IDrawableObject : IObject
    {
        Vector2 Scale { get; set; }

        float Rotation { get; set; }

        Texture2D Texture { get; }

        string TexturePath { get; set; }

        float ZDepth { get; set; }

        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
