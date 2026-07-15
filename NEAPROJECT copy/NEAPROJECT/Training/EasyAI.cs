using System;
using NEAPROJECT.Backend;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.States;
using NEAPROJECT.Sprites;

namespace NEAPROJECT.Training
{
    public class EasyAI : AITemplate
    {
        private System.Timers.Timer _equipShieldTimer;
        private int _reactionTime;

        private System.Timers.Timer _defendTimer;
        private int _defendTime;

        public EasyAI(Dictionary<string, Animation> animations) : base(animations)
        {
            _health = 100;
            _rangeRequirement = 200;
            _attackingRange = 50;

            _equipShieldTimer = new System.Timers.Timer();
            _equipShieldTimer.Interval = 1000;
            _equipShieldTimer.Elapsed += _equipShieldTimer_Elapsed;

            _defendTimer = new System.Timers.Timer();
            _defendTimer.Interval = 1000;
            _defendTimer.Elapsed += _defendTimer_Elapsed;

            _attackCooldownTimer = new System.Timers.Timer();
            _attackCooldownTimer.Interval = 1000;
            _attackCooldownTimer.Elapsed += _attackCooldownTimer_Elapsed;
        }

        public override void Update(GameTime gameTime, CustomLinkedList components)
        {
            if (_isBeingAttacked && !_shield.IsEquipped)
            {
                // generate a random reaction time between 1 and 3 seconds
                Random random = new Random();
                _reactionTime = random.Next(1, 4);

                // set isBeingAttacked to false otherwise this selection block will be called again (prevents bug)
                _isBeingAttacked = false;
                // begin timer which when reaches 0, the AI will equip its shield
                _equipShieldTimer.Start();
            }

            if (_shield.IsEquipped)
            {
                PlayAnimation("Defend");
                _inAnimationLock = true;
            }
            else
            {
                PlayAnimation("Idle");
            }

            base.Update(gameTime, components);
        }

        protected override void Attack()
        {
            if (!_shield.IsEquipped)
            {
                PlayAnimation("Attack");
                _inAnimationLock = true;

                _currentlySelectedOffense = _primaryOffense;
                _primaryOffense.Use();

                _onAttackCooldown = true;
                _attackCooldown = 2;
                _attackCooldownTimer.Start();
            }
        }

        #region timers

        private void _equipShieldTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _reactionTime--;

            if (_reactionTime == 0)
            {
                // equip AIs shield
                _shield.IsEquipped = true;
                // being timer which when reaches 0, the AI will unequip its shield
                _defendTime = 5;
                _equipShieldTimer.Stop();
                _defendTimer.Start();
            }
        }

        private void _defendTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _defendTime--;

            if (_defendTime == 0)
            {
                // unequip AIs shield
                _shield.IsEquipped = false;
                _defendTimer.Stop();
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
                    if (keyMinusDirection == "Attack")
                    {
                        Random rnd = new Random();
                        int randomNumber = rnd.Next(1, 4);
                        _animator.PlayAnimator(_animations["LeftAttack0" + randomNumber]);
                    }
                    else
                    {
                        _animator.PlayAnimator(_animations["Left" + keyMinusDirection]);
                    }
                }
                else if (_direction.X == 1)
                {
                    if (keyMinusDirection == "Attack")
                    {
                        Random rnd = new Random();
                        int randomNumber = rnd.Next(1, 4);
                        _animator.PlayAnimator(_animations["RightAttack0" + randomNumber]);
                    }
                    else
                    {
                        _animator.PlayAnimator(_animations["Right" + keyMinusDirection]);
                    }
                }
            }
        }

        #endregion animations
    }
}

