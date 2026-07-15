using System;
using NEAPROJECT.Sprites;

namespace NEAPROJECT.Sprites
{
    public class Upgrade : Sprite
    {
        private int _cost;
        private Player _owner;
        private string _type;
        private int _duration;
        private bool _hasBeenUsed;
        private System.Timers.Timer _timer;
        private int _tick;

        public bool HasBeenUsed { get => _hasBeenUsed; }

        public Upgrade(Texture2D texture, Player owner, string name, int duration) : base(texture)
        {
            _texture = texture;
            _owner = owner;
            _name = name;
            _duration = duration;

            _timer = new System.Timers.Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
        }

        public void Use()
        {
            switch (_name)
            {
                case "charge":
                    {

                    }
                    break;
                case "lockdown":
                    {
                        _owner.Health += 50;
                        _owner.Armour += 50;
                    }
                    break;
                case "enchantment":
                    {
                        _owner.PrimaryOffense.DamageAmount = 20;
                    }
                    break;
                case "stealth":
                    {
                        _owner.StealthActive = true;
                    }
                    break;
                case "multishot":
                    {
                        _owner.PrimaryOffense.MultishotActive = true;
                    }
                    break;
                case "bleed":
                    {
                        _owner.PrimaryOffense.Ammunition.CanBleed = true;
                    }
                    break;
            }

            _hasBeenUsed = true;
            _tick = _duration;
            _timer.Start();
        }

        private void Stop()
        {
            switch (_name)
            {
                case "lockdown":
                    {
                        _owner.Armour = 0;
                    }
                    break;
                case "enchantment":
                    {
                        _owner.PrimaryOffense.DamageAmount = 10;
                    }
                    break;
                case "stealth":
                    {
                        _owner.StealthActive = false;
                        _owner.Speed = 7;
                    }
                    break;
                case "multishot":
                    {
                        _owner.PrimaryOffense.MultishotActive = false;
                    }
                    break;
                case "bleed":
                    {
                        _owner.Opponent.BleedActive = false;
                        _owner.PrimaryOffense.Ammunition.CanBleed = false;
                        _owner.SecondaryOffense.Ammunition.CanBleed = false;
                    }
                    break;
            }
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _tick--;

            if (_tick == 0)
            {
                Stop();
                _timer.Stop();
            }
        }
    }
}

