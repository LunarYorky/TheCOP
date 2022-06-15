using System;
using TheCoP.Scripts__components_;

namespace TheCoP.Architecture.Data_types
{
    [Serializable]
    public struct PhysicalResistance
    {
        public int Sleshing;
        public int Piercing;
        public int Crushing;

        public PhysicalResistance(int sleshing, int piercing, int crushing)
        {
            Sleshing = sleshing;
            Piercing = piercing;
            Crushing = crushing;
        }

        public static PhysicalResistance operator +(PhysicalResistance x, PhysicalResistance y)
        {
            return new PhysicalResistance(x.Sleshing + y.Sleshing, x.Piercing + y.Piercing, x.Crushing + y.Crushing);
        }
    }
}