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

        private Simulation parentSimaultion;

        private BoundingSphere boundingsphere;

        [XmlIgnore]
        private Texture2D _texture;

        private Vector2 _position;
        private Vector2 _nextPosition;
        private Vector2 _size;
        private Vector2 _origin;
        private Vector2 _scale;
        private Vector2 _velocity;
        private Vector2 _speed;
        private Vector2 _maxSpeed;
        private Vector2 _direction;

        private float _rotation;
        private float _zDepth;
        private float _mass;

        private bool _visible;
        private bool _enabled;

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
                _scale = value;
            }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Vector2 Speed
        {
            get { return _speed; }
        }

        public Vector2 MaxSpeed
        {
            get { return _maxSpeed; }
            set { if (value.X > 0 && value.Y > 0) _maxSpeed = value; else throw new Exception("Max speed must be greater than zero"); }
        }

        public Vector2 Direction
        {
            get { return _direction; }
            set 
            {
                if (value.X > 0) _direction.X = 1;
                else if (value.X == 0) _direction.X = 0;
                else _direction.X = -1;

                if (value.Y > 0) _direction.Y = 1;
                else if (value.Y == 0) _direction.Y = 0;
                else _direction.Y = -1;
            }
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public float Mass
        {
            get { return _mass; }
            set { if (value >= 0) _mass = value; else throw new Exception("Mass must be positive"); }
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

        public bool Visible
        {
            get { return _visible; }
            set 
            { 
                if (_visible != value)
                {
                    if (VisibleChanged != null)
                    {
                        VisibleChanged(this, null);
                    }
                    _visible = value;
                }
            }
        }

        public DynamicBall(Vector2 pos, Vector2 size, Vector2 scale, Vector2 velocity, Vector2 maxSpeed, float mass, float rotation,  string texPath, Simulation parentSim)
        {
            Position = pos;
            Size = size;
            TexturePath = texPath;
            Velocity = new Vector2(velocity.X, 0);
            MaxSpeed = maxSpeed;
            Scale = scale;
            Mass = mass;
            Rotation = rotation;
            parentSimaultion = parentSim;
            boundingsphere.Center = new Vector3(pos, 0);
            boundingsphere.Radius = size.X/2;
            _visible = true;
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
            _velocity.Y = (parentSimaultion.g * Mass) / 5;
            _speed.X = (Math.Min(_speed.X + Velocity.X, MaxSpeed.X)) * Direction.X;
            _speed.Y = (Math.Min(_speed.Y + (Velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds), MaxSpeed.Y)) * Direction.Y;

            _nextPosition = _position + _speed;

            if (!((_nextPosition.Y + Size.Y) > ScreenManager.Instance.ScreenSize.Y))
            {
                _position.Y = MathHelper.Lerp(_position.Y, _nextPosition.Y, _speed.Y);
                _direction.Y = 1;
            }
            else
            {
                _direction.Y = 0;
            }
        }

        public void Draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                Origin = new Vector2(0, 0);//(Texture.Width * Scale.X) / 2, (Texture.Height * Scale.Y) / 2); 
                spriteBatch.Draw(Texture, Position, null, Color.White, Rotation, Origin, Scale, SpriteEffects.None, ZDepth);
            }
        }

    }
}
