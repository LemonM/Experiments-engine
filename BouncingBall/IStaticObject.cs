using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BouncingBall
{
    interface IStaticObject : IObject, IDrawable
    {
        bool IsVisible { get; set; }
    }
}
