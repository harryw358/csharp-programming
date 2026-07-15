using System;
using System.Timers;
using NEAPROJECT.Sprites;
using NEAPROJECT.States;

namespace NEAPROJECT.Sprites
{
    public class HealingItem : Sprite
    {
        private int _healingAmount;
        private int _count;
        private Player _owner;
        private bool _isOnCooldown;
        private System.Timers.Timer _timer;
        private int _tick;

        public int Count { get => _count; set => _count = value; }
        public bool IsOnCooldown { get => _isOnCooldown; }

        public HealingItem(Texture2D texture, string type, int count, Player owner) : base(texture)
        {
            switch (type)
            {
                case "small":
                    _healingAmount = 75;
                    break;
                case "large":
                    _healingAmount = 150;
                    break;
            }
            _owner = owner;
            _isOnCooldown = false;

            _count = count;
        }

        public void Use()
        {
            // increase players health by healing amount (75 or 150)
            if (_owner.Health + _healingAmount > 200)
            {
                // this if statement prevents the player from gaining overhealth, for example,
                // if the players health was 160HP and they used a small healing item (75HP)
                // instead of their health going to 235HP, it stays capped at 200HP
                _owner.Health += 200 - _owner.Health;
            }
            else
            {
                _owner.Health += _healingAmount;
            }

            if (_healingAmount == 150)
            {
                _owner.IsOnMoveCooldown = true;
            }

            BeginCooldown();
        }

        private void BeginCooldown()
        {
            _isOnCooldown = true;

            _tick = 5; // always 25 because only small healing items will have a cooldown since the player can only use 1 large healing amount during the round
            _timer = new System.Timers.Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }


        #region timers

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _tick--;
            if (_tick == 0)
            {
                _isOnCooldown = false;
                _timer.Stop();
            }
        }

        #endregion timers
    }
}

