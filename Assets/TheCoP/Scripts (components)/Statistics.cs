using System;
using System.Collections;
using TheCoP.Architecture.Data_types;
using TheCoP.Architecture.Enums;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TheCoP.Scripts__components_
{
    public class Statistics : MonoBehaviour
    {
        public float testStaminaRegen;
        private int _id;
        private int _status;

        [SerializeField] private Characteristics _basicCharacteristics;

        public Characteristics BasicCharacteristics
        {
            get => _basicCharacteristics;
            set
            {
                _basicCharacteristics = value;
                CalculateStats();
            }
        }

        // Calculated stats
        private Characteristics _generalCharacteristics;

        private float _maxHealth;
        private float _MaxStamina;
        private float _staminaRegen;

        public PhysicalResistance PhysicalResistance { get; private set; }

        // resources
        [Header("Resources")] [SerializeField] private float _currentHealth;
        [SerializeField] private float _currentStamina;

        //Extras
        private Characteristics _extraCharacteristics;

        private PhysicalResistance _extraPhysicalResistance;

        public float MaxStamina
        {
            get => _MaxStamina;
            private set => _MaxStamina = value;
        }

        public float MaxHealth
        {
            get => _maxHealth;
            private set => _maxHealth = value;
        }

        public float StaminaRegen
        {
            get => _staminaRegen;
            private set => _staminaRegen = value;
        }

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public int Status
        {
            get { return _status; }
            private set { _status = value; }
        }

        public int ItemsCount
        {
            get
            {
                var itemsStorage = GetComponent<ItemsStorage>();
                return itemsStorage == null ? 0 : itemsStorage.ItemsCount;
            }
        }

        public float CurrentStamina
        {
            get => _currentStamina;
            set
            {
                if (value > 0)
                    _currentStamina = value > _MaxStamina ? _MaxStamina : value;
                else
                    _currentStamina = 0f;
            }
        }

        public float CurrentHealth
        {
            get { return _currentHealth; }
            set
            {
                if (value > 0f)
                    _currentHealth = value > MaxHealth ? MaxHealth : value;

                else
                    _currentHealth = 0f;
            }
        }

        public Characteristics ExtraCharacteristics
        {
            get => _extraCharacteristics;
            set => _extraCharacteristics = value;
        }

        public PhysicalResistance ExtraPhysicalResistance
        {
            get => _extraPhysicalResistance;
            set => _extraPhysicalResistance = value;
        }

        public Characteristics GeneralCharacteristics
        {
            get { return _generalCharacteristics; }
        }
        
        public byte GetStat(CharacteristicsType type)
        {
            return type switch
            {
                CharacteristicsType.Strength => _basicCharacteristics.Strength,
                CharacteristicsType.Dexterity => _basicCharacteristics.Dexterity,
                CharacteristicsType.Endurance => _basicCharacteristics.Endurance,
                CharacteristicsType.Constitution => _basicCharacteristics.Constitution,
                CharacteristicsType.Intelligence => _basicCharacteristics.Intelligence,
                CharacteristicsType.Faith => _basicCharacteristics.Faith,
                CharacteristicsType.Perception => _basicCharacteristics.Perception,
                CharacteristicsType.Fortune => _basicCharacteristics.Fortune,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public float GetStat(StatType statType)
        {
            return statType switch
            {
                StatType.MaxHealth => MaxHealth,
                StatType.CurrentHealth => CurrentHealth,
                StatType.MaxStamina => MaxStamina,
                StatType.CurrentStamina => CurrentStamina,
                StatType.staminaRegen => StaminaRegen,
                _ => throw new ArgumentOutOfRangeException(nameof(statType), statType, null)
            };
        }

        // LoGgika------------------------------------------------------------------------------------

        private void Start()
        {
            CalculateStats();
            StartCoroutine(StaminaRegenerator());
        }

        private IEnumerator StaminaRegenerator()
        {
            while (true)
            {
                if (CurrentStamina < MaxStamina)
                    CurrentStamina += 1;

                yield return new WaitForSeconds(_staminaRegen);
            }
        }

        public void CalculateStats()
        {
            _extraCharacteristics = new();
            _extraPhysicalResistance = new();

            ExecuteEvents.Execute<IStatsModifier>(gameObject, null, (x, y) => x.ModifyStatistics());

            _generalCharacteristics = _basicCharacteristics + _extraCharacteristics;

            var temp = 10 * GeneralCharacteristics.Constitution;
            _maxHealth = 100 + temp;
            _MaxStamina = 100 + 10 * GeneralCharacteristics.Endurance;
            _staminaRegen = testStaminaRegen;

            PhysicalResistance = new PhysicalResistance(50 + temp, 50 + temp, 50 + temp);
        }


        public bool UseUpStamina(int value)
        {
            if (_currentStamina == 0)
                return false;
            CurrentStamina -= value;
            return true;
        }

        public void Increment(CharacteristicsType type)
        {
            if (type == CharacteristicsType.Strength)
                _basicCharacteristics.Strength++;
            else if (type == CharacteristicsType.Dexterity)
                _basicCharacteristics.Dexterity++;
            else if (type == CharacteristicsType.Endurance)
                _basicCharacteristics.Endurance++;
            else if (type == CharacteristicsType.Constitution)
                _basicCharacteristics.Constitution++;
            else if (type == CharacteristicsType.Intelligence)
                _basicCharacteristics.Intelligence++;
            else if (type == CharacteristicsType.Faith)
                _basicCharacteristics.Faith++;
            else if (type == CharacteristicsType.Perception)
                _basicCharacteristics.Perception++;
            else if (type == CharacteristicsType.Fortune) 
                _basicCharacteristics.Fortune++;
            
            CalculateStats();
        }

        public void Decrement(CharacteristicsType type)
        {
            if (type == CharacteristicsType.Strength)
                _basicCharacteristics.Strength--;
            else if (type == CharacteristicsType.Dexterity)
                _basicCharacteristics.Dexterity--;
            else if (type == CharacteristicsType.Endurance)
                _basicCharacteristics.Endurance--;
            else if (type == CharacteristicsType.Constitution)
                _basicCharacteristics.Constitution--;
            else if (type == CharacteristicsType.Intelligence)
                _basicCharacteristics.Intelligence--;
            else if (type == CharacteristicsType.Faith)
                _basicCharacteristics.Faith--;
            else if (type == CharacteristicsType.Perception)
                _basicCharacteristics.Perception--;
            else if (type == CharacteristicsType.Fortune)
                _basicCharacteristics.Fortune--;
            
            CalculateStats();
        }
    }
}