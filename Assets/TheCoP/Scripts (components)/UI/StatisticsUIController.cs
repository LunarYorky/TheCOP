using System;
using TheCoP.Architecture.Enums;
using TheCoP.UI.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace TheCoP.Scripts__components_.UI
{
    public class StatisticsUIController : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset statElementAsset;
        [SerializeField] private GameObject source;

        private Statistics _statistics;
        private VisualElement _characteristicsList;
        private VisualElement _statsList;
        public Action Refresh;

        public void Browse(UIDocument doc)
        {
            Refresh = null;
            var root = doc.rootVisualElement;
            _characteristicsList = root.Q<VisualElement>("CharacteristicsList");
            _statsList = root.Q<VisualElement>("StatisticsList");

            _statistics = source.GetComponent<Statistics>();

            FillStatsList();
            
            this.enabled = true;
        }

        private void Update()
        {
            Refresh?.Invoke();
        }

        private void FillStatsList()
        {
            _characteristicsList.Add(CreateElement(CharacteristicsType.Strength, "Strength"));
            _characteristicsList.Add(CreateElement(CharacteristicsType.Dexterity, "Dexterity"));
            _characteristicsList.Add(CreateElement(CharacteristicsType.Endurance, "Endurance"));
            _characteristicsList.Add(CreateElement(CharacteristicsType.Constitution, "Constitution"));
            _characteristicsList.Add(CreateElement(CharacteristicsType.Intelligence, "Intelligence"));
            _characteristicsList.Add(CreateElement(CharacteristicsType.Faith, "Faith"));
            _characteristicsList.Add(CreateElement(CharacteristicsType.Perception, "Perception"));
            _characteristicsList.Add(CreateElement(CharacteristicsType.Fortune, "Fortune"));

            _statsList.Add(CreateElement(StatType.CurrentHealth,StatType.MaxHealth, "Max Health"));
            _statsList.Add(CreateElement(StatType.CurrentStamina,StatType.MaxStamina, "Max Stamina"));
            _statsList.Add(CreateElement(StatType.staminaRegen, "Stamina Regen"));
        }

        private VisualElement CreateElement(StatType st, string statName)
        {
            var newElement = statElementAsset.Instantiate();
            var newController = new StatElementController(newElement, _statistics, this, st, statName);
            newElement.userData = newController;

            return newElement;
        }

        private VisualElement CreateElement(CharacteristicsType characteristicsType, string statName)
        {
            var newElement = statElementAsset.Instantiate();
            var newController = new StatElementController(newElement, _statistics, this, characteristicsType, statName);
            newElement.userData = newController;

            return newElement;
        }

        private VisualElement CreateElement(StatType st, StatType st2, string statName)
        {
            var newElement = statElementAsset.Instantiate();
            var newController = new StatElementController(newElement, _statistics, this, st, st2, statName);
            newElement.userData = newController;

            return newElement;
        }
    }
}