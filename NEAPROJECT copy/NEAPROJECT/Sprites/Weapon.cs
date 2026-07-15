using System;
using Microsoft.Xna.Framework.Graphics;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Training;
using NEAPROJECT.Sprites;
using NEAPROJECT.States;

namespace NEAPROJECT.Sprites
{
    public class Weapon : Sprite
    {
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;

        protected Player _owner;
        protected Ammunition _ammunition;
        protected SnareAmmunition _snareAmmunition;
        protected int _ammunitionCount;
        protected SoundEffect _soundEffect;
        protected bool _canBeEquipped;
        protected bool _isEquipped;
        protected bool _multishotActive;

        protected bool _hasFired;
        protected int _damageAmount;

        public bool HasFired { get => _hasFired; set => _hasFired = value; }
        public Player Owner { get => _owner; set => _owner = value; }
        public Ammunition Ammunition { get => _ammunition; set => _ammunition = value; }
        public SnareAmmunition SnareAmmunition { get => _snareAmmunition; set => _snareAmmunition = value; }
        public int AmmunitionCount { get => _ammunitionCount; set => _ammunitionCount = value; }
        public SoundEffect SoundEffect { get => _soundEffect; set => _soundEffect = value; }
        public bool CanBeEquipped { get => _canBeEquipped; }
        public bool IsEquipped { get => _isEquipped; set => _isEquipped = value; }
        public bool MultishotActive { get => _multishotActive; set => _multishotActive = value; }

        public int DamageAmount { get => _damageAmount; set => _damageAmount = value; }

        public Weapon(Texture2D texture) : base(texture)
        {
            _canBeEquipped = true;
        }

        public override void Update(GameTime gameTime, CustomLinkedList components)
        {
            if (_isEquipped || _owner is MediumAI)
            {
                _position = _owner.Position;
                _direction = _owner.Direction;

                for (int i = 1; i <= _spriteComponents.Count; i++)
                {
                    Component currentComponent = _spriteComponents.SearchList(i);
                    currentComponent.Update(gameTime, components);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_isEquipped || _owner is AITemplate)
            {
                if (_texture != null)
                {
                    spriteBatch.Draw(_texture, _position, _colour);
                }
                for (int i = 1; i <= _spriteComponents.Count; i++)
                {
                    Component currentComponent = _spriteComponents.SearchList(i);
                    currentComponent.Draw(spriteBatch);
                }
            }
        }

        public void Use()
        {
            _hasFired = true;
            switch (_name)
            {
                case "Attack":
                    {
                        if (Math.Abs(_owner.Position.X - _owner.Opponent.Position.X) <= 100)
                        {
                            _owner.Opponent.Health -= _damageAmount;
                            _owner.Points += 10;
                        }
                    }
                    break;
                case "Magic Wand":
                    {
                        _ammunitionCount--;
                        if (_ammunitionCount == 0)
                        {
                            _canBeEquipped = false;
                        }
                        _hasFired = true;
                        AddAmmunition(_spriteComponents);
                    }
                    break;
                case "Cursed Flames":
                    {
                        _ammunitionCount--;
                        if (_ammunitionCount == 0)
                        {
                            _canBeEquipped = false;
                        }
                        _hasFired = true;
                        AddAmmunition(_spriteComponents);
                    }
                    break;
                case "Pancake Shooter":
                    {
                        _ammunitionCount--;
                        if (_ammunitionCount == 0)
                        {
                            _canBeEquipped = false;
                        }
                        _hasFired = true;
                        if (!_multishotActive)
                        {
                            AddAmmunition(_spriteComponents);
                        }
                        if (_multishotActive)
                        {
                            AddAmmunition(_spriteComponents);
                            AddAmmunition(_spriteComponents);
                            AddAmmunition(_spriteComponents);
                        }
                    }
                    break;
                case "Cat Launcher":
                    {
                        _ammunitionCount--;
                        if (_ammunitionCount == 0)
                        {
                            _canBeEquipped = false;
                        }
                        _hasFired = true;
                        if (!_multishotActive)
                        {
                            AddAmmunition(_spriteComponents);
                        }
                        if (_multishotActive)
                        {
                            AddAmmunition(_spriteComponents);
                            AddAmmunition(_spriteComponents);
                            AddAmmunition(_spriteComponents);
                        }
                    }
                    break;
            }
        }

        protected void AddAmmunition(CustomLinkedList components)
        {
            var ammunition = _ammunition.Duplicate() as Ammunition;
            ammunition.Direction = _direction;
            if (_owner.Direction == new Vector2(-1, 0))
            {
                ammunition.Position = new Vector2(_position.X, _position.Y + 130);
            }
            else
            {
                ammunition.Position = new Vector2(_position.X + 150, _position.Y + 130);
            }
            ammunition.Speed = 15;
            ammunition.LifeSpan = 2d;
            ammunition.Weapon = this;

            components.AddNodeToFront(ammunition);
        }

        public void AddSnareAmmunition(CustomLinkedList components, Vector2 lastKnownPosition)
        {
            var snareAmmunition = _snareAmmunition.Duplicate() as SnareAmmunition;
            snareAmmunition.Direction = _direction;
            snareAmmunition.Position = new Vector2(lastKnownPosition.X, 300);
            snareAmmunition.LifeSpan = 3d;
            _snareAmmunition.Weapon = this;

            components.AddNodeToFront(snareAmmunition);
        }
    }
}

