using System.Globalization;
using TheCoP.Architecture.Enums;
using TheCoP.Scripts__components_;
using TheCoP.Scripts__components_.UI;
using UnityEngine.UIElements;

namespace TheCoP.UI.Scripts
{
    public class StatElementController
    {
        public StatElementController(VisualElement root, Statistics statistics, StatisticsUIController controller,
            CharacteristicsType ct, string name)
        {
            var _statName = root.Q<Label>("StatName");
            var _statValue = root.Q<Label>("Value");
            var _up = root.Q<VisualElement>("Up");
            var _down = root.Q<VisualElement>("Down");

            _statName.text = name;

            controller.Refresh += () => _statValue.text = statistics.GetStat(ct).ToString();

            _up.RegisterCallback<ClickEvent>(evt =>
            {
                statistics.Increment(ct);
                controller.Refresh?.Invoke();
            });
            _down.RegisterCallback<ClickEvent>(evt =>
            {
                statistics.Decrement(ct);
                controller.Refresh?.Invoke();
            });
        }

        public StatElementController(VisualElement root, Statistics statistics, StatisticsUIController controller,
            StatType statType, string name)
        {
            var _statName = root.Q<Label>("StatName");
            var _statValue = root.Q<Label>("Value");

            root.Q<VisualElement>("Up").RemoveFromHierarchy();
            root.Q<VisualElement>("Down").RemoveFromHierarchy();

            _statName.text = name;

            controller.Refresh += () =>
                _statValue.text = statistics.GetStat(statType).ToString(CultureInfo.InvariantCulture);
        }

        public StatElementController(VisualElement root, Statistics statistics, StatisticsUIController controller,
            StatType statType1, StatType statType2, string name)
        {
            var _statName = root.Q<Label>("StatName");
            var _statValue = root.Q<Label>("Value");

            root.Q<VisualElement>("Up").RemoveFromHierarchy();
            root.Q<VisualElement>("Down").RemoveFromHierarchy();

            _statName.text = name;

            controller.Refresh += () =>
                _statValue.text = statistics.GetStat(statType1).ToString(CultureInfo.InvariantCulture) + "/" +
                                  statistics.GetStat(statType2).ToString(CultureInfo.InvariantCulture);
        }
    }
}