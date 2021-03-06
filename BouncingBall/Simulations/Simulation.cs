﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Engine.Objects;

namespace Engine.Simulations
{
    public class Simulation
    {
        private string _name;

        private List<IDynamicObject> _dynamicObjects;
        private List<IStaticObject> _staticObjects;

        private IObject _selectedObject;

        public readonly float g;

        [XmlIgnore]
        public ContentManager Content { get; private set; }

        [XmlIgnore]
        public bool Enabled { get; private set; }

        public List<IDynamicObject> DynamicObjects { get { return _dynamicObjects; } private set { _dynamicObjects = value; } }
        public List<IStaticObject> StaticObjects { get { return _staticObjects; } private set { _staticObjects = value; } }

        public string Name
        {
            get { return _name; }
        }

        public IObject SelectedObject
        {
            get { return _selectedObject; }
            set { _selectedObject = value; }
        }

        public Simulation(string name, float g)
        {
            this.g = g;
            _name = name;
            Enabled = false;
        }

        public void Initialize()
        {
            _dynamicObjects = new List<IDynamicObject>();
            _staticObjects = new List<IStaticObject>();            
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
                foreach (IDynamicObject dynamicObject in DynamicObjects)
                {
                    dynamicObject.Update(gameTime);
                }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //if (Enabled)
            {
                foreach (IDynamicObject dynamicObject in DynamicObjects)
                {
                    dynamicObject.Draw(spriteBatch, gameTime);
                }

                foreach (IDrawableObject staticObject in StaticObjects)
                {
                    staticObject.Draw(spriteBatch, gameTime);
                }
            }
        }

        public void Stop()
        {
            Enabled = false;
        }

        public void Start()
        {
            Enabled = true;
        }

        public void Pause()
        {
            Enabled = false;
        }

        public void AddDynamicObject(IDynamicObject dynamicObject)
        {
            dynamicObject.ParentSimulation = this;
            if (dynamicObject.Name == string.Empty)
                _name = dynamicObject.GetType().ToString() + DynamicObjects.Count.ToString() ?? "0";
            DynamicObjects.Add(dynamicObject);
        }

        public void AddStaticObject(IStaticObject staticObject)
        {
            StaticObjects.Add(staticObject);
        }
        
    }
}
