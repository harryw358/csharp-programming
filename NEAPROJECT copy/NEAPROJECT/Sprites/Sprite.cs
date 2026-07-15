using NEAPROJECT.Controllers;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.States;
using NEAPROJECT.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NEAPROJECT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEAPROJECT
{
    public class Sprite : Component
    {
        protected bool _inAnimationLock;
        public bool InAnimationLock { get => _inAnimationLock; set => _inAnimationLock = value; }

        protected AnimationController _animator;
        protected Dictionary<string, Animation> _animations;
        protected State _state;
        protected CustomLinkedList _spriteComponents;

        public AnimationController Animator { get => _animator; set => _animator = value; }
        public Dictionary<string, Animation> Animations { get => _animations; }
        public CustomLinkedList SpriteComponents { get => _spriteComponents; set => _spriteComponents = value; }

        protected Texture2D _texture;
        protected Color _colour;
        protected Vector2 _velocity;
        protected int _speed;
        protected Vector2 _direction;
        protected float _linearVelocity;
        protected Input _input;
        protected bool _requiresCollisionDetection;

        public Texture2D Texture { get => _texture; set => _texture = value; }
        public Color Colour { get => _colour; set => _colour = value; }
        public Vector2 Velocity { get => _velocity; set => _velocity = value; }
        public float XVelocity { get => _velocity.X; set => _velocity.X = value; }
        public float YVelocity { get => _velocity.Y; set => _velocity.Y = value; }
        public int Speed { get => _speed; set => _speed = value; }
        public Vector2 Direction { get => _direction; set => _direction = value; }
        public float LinearVelocity { get => _linearVelocity; set => _linearVelocity = value; }
        public Input Input { get => _input; set => _input = value; }
        public bool RequiresCollisionDetection { get => _requiresCollisionDetection; set => _requiresCollisionDetection = value; }

        public override Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                if (_animator != null)
                {
                    _animator.Position = _position;
                }
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                int height = 0, width = 0;
                if (_texture == null)
                {
                    if (this is Player)
                    {
                        height = _animations["LeftRun"].Height;
                        width = _animations["LeftRun"].Width;
                    }
                    else if (this is SnareAmmunition)
                    {
                        height = _animations["Fire"].Height;
                        width = _animations["Fire"].Width;
                    }
                }
                else
                {
                    height = _texture.Height;
                    width = _texture.Width;
                }
                return new Rectangle((int)_position.X, (int)_position.Y, width, height);
            }
        }

        public Sprite(Texture2D texture)
        {
            // constructor for inanimate sprites such as backgrounds and the HUD

            _texture = texture;
            _colour = Color.White;

            _spriteComponents = new CustomLinkedList();
        }

        public Sprite(Dictionary<string, Animation> animations)
        {
            // constructor for animate sprites such as player, AI, and effects

            _animations = animations;
            _animator = new AnimationController(_animations.First().Value, this);
            _colour = Color.White;

            _spriteComponents = new CustomLinkedList();
        }

        public override void Update(GameTime gameTime, CustomLinkedList components)
        {
            for (int i = 1; i <= _spriteComponents.Count; i++)
            {
                Component currentComponent = _spriteComponents.SearchList(i);
                currentComponent.Update(gameTime, _spriteComponents);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
            {
                spriteBatch.Draw(_texture, _position, _colour);
            }
            else if (_animator != null)
            {
                _animator.Draw(spriteBatch);
            }
            for (int i = 1; i <= _spriteComponents.Count; i++)
            {
                Component currentComponent = _spriteComponents.SearchList(i);
                currentComponent.Draw(spriteBatch);
            }
        }

        protected bool IsTouchingLeft(Sprite sprite)
        {
            return Rectangle.Right + _velocity.X > sprite.Rectangle.Left &&
                Rectangle.Left < sprite.Rectangle.Left &&
                Rectangle.Bottom > sprite.Rectangle.Top &&
                Rectangle.Top < sprite.Rectangle.Bottom;
        }
        protected bool IsTouchingRight(Sprite sprite)
        {
            return Rectangle.Left + _velocity.X < sprite.Rectangle.Right &&
                Rectangle.Right > sprite.Rectangle.Right &&
                Rectangle.Bottom > sprite.Rectangle.Top &&
                Rectangle.Top < sprite.Rectangle.Bottom;
        }
    }
}
