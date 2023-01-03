using UnityEngine.UIElements;

namespace TheCoP.UI.Scripts
{
    public class ListViewElementController
    {
        private readonly Label _elementName;
        private ButtonAction _buttonAction;

        public ListViewElementController(VisualElement vl)
        {
            vl.RegisterCallback<ClickEvent>(OnClick);
            _elementName = vl.Q<Label>();

        }

        public void SetElementData(ButtonData data)
        {
            _elementName.text = data.ButtonText;
            _buttonAction = data.Action;
        }

        public void SetElementData(string label, ButtonAction action)
        {
            _elementName.text = label;
            _buttonAction = action;
        }

        private void OnClick(ClickEvent ev)
        {
            _buttonAction?.Invoke();

        }
    }
}