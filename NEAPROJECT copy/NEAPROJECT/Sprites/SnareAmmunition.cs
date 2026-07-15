    using System;
using Microsoft.Xna.Framework;
using NEAPROJECT.CustomLinkedLists;

namespace NEAPROJECT.Sprites
{
    public class SnareAmmunition : Ammunition
    {
        private int _snareDamage;
        private double _snareDuration;
        private double _snareDistance;
        private System.Timers.Timer _snareTimer;
        private int _tick;
        private bool _snareTimerStarted;

        public SnareAmmunition(Dictionary<string, Animation> animations) : base(animations)
        {
            _colour = Color.DeepPink;

            // 5 damage per second, for 3 seconds, meaning a max of 15 damage can be dealt
            _snareDamage = 5;
            _snareDuration = 3;
            _snareDistance = 50;

            _snareTimer = new System.Timers.Timer();
            _snareTimer.Interval = 1000;
            _snareTimer.Elapsed += _snareTimer_Elapsed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!_isRemoved)
            {
                _animator.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime, CustomLinkedList components)
        {
            _animator.Update(gameTime);

            double elapsedGameTime = gameTime.ElapsedGameTime.TotalSeconds;
            _timer += elapsedGameTime;

            if (_timer >= _lifeSpan)
            {
                _isRemoved = true;
            }
        }

        public void StartSnareTimer()
        {
            // this timer is to make sure the snare effect only deals damage per second. As the update method
            // is called 60 times per second, no wait timer would mean the snare effect does 60 x 5 = 300 damage
            // per second. A 1 second timer is called every time the snare effect does damage to the player to effectively
            // place it on a "cooldown

            _animator.PlayAnimator(_weapon.SnareAmmunition.Animations["Fire"]);

            if (!_snareTimerStarted)
            {
                _tick = 0;
                _snareTimer.Start();
            }
        }

        private bool IsInRange(Player opponent)
        {
            if (Math.Abs(_position.X - opponent.Position.X) <= _snareDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region timers

        private void _snareTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _tick++;
            if (_tick == _snareDuration)
            {
                _snareTimer.Stop();
                _snareTimerStarted = false;
                _tick = 0;
            }
            else if (IsInRange(_weapon.Owner.Opponent))
            {
                _weapon.Owner.Opponent.Health -= _snareDamage;
            }
        }

        #endregion timers
    }
}

