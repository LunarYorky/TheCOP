using System.Collections.Generic;
using TheCoP.Architecture.Data_types;
using TheCoP.Architecture.Enums;
using TheCoP.Architecture.Scriptable_Objects;
using UnityEngine;

namespace TheCoP.Scripts__components_
{
    public class BuffHandler : MonoBehaviour, IStatsModifier
    {
        private Statistics _statistics;
        public List<BuffBase> BuffList;

        private void Start()
        {
            _statistics = GetComponent<Statistics>();
        }

        public void ModifyStatistics()
        {
            foreach (var buff in BuffList)
            {
                switch (buff.BuffType)
                {
                    case BuffType.CharacteristicsBuff:
                        AddCharacteristicsBuff(buff as CharacteristicsBuff);
                        break;
                    case BuffType.PhysicalResistanceBuff:
                        AddPhysicalResistanceBuff(buff as PhysicalResistanceBuff);
                        break;
                }
            }
        }

        private void AddCharacteristicsBuff(CharacteristicsBuff characteristicsBuff)
        {
            _statistics.ExtraCharacteristics += characteristicsBuff.ExtraCharacteristics;
        }

        private void AddPhysicalResistanceBuff(PhysicalResistanceBuff physicalResistanceBuff)
        {
            _statistics.ExtraPhysicalResistance += physicalResistanceBuff.ExtraPhysicalResistance;
        }
    }
}