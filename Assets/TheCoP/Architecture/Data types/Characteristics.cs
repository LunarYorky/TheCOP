using System;
using TheCoP.Architecture.Enums;
using TheCoP.Scripts__components_;
using UnityEngine;

namespace TheCoP.Architecture.Data_types
{
    [Serializable]
    public struct Characteristics
    {
        //Physical
        public byte Strength;
        public byte Dexterity;
        public byte Endurance;
        public byte Constitution;

        //Mental
        public byte Intelligence;
        public byte Faith;
        public byte Perception;
        public byte Fortune;

        public Characteristics(byte strength = default, byte dexterity = default, byte endurance = default,
            byte constitution = default, byte intelligence = default, byte faith = default, byte perception = default,
            byte fortune = default)
        {
            Strength = strength;
            Dexterity = dexterity;
            Endurance = endurance;
            Constitution = constitution;
            Intelligence = intelligence;
            Faith = faith;
            Perception = perception;
            Fortune = fortune;
        }

        public static Characteristics operator +(Characteristics x, Characteristics y)
        {
            return new Characteristics((byte)(x.Strength + y.Strength), (byte)(x.Dexterity + y.Dexterity),
                (byte)(x.Endurance + y.Endurance), (byte)(x.Constitution + y.Constitution),
                (byte)(x.Intelligence + y.Intelligence), (byte)(x.Faith + y.Faith), (byte)(x.Perception + y.Perception),
                (byte)(x.Fortune + y.Fortune));
        }

        public static Characteristics operator -(Characteristics x, Characteristics y)
        {
            return new Characteristics((byte)(x.Strength - y.Strength), (byte)(x.Dexterity - y.Dexterity),
                (byte)(x.Endurance - y.Endurance), (byte)(x.Constitution - y.Constitution),
                (byte)(x.Intelligence - y.Intelligence), (byte)(x.Faith - y.Faith), (byte)(x.Perception - y.Perception),
                (byte)(x.Fortune - y.Fortune));
        }
    }
}