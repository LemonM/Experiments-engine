using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BouncingBall
{
    class Simulation
    {
        private List<IDynamicObject> _dynamicObjects;
        private List<IStaticObject> _staticObjects;

        public readonly float g;

        [XmlIgnore]
        private ContentManager Content;

        [XmlIgnore]
        public bool Enabled { get; private set; }
        public int UpdateOrder { get; private set; }

        public List<IDynamicObject> DynamicObjects { get { return _dynamicObjects; } set { _dynamicObjects = value; } }
        public List<IStaticObject> StaticObjects { get { return _staticObjects; } set { _staticObjects = value; } }

        public Simulation(float g)
        {
            this.g = g;
        }

        public void Initialize()
        {
            _dynamicObjects = new List<IDynamicObject>();
            _staticObjects = new List<IStaticObject>();
            Enabled = true;
        }

        public void LoadContent(ContentManager content)
        {
            if (Content == null)
                Content = new ContentManager(content.ServiceProvider);

            foreach (IDynamicObject dynamicObject in DynamicObjects)
            {
                dynamicObject.LoadContent(Content);
            }

            foreach (IStaticObject staticObject in StaticObjects)
            {
                staticObject.LoadContent(Content);
            }
        }

        public void UnloadContent()
        {
            Content.Unload();
        }
        public void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                foreach (IDynamicObject dynamicObject in DynamicObjects)
                {
                    dynamicObject.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Enabled)
            {
                foreach (IDynamicObject dynamicObject in DynamicObjects)
                {
                    dynamicObject.Draw(gameTime, spriteBatch);
                }

                foreach (IStaticObject staticObject in StaticObjects)
                {
                    staticObject.Draw(gameTime);
                }
            }
        }

        public void Stop()
        {
            Enabled = false;
            UnloadContent();
        }

        public void Start(ContentManager content)
        {
            Enabled = true;
        }

        public void Pause()
        {
            Enabled = false;
        }

        public void AddDynamicObject(IDynamicObject dynamicObject)
        {
            DynamicObjects.Add(dynamicObject);
        }

        public void AddStaticObject(IStaticObject staticObject)
        {
            StaticObjects.Add(staticObject);
        }

        
        
    }
}
