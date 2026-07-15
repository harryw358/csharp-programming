using System;
using System.Collections.Generic;
using System.Text;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NEAPROJECT.Training;

namespace NEAPROJECT.Sprites
{
    public class Ammunition : Sprite
    {
        protected double _timer;
        protected double _lifeSpan;
        protected Weapon _weapon;
        protected bool _isRemoved;
        private bool _hasCollided;
        private bool _canBleed;

        public double Timer { get => _timer;set => _timer = value; }
        public double LifeSpan { get => _lifeSpan; set => _lifeSpan = value; }
        public Weapon Weapon { get => _weapon; set => _weapon = value; }
        public bool IsRemoved { get => _isRemoved; set => _isRemoved = value; }
        public bool HasCollided { get => _hasCollided; set => _hasCollided = value; }
        public bool CanBleed { get => _canBleed; set => _canBleed = value; }

        public Ammunition(Texture2D texture) : base(texture)
        {
            _isRemoved = false;
        }

        public Ammunition(Dictionary<string, Animation> animations) : base(animations)
        {

        }

        public override void Update(GameTime gameTime, CustomLinkedList components)
        {
            double elapsedGameTime = gameTime.ElapsedGameTime.TotalSeconds;
            _timer += elapsedGameTime;  

            if (_timer >= _lifeSpan)
            {
                _isRemoved = true;
            }
            if (!_isRemoved)
            {
                if (IsTouchingLeft(_weapon.Owner.Opponent) || IsTouchingRight(_weapon.Owner.Opponent))
                {
                    _hasCollided = true;
                }
                if (_hasCollided)
                {
                    OnCollide(_weapon.Owner.Opponent);
                }

                _position += _direction * _speed;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!_isRemoved)
            {
                spriteBatch.Draw(_texture, _position, Color.White);
            }
        }

        public object Duplicate()
        {
            // creates a copy of ammunition and assigns new ammunition object whos values are the same as the original copy
            return MemberwiseClone();
        }

        public virtual void OnCollide(Sprite hitSprite)
        {
            if (hitSprite is Player)
            {
                Player hitPlayer = (Player)hitSprite;

                if (hitPlayer.Shield != null && hitPlayer.Shield.IsEquipped && hitPlayer.Shield.Health > 0)
                {
                    hitPlayer.Shield.Health -= _weapon.DamageAmount;
                }
                else
                {
                    if (hitPlayer.Armour > 0)
                    {
                        hitPlayer.Armour -= _weapon.DamageAmount * 0.7;
                        hitPlayer.Health -= Convert.ToInt32(_weapon.DamageAmount * 0.7);
                    }
                    else
                    {
                        hitPlayer.Health -= _weapon.DamageAmount;
                        if (_canBleed)
                        {
                            hitPlayer.BleedActive = true;
                        }
                    }
                    _weapon.Owner.Points += 10;
                }
            }
            if (hitSprite is AITemplate)
            {
                AITemplate hitAI = (AITemplate)hitSprite;

                hitAI.IsBeingAttacked = true;
            }

            if (_weapon.SnareAmmunition != null)
            {
                _weapon.AddSnareAmmunition(_weapon.SpriteComponents, _position);
                _weapon.SnareAmmunition.StartSnareTimer();
            }

            _isRemoved = true;
            _hasCollided = false;
            _position = new Vector2(3000, 3000);

        }
    }
}

