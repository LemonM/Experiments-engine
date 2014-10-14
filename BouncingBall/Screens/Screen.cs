using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Screens
{
    public abstract class Screen
    {
        public ContentManager Content { get; set; }
        protected bool Enabled { get; set; }

        public void UnloadContent()
        {
            Content.Unload();
        }
        public virtual void LoadContent(ContentManager content)
        {
            Content = new ContentManager(content.ServiceProvider, content.RootDirectory);
        }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

        public void Pause()
        {
            Enabled = false;
        }

        public void Start()
        {
            Enabled = true;
        }
    }
}
