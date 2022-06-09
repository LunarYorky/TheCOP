using UnityEngine.UIElements;

namespace TheCoP.UI.Scripts
{
    public class ListViewElementController
    {
        private Label _elemetName;
        private VoidAction _buttonAction;

        public ListViewElementController(VisualElement vl)
        {
            vl.RegisterCallback<ClickEvent>(OnClick);
            _elemetName = vl.Q<Label>();

        }

        public void SetElemetData(ButtonData data)
        {
            _elemetName.text = data.ButtonText;
            _buttonAction = data.Action;
        }

        public void SetElemetData(string label, VoidAction action)
        {
            _elemetName.text = label;
            _buttonAction = action;
        }

        private void OnClick(ClickEvent ev)
        {
            _buttonAction?.Invoke();

        }
    }
}