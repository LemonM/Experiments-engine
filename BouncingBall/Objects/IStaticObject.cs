using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Objects
{
    public interface IStaticObject : IObject
    {
        bool IsVisible { get; set; }
    }
}
