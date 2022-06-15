using TheCoP.Architecture.Data_types;
using TheCoP.Architecture.Enums;
using UnityEngine;

namespace TheCoP.Architecture.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New CharacteristicsBuff",
        menuName = "ScriptableObjects/Buffs/PhysicalResistance Buff")]
    public class PhysicalResistanceBuff : BuffBase
    {
        public override BuffType BuffType => BuffType.PhysicalResistanceBuff;

        public PhysicalResistance ExtraPhysicalResistance;
    }
}