using System;
using NEAPROJECT.Sprites;
using NEAPROJECT.Backend;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.States;
using NEAPROJECT.Controllers;
using Microsoft.Xna.Framework.Graphics;

namespace NEAPROJECT.Training
{
    public abstract class AITemplate : Player
    {
        private bool _inUpdateLoop;
        private bool _inRangeOfOpponent;
        protected int _rangeRequirement;
        protected int _attackingRange;
        private bool _isMoving;
        protected bool _isBeingAttacked;
        protected bool _isAttacking;
        protected bool _onAttackCooldown;

        protected System.Timers.Timer _attackCooldownTimer;
        protected int _attackCooldown;

        public bool IsBeingAttacked { get => _isBeingAttacked; set => _isBeingAttacked = value; }

        public AITemplate(Dictionary<string, Animation> animations) : base(animations)
        {
            _inUpdateLoop = true;

            _attackCooldownTimer = new System.Timers.Timer();
            _attackCooldownTimer.Interval = 1000;
            _attackCooldownTimer.Elapsed += _attackCooldownTimer_Elapsed;

            _animations = animations;
            _animator = new AnimationController(_animations.First().Value, this);
            _colour = Microsoft.Xna.Framework.Color.White;
            _speed = 3;
            _points = 0;
            _isAlive = true;
            _hasJumped = true;
            _isMoving = false;

            _startingPosition = new Vector2(400, 100);
        }

        protected abstract void Attack();

        public void Jump()
        {
            _position.Y -= 20f;
            _velocity.Y = -10f;
            _hasJumped = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _primaryOffense.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime, CustomLinkedList components)
        {
            for (int i = 1; i <= _spriteComponents.Count; i++)
            {
                Component currentComponent = _spriteComponents.SearchList(i);
                currentComponent.Update(gameTime, components);
            }

            // logic for moving towards the real player

            // if target player is not within range of player, then move towards them
            double distanceBetweenPlayerAndAI = Math.Abs(_position.X - _opponent.Position.X);

            if (distanceBetweenPlayerAndAI > _rangeRequirement)
            {
                _inRangeOfOpponent = false;
                if (_opponent.Position.X < _position.X)
                {
                    Move("left");
                    _direction = new Vector2(-1, 0);
                }
                if (_opponent.Position.X > _position.X)
                {
                    Move("right");
                    _direction = new Vector2(1, 0);
                }
            }
            else
            {
                _inRangeOfOpponent = true;
                _velocity.X = 0;
                PlayAnimation("Idle");
            }

            // end of logic for moving towards the real player

            // logic for attacking the real player

            if (distanceBetweenPlayerAndAI <= _attackingRange && !_isAttacking)
            {
                if (!_onAttackCooldown)
                {
                    if (_opponent.IsAlive)
                    {
                        _isAttacking = true;
                        Attack();
                        _isAttacking = false;
                    }
                }
            }

            _healthBar.Update(gameTime, components);
            _pointsBar.Update(gameTime, components);

            if (_animator != null)
            {
                _animator.Update(gameTime);
                _animator.Position = _position;
            }

            if (_currentlySelectedOffense != null)
            {
                _currentlySelectedOffense.Update(gameTime, components);
            }
        }

        private void Move(string direction)
        {
            switch (direction)
            {
                case "left":
                    {
                        _position += new Vector2(-1, 0) * _speed;
                    }
                    break;
                case "right":
                    {
                        _position += new Vector2(1, 0) * _speed;
                    }
                    break;
            }

            PlayAnimation("Run");
            _inAnimationLock = true;
            _isMoving = true;
        }

        #region timers

        protected void _attackCooldownTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _attackCooldown--;

            if (_attackCooldown == 0)
            {
                _onAttackCooldown = false;
            }
        }

        #endregion timers

        #region animations

        protected override void PlayAnimation(string keyMinusDirection)
        {
            if (!_inAnimationLock)
            {
                if (_direction.X == -1)
                {
                    _animator.PlayAnimator(_animations["Left" + keyMinusDirection]);
                }
                else if (_direction.X == 1)
                {
                    _animator.PlayAnimator(_animations["Right" + keyMinusDirection]);
                }
            }
        }

        #endregion animations
    }
}

