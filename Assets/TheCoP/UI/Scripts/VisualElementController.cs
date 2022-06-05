using UnityEngine.UIElements;

namespace TheCOP.Yorky.UI
{
    public class VisualElementController
    {
        private VisualElement _vl;
        private ButtonAction _action;

        public VisualElement SetVisualElement
        {
            set
            {
                _vl = value;
                _vl.RegisterCallback<ClickEvent>(OnClick);
            }
        }

        public ButtonAction Action { set => _action = value; }

        public VisualElementController(VisualElement vl, ButtonAction action)
        {
            _vl = vl;
            _vl.RegisterCallback<ClickEvent>(OnClick);
            _action = action;
        }

        private void OnClick(ClickEvent ce)
        {
            _action?.Invoke();
        }
    }
}
