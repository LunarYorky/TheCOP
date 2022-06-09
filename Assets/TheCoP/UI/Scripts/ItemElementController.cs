using UnityEngine.UIElements;

namespace TheCOP.Yorky.UI
{
    public class ItemElementController
    {
        private VisualElement _icon;
        private Label _elemetName;
        private Label _mass;
        private Label _volume;
        private VoidAction _buttonAction;

        public ItemElementController(VisualElement visualElement)
        {
            visualElement.RegisterCallback<ClickEvent>(OnClick);

            _icon = visualElement.Q<VisualElement>("Icon");
            _elemetName = visualElement.Q<Label>("Name");
            _mass = visualElement.Q<Label>("Mass");
            _volume = visualElement.Q<Label>("Volume");
        }

        public void SetItemData(Item item, VoidAction action)
        {
            _icon.style.backgroundImage = new StyleBackground(item.Icon);
            _elemetName.text = item.Name;
            _mass.text = "Mass: " + item.Weight.ToString();
            _volume.text = "Volume: " + item.Volume.ToString();
            _buttonAction = action;
        }

        private void OnClick(ClickEvent ce)
        {
            _buttonAction?.Invoke();
        }
    }
}