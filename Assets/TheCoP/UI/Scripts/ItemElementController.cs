using UnityEngine.UIElements;

namespace TheCOP.Yorky.UI
{
    public class ItemElementController
    {
        private VisualElement _vl;
        private VisualElement icon;
        private Label elemetName;
        private Label mass;
        private Label volume;
        private ButtonAction buttonAction;

        public ItemElementController(VisualElement vl)
        {
            _vl = vl;
            _vl.RegisterCallback<ClickEvent>(OnClick);

            icon = _vl.Q<VisualElement>("Icon");
            elemetName = _vl.Q<Label>("Name");
            mass = _vl.Q<Label>("Mass");
            volume = _vl.Q<Label>("Volume");
        }

        public void SetItemData(Item item, ButtonAction action)
        {
            icon.style.backgroundImage = new StyleBackground(item.Icon);
            elemetName.text = item.Name;
            mass.text = "Mass: " + item.Weight.ToString();
            volume.text = "Volume: " + item.Volume.ToString();
            buttonAction = action;
        }

        private void OnClick(ClickEvent ce)
        {
            buttonAction?.Invoke();
        }
    }
}