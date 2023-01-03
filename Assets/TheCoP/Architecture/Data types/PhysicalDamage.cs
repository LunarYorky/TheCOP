using System;

namespace TheCoP.Architecture.Data_types
{
    [Serializable]
    public struct PhysicalDamage
    {
        public int Sleshing;
        public int Piercing;
        public int Crushing;

        public PhysicalDamage(int sleshing, int piercing, int crushing)
        {
            Sleshing = sleshing;
            Piercing = piercing;
            Crushing = crushing;
        }

        public static PhysicalDamage operator +(PhysicalDamage x, PhysicalDamage y)
        {
            return new PhysicalDamage(x.Sleshing + y.Sleshing, x.Piercing + y.Piercing, x.Crushing + y.Crushing);
        }
    }
}