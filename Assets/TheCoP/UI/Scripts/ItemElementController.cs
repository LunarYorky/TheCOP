using UnityEngine.UIElements;

namespace TheCoP.UI.Scripts
{
    public class ItemElementController
    {
        private readonly VisualElement _icon;
        private readonly Label _elementName;
        private readonly Label _mass;
        private readonly Label _volume;
        private ButtonAction _buttonAction;

        public ItemElementController(VisualElement vl)
        {
            vl.RegisterCallback<ClickEvent>(OnClick);

            _icon = vl.Q<VisualElement>("Icon");
            _elementName = vl.Q<Label>("Name");
            _mass = vl.Q<Label>("Mass");
            _volume = vl.Q<Label>("Volume");
        }

        public void SetItemData(Item item, ButtonAction action)
        {
            _icon.style.backgroundImage = new StyleBackground(item.Icon);
            _elementName.text = item.Name;
            _mass.text = "Mass: " + item.Weight;
            _volume.text = "Volume: " + item.Volume;
            _buttonAction = action;
        }

        private void OnClick(ClickEvent ce)
        {
            _buttonAction?.Invoke();
        }
    }
}
