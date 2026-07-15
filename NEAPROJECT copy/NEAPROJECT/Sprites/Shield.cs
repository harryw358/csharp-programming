using System;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Training;

namespace NEAPROJECT.Sprites
{
    public class Shield : Sprite
    {
        private Player _owner;
        private bool _canBeEquipped;
        private bool _isEquipped;
        private int _health;
        private System.Timers.Timer _cooldownTimer;
        private int _cooldownTime;
        private bool _cooldownTimerStarted;

        public Player Owner { get => _owner; }
        public int Health { get => _health; set => _health = value; }
        public bool CanBeEquipped { get => _canBeEquipped; }
        public bool IsEquipped { get => _isEquipped; set => _isEquipped = value; }

        public Shield(Texture2D texture, Player owner) : base(texture)
        {
            _owner = owner;
            _canBeEquipped = true;
            _health = 100;
            _cooldownTimer = new System.Timers.Timer();
            _cooldownTimer.Interval = 1000;
            _cooldownTimer.Elapsed += _cooldownTimer_Elapsed;
            _cooldownTime = 8;

            _requiresCollisionDetection = true;
        }

        private void _cooldownTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _cooldownTime--;

            if (_cooldownTime == 0)
            {
                _canBeEquipped = true;
                _isEquipped = false;
                _cooldownTimerStarted = false;
                _health = 100;
                _cooldownTimer.Stop();
            }
        }

        public override void Update(GameTime gameTime, CustomLinkedList components)
        {
            if (_health <= 0)
            {
                _canBeEquipped = false;
                _isEquipped = false;
                if (!_cooldownTimerStarted)
                {
                    _cooldownTime = 8;
                    _cooldownTimerStarted = true;
                    _cooldownTimer.Start();
                }
            }
        }
    }
}

