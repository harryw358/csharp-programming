using WarriorWars.Enum;

namespace WarriorWars.Equipment
{
    class Weapon
    {
        private const int GOOD_GUY_DAMAGE = 20;
        private const int BAD_GUY_DAMAGE = 20;


        private int damage;

        public int Damage
        {
            get
            {
                return damage;
            }
        }

        public Weapon(Faction faction)
        {
            switch (faction)
            {
                case Faction.Goodguy:
                    damage = GOOD_GUY_DAMAGE;
                    break;
                case Faction.Badguy:
                    damage = GOOD_GUY_DAMAGE;
                    break;
                default:
                    break;
            }
        }
    }
}
