using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEAPROJECT
{
    public class Input
    {
        private Keys _left;
        private Keys _right;
        private Keys _jump;
        private Keys _attack;
        private Keys _equipPrimaryOffense;
        private Keys _equipSecondaryOffense;
        private Keys _useUpgrade;
        private Keys _equipShield;
        private Keys _useSmallHealing;
        private Keys _useLargeHealing;

        public Keys Left { get => _left; set => _left = value; }
        public Keys Right { get => _right; set => _right = value; }
        public Keys Jump { get => _jump; set => _jump = value; }
        public Keys Attack { get => _attack; set => _attack = value; }
        public Keys EquipPrimaryOffense { get => _equipPrimaryOffense; set => _equipPrimaryOffense = value; }
        public Keys EquipSecondaryOffense { get => _equipSecondaryOffense; set => _equipSecondaryOffense = value; }
        public Keys UseUpgrade { get => _useUpgrade; set => _useUpgrade = value; }
        public Keys EquipShield { get => _equipShield; set => _equipShield = value; }
        public Keys UseSmallHealing { get => _useSmallHealing; set => _useSmallHealing = value; }
        public Keys UseLargeHealing { get => _useLargeHealing; set => _useLargeHealing = value; }
    }
}