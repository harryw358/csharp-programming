using System;
using NEAPROJECT.Backend;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.Sprites;
using NEAPROJECT.States;

namespace NEAPROJECT.Training
{
    public class HardAI : AITemplate
    {
        public HardAI(Dictionary<string, Animation> animations) : base(animations)
        {
            _health = 200;
            _rangeRequirement = 500;
            _attackingRange = 400;

            _armour = 50;
        }

        public override void Update(GameTime gameTime, CustomLinkedList components)
        {
            if (_primaryOffense.IsEquipped)
            {
                _primaryOffense.Update(gameTime, components);
            }

            if (_position.X > _opponent.Position.X)
            {
                _direction = new Vector2(-1, 0);
            }
            else if (_position.X < _opponent.Position.X)
            {
                _direction = new Vector2(1, 0);
            }

            if (_isAlive)
            {
                base.Update(gameTime, components);
            }
        }

        protected override void Attack()
        {
            if (_velocity.X == 0)
            {
                PlayAnimation("Attack");
                _inAnimationLock = true;

                _currentlySelectedOffense = _primaryOffense;
                _primaryOffense.IsEquipped = true;
                _primaryOffense.Use();
                PlayAnimation("Idle");
                _inAnimationLock = true;

                _onAttackCooldown = true;
                _attackCooldown = 2;
                _attackCooldownTimer.Start();
            }
        }
    }
}

