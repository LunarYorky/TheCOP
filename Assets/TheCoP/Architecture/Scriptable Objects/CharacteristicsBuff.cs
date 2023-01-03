using TheCoP.Architecture.Abstract;
using TheCoP.Architecture.Data_types;
using TheCoP.Architecture.Enums;
using UnityEngine;

namespace TheCoP.Architecture.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New CharacteristicsBuff", menuName = "ScriptableObjects/Buffs/Characteristics Buff")]
    public class CharacteristicsBuff : BuffBase
    {
        public override BuffType BuffType => BuffType.CharacteristicsBuff;

        public Characteristics ExtraCharacteristics;
    }
}