using TheCoP.Architecture.Data_types;
using TheCoP.Scripts__components_;

namespace TheCoP.Architecture
{
    public static class StatisticsUtils
    {
        public static void DealingDamage(Statistics statistics, in PhysicalDamage damage)
        {
            statistics.CurrentHealth -= lol(damage.Sleshing, statistics.PhysicalResistance.Sleshing);
            statistics.CurrentHealth -= lol(damage.Piercing, statistics.PhysicalResistance.Piercing);
            statistics.CurrentHealth -= lol(damage.Crushing, statistics.PhysicalResistance.Crushing);
        }

        private static int lol(in int damage,in int armor)
        {
            if (damage > armor)
                return damage;
            return damage*damage/armor;
        }
    }
}
