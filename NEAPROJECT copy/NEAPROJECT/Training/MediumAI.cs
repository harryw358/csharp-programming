using System;
using NEAPROJECT.Backend;
using NEAPROJECT.CustomLinkedLists;
using NEAPROJECT.States;
using NEAPROJECT.Sprites;

namespace NEAPROJECT.Training
{
    public class MediumAI : AITemplate
    {
        public MediumAI(Dictionary<string, Animation> animations) : base(animations)
        {
            _health = 150;
            _rangeRequirement = 500;
            _attackingRange = 400;
        }

        public override void Update(GameTime gameTime, CustomLinkedList components)
        { 
            if (_primaryOffense.IsEquipped)
            {
                _primaryOffense.Update(gameTime, components);
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

