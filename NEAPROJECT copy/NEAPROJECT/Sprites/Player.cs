using NEAPROJECT.Controllers;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Enumerations;
using NEAPROJECT.Backend;
using NEAPROJECT.UI.RoundUI;
using NEAPROJECT.States;
using NEAPROJECT.Training;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NEAPROJECT.Sprites
{
    public class Player : Sprite
    {
        protected Account _account;
        protected int _health;
        protected double _armour;
        protected Vector2 _startingPosition;
        protected Vector2 _previousDirection;
        protected int _points;
        protected bool _isOnMoveCooldown;
        protected bool _isAlive;
        protected bool _hasJumped;
        protected bool _hasAttacked;
        protected Enumerations.Class _class;
        protected Player _opponent;
        // class specific attributes
        protected bool _stealthActive;
        protected bool _bleedActive;
        // timers
        protected System.Timers.Timer _moveCooldownTimer;
        protected int _moveCooldownTime;
        protected bool _moveCooldownTimerStarted;
        protected System.Timers.Timer _respawnTimer;
        protected int _respawnTime;

        // weapons
        protected Weapon _primaryOffense;
        protected Weapon _secondaryOffense;
        protected Weapon _currentlySelectedOffense;

        // shield for melee players
        protected Shield _shield;
        protected bool _shieldInUse;

        // healing items + upgrades
        protected HealingItem _smallHealingItem;
        protected HealingItem _largeHealingItem;
        protected Upgrade _upgrade;

        // class specific attributes
        public bool StealthActive { get => _stealthActive; set => _stealthActive = value; }
        public bool BleedActive { get => _bleedActive; set => _bleedActive = value; }

        public double Armour { get => _armour; set => _armour = value; }

        // healing items + upgrades
        public HealingItem SmallHealingItem { get => _smallHealingItem; set => _smallHealingItem = value; }
        public HealingItem LargeHealingItem { get => _largeHealingItem; set => _largeHealingItem = value; }
        public Upgrade Upgrade { get => _upgrade; set => _upgrade = value; }

        // healthbar + pointsbar
        protected HealthBar _healthBar;
        public PointsBar _pointsBar;

        // hotbar (weapons and healing items)
        protected HotbarSlot _primaryOffenseSlot;
        protected HotbarSlot _secondaryOffenseSlot;
        protected HotbarSlot _upgradeSlot;
        protected HotbarSlot _smallHealingSlot;
        protected HotbarSlot _largeHealingSlot;

        public Account Account { get => _account; set => _account = value; }
        public Vector2 StartingPosition { get => _startingPosition; set => _startingPosition = value; }
        public int Health { get => _health; set => _health = value; }
        public int Points { get => _points; set => _points = value; }
        public bool IsOnMoveCooldown { get => _isOnMoveCooldown; set => _isOnMoveCooldown = value; }
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }
        public bool HasJumped { get => _hasJumped; set => _hasJumped = value; }
        public Enumerations.Class Class { get => _class; set => _class = value; }
        public Player Opponent { get => _opponent; set => _opponent = value; }

        // weapons
        public Weapon PrimaryOffense { get => _primaryOffense; set => _primaryOffense = value; }
        public Weapon SecondaryOffense { get => _secondaryOffense; set => _secondaryOffense = value; }

        // shield for melee players
        public Shield Shield { get => _shield; set => _shield = value; }

        // healthbar + pointsbar
        public HealthBar HealthBar { get => _healthBar; set => _healthBar = value; }
        public PointsBar PointsBar { get => _pointsBar; set => _pointsBar = value; }

        // hotbar (weapons, upgrades, and healing items)
        public HotbarSlot PrimaryOffenseSlot { get => _primaryOffenseSlot; set => _primaryOffenseSlot = value; }
        public HotbarSlot SecondaryOffenseSlot { get => _secondaryOffenseSlot; set => _secondaryOffenseSlot = value; }
        public HotbarSlot UpgradeSlot { get => _upgradeSlot; set => _upgradeSlot = value; }
        public HotbarSlot SmallHealingSlot { get => _smallHealingSlot; set => _smallHealingSlot = value; }
        public HotbarSlot LargeHealingSlot { get => _largeHealingSlot; set => _largeHealingSlot = value; }

        public Player(Dictionary<string, Animation> animations) : base(animations)
        {
            _colour = Microsoft.Xna.Framework.Color.White;
            _health = 200;
            _armour = 0;
            _previousDirection = new Vector2(1, 0);
            _speed = 7;
            _points = 0;
            _isAlive = true;
            _hasJumped = true;
            _hasAttacked = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _healthBar.Draw(spriteBatch);
            _pointsBar.Draw(spriteBatch);

            if (_isAlive)
            {
                for (int i = 1; i <= _spriteComponents.Count; i++)
                {
                    Component currentComponent = _spriteComponents.SearchList(i);
                    currentComponent.Draw(spriteBatch);
                }

                if (_animator != null)
                {
                    _animator.Draw(spriteBatch);
                }

                if (_currentlySelectedOffense != null)
                {
                    _currentlySelectedOffense.Draw(spriteBatch);
                }
            }
        }

        public override void Update(GameTime gameTime, CustomLinkedList components)
        {
            _healthBar.Update(gameTime, components);
            _pointsBar.Update(gameTime, components);
            if (_isAlive)
            {
                // collision detection
                for (int i = 1; i <= components.Count; i++)
                {
                    Component currentComponent = components.SearchList(i);
                    if (currentComponent is Sprite)
                    {
                        Sprite currentSprite = (Sprite)components.SearchList(i);
                        if (_requiresCollisionDetection)
                        {
                            if (currentSprite == this)
                            {
                                continue;
                            }
                            if ((_velocity.X > 0 && IsTouchingLeft(currentSprite)) || (_velocity.X < 0 && IsTouchingRight(currentSprite)))
                            {
                                _velocity.X = 0;
                            }
                            //if ((_velocity.Y > 0 && IsTouchingTop(currentSprite)) || (_velocity.Y < 0 && IsTouchingBottom(currentSprite)))
                            //{
                            //    _velocity.Y = 0;
                            //}
                        }
                    }
                }

                if (_isOnMoveCooldown && !_moveCooldownTimerStarted)
                {
                    _moveCooldownTimerStarted = true;
                    BeginMoveCooldown();
                }
                else if (!_isOnMoveCooldown)
                {
                    Move();
                }

                if (_animator != null)
                {
                    _animator.Update(gameTime);
                    _animator.Position = _position;
                }

                if (_currentlySelectedOffense != null)
                {
                    _currentlySelectedOffense.Update(gameTime, components);
                }

                if (_stealthActive)
                {
                    _speed = 14;
                    PlayAnimation("Stealth");
                    _inAnimationLock = true;
                }

                if (_bleedActive)
                {
                    double timer = 0;
                    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                    if (timer > 1)
                    {
                        timer = 0f;
                        _health -= 3;
                    }
                }

                // key detection
                KeyboardState previousKey, currentKey = Keyboard.GetState();
                previousKey = currentKey;
                currentKey = Keyboard.GetState();

                // allows the player to attack opponent, second flag prevents player from holding attack
                if (Keyboard.GetState().IsKeyDown(_input.Attack) && !_currentlySelectedOffense.HasFired)
                {
                    if (_currentlySelectedOffense == null)
                    {
                        return;
                    }
                    if (_currentlySelectedOffense != null)
                    {
                        PlayAnimation("Attack");
                        _inAnimationLock = true;
                        _currentlySelectedOffense.Use();
                    }
                }
                if (!Keyboard.GetState().IsKeyDown(_input.Attack))
                {
                    if (_currentlySelectedOffense != null)
                    {
                        _currentlySelectedOffense.HasFired = false;
                    }
                }
                // equip primary offense
                if (Keyboard.GetState().IsKeyDown(_input.EquipPrimaryOffense))
                {
                    if (_currentlySelectedOffense != null)
                    {
                        _currentlySelectedOffense.IsEquipped = false;
                    }
                    if (_primaryOffense.CanBeEquipped)
                    {
                        _primaryOffense.IsEquipped = true;
                        _currentlySelectedOffense = _primaryOffense;
                    }
                }
                // equip secondary offense
                if (Keyboard.GetState().IsKeyDown(_input.EquipSecondaryOffense))
                {
                    if (_currentlySelectedOffense != null)
                    {
                        _currentlySelectedOffense.IsEquipped = false;
                    }

                    // for Mage and Range players
                    if (_class == Class.Mage || _class == Class.Ranger)
                    {
                        if (_secondaryOffense.CanBeEquipped)
                        {
                            _secondaryOffense.IsEquipped = true;
                            _currentlySelectedOffense = _secondaryOffense;
                        }
                    }
                    // for Melee players
                    else if (_shield.CanBeEquipped)
                    {
                        _shield.IsEquipped = true;
                        PlayAnimation("Defend");
                    }
                }
                // unequip shield (for melee players)
                if (_shield != null && !(Keyboard.GetState().IsKeyDown(_input.EquipSecondaryOffense)))
                {
                    _shield.IsEquipped = false;
                }

                // use small healing
                if (Keyboard.GetState().IsKeyDown(_input.UseSmallHealing) && _smallHealingItem.Count > 0 && !_smallHealingItem.IsOnCooldown)
                {
                    _smallHealingItem.Count--;
                    _smallHealingItem.Use();
                }
                // use large healing item
                if (Keyboard.GetState().IsKeyDown(_input.UseLargeHealing) && _largeHealingItem.Count > 0 && !_largeHealingItem.IsOnCooldown)
                {
                    _largeHealingItem.Count--;
                    _largeHealingItem.Use();
                }
                // use upgrade
                if (Keyboard.GetState().IsKeyDown(_input.UseUpgrade) && _upgrade != null && !_upgrade.HasBeenUsed)
                {
                    _upgrade.Use();
                }
            }

            base.Update(gameTime, _spriteComponents);
        }

        private void Move()
        {
            _position += _velocity;

            if (_primaryOffense != null)
            {
                _primaryOffense.Position = _primaryOffense.Owner.Position;
            }

            if (_secondaryOffense != null)
            {
                _secondaryOffense.Position = _secondaryOffense.Owner.Position;
            }

            if (Input == null)
            {
                return;
            }
            else
            {
                // allows the player to move left
                if (Keyboard.GetState().IsKeyDown(_input.Left))
                {
                    _animator.PlayAnimator(_animations["LeftRun"]);
                    _velocity.X = _speed * -1;
                    _direction = new Vector2(-1, 0);
                }
                // allows the player to move right
                else if (Keyboard.GetState().IsKeyDown(_input.Right))
                {
                    _animator.PlayAnimator(_animations["RightRun"]);
                    _velocity.X = _speed;
                    _direction = new Vector2(1, 0);
                }
                // the player does not move if left or right input key is not being pressed
                else
                { 
                    PlayAnimation("Idle");
                    _velocity.X = 0f;
                }
                // allows the player to jump
                if (Keyboard.GetState().IsKeyDown(_input.Jump) && !_hasJumped)
                {
                    _position.Y -= 20f;
                    _velocity.Y = -10f;
                    _hasJumped = true;
                }
                if (_hasJumped)
                {
                    int i = 5;
                    _velocity.Y += 0.15f * i;
                }
                // code for ground level physics
                int height;
                if (_texture == null)
                {
                    height = _animations["LeftIdle"].Height;
                }
                else
                {
                    height = _texture.Height;
                }
                if (_position.Y + height >= 350)
                {
                    // resets jump status and prevents player from falling past ground level
                    _hasJumped = false;
                    _velocity.Y = 0f;
                }
                _previousDirection = _direction;
            }
        }

        public void GrantSiphon()
        {
            _points += 250;
            if (_health + 50 >= 200)
            {
                // prevents player from gaining overhealth
                _health = 200;
            }
            else
            {
                _health += 50;
            }
        }

        #region timers

        private void BeginMoveCooldown()
        {
            _moveCooldownTime = 5;
            _moveCooldownTimer = new System.Timers.Timer();
            _moveCooldownTimer.Interval = 1000;
            _moveCooldownTimer.Elapsed += _moveCooldownTimer_Elapsed;
            _moveCooldownTimer.Start();
        }

        private void _moveCooldownTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _moveCooldownTime--;
            if (_moveCooldownTime == 0)
            {
                _isOnMoveCooldown = false;
                _moveCooldownTimerStarted = false;
                _moveCooldownTimer.Stop();
            }
        }

        #endregion timers

        #region animations

        protected virtual void PlayAnimation(string keyMinusDirection)
        {
            if (!_inAnimationLock)
            {
                string animationDirection = "";

                if (_previousDirection.X == -1)
                {
                    animationDirection = "Left";
                }
                else
                {
                    animationDirection = "Right";
                }


                if (keyMinusDirection == "Attack")
                {
                    if (_class == Class.Melee)
                    {
                        Random rnd = new Random();
                        int randomNumber = rnd.Next(1, 4);
                        _animator.PlayAnimator(_animations[animationDirection + "Attack0" + randomNumber]);
                    }
                    else
                    {
                        _animator.PlayAnimator(_animations[animationDirection + "Attack"]);
                    }
                }
                else
                {
                    _animator.PlayAnimator(_animations[animationDirection + keyMinusDirection]);
                }
            }
        }

        #endregion animations
    }
}
