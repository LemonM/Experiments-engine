using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using  System.Xml.Serialization;

namespace BouncingBall
{
    [Serializable]
    class DynamicBall : IDynamicObject
    {
        public event EventHandler OnDrag;

        public event EventHandler OnLMBDown;

        public event EventHandler OnLMBRelease;

        public event EventHandler OnClick;

        public event EventHandler<EventArgs> VisibleChanged;

        public event EventHandler<EventArgs> EnabledChanged;

        private Vector2 _position;

        private Vector2 _nextPosition;

        private Vector2 _size;

        private Vector2 _origin;

        private Vector2 _scale;

        private bool _enabled;

        private float _rotation;

        private float _zDepth;

        private Simulation parentSimaultion;

        private BoundingSphere boundingsphere;

        [XmlIgnore]
        private Texture2D _texture;

        private string _texturePath;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Vector2 Size
        {
            get { return _size; }
            set { _size = new Vector2(value.X > 0 ? value.X : 0, value.Y > 0 ? value.Y : 0); }
        }

        public Vector2 Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        public Vector2 Scale
        {
            get { return _scale; }
            set
            {
                if (_scale.X < 0 && _scale.Y < 0)
                    _scale = Vector2.Zero;
                if (_scale.X < 0)
                    _scale = new Vector2(0, _scale.Y);
                if (_scale.Y < 0)
                    _scale = new Vector2(_scale.X, 0);
            }
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public float ZDepth
        {
            get { return _zDepth; }
            set
            {
                if (value < 0)
                    throw new Exception("Z depth must be positive");
                _zDepth = value;
            }
        }

        [XmlIgnore]
        public Texture2D Texture
        {
            get
            {
                return _texture;
            }
        }

        public string TexturePath
        {
            get { return _texturePath; }
            set
            {
                _texturePath = File.Exists(value)
                    ? value
                    : ScreenManager.Instance.Content.RootDirectory + @"\Textures\DefaultBall" ;
            }
        }

        public bool Enabled
        {
            get { return _enabled; }
        }

        public event EventHandler<EventArgs> DrawOrderChanged;

        public bool Visible
        {
            get { throw new NotImplementedException(); }
        }

        public DynamicBall(Vector2 pos, Vector2 size, Vector2 scale, float rotation,  string texPath, Simulation parentSim)
        {
            Position = pos;
            Size = size;
            TexturePath = texPath;
            Scale = scale;
            Rotation = rotation;
            parentSimaultion = parentSim;
            boundingsphere.Center = new Vector3(pos, 0);
            boundingsphere.Radius = size.X/2;
        }

        public void Initialize()
        {

        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>(TexturePath);
        }

        public void Update(GameTime gameTime)
        {
            _nextPosition.Y = _position.Y + (parentSimaultion.g * (float)gameTime.ElapsedGameTime.TotalMilliseconds);

            if (!((_nextPosition.Y + Size.Y) > ScreenManager.Instance.ScreenSize.Y))
            {
                _position = _nextPosition;
            }
        }

        public int UpdateOrder
        {
            get { throw new NotImplementedException(); }
        }

        public event EventHandler<EventArgs> UpdateOrderChanged;

        public void Draw(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Origin = new Vector2(0, 0);//(Texture.Width * Scale.X) / 2, (Texture.Height * Scale.Y) / 2); 
            spriteBatch.Draw(Texture, Position, null, Color.White, Rotation, Origin, Scale, SpriteEffects.None, ZDepth);
        }

        public int DrawOrder
        {
            get { throw new NotImplementedException(); }
        }
    }
}
