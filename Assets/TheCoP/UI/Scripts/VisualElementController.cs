using UnityEngine.UIElements;

namespace TheCOP.Yorky.UI
{
    public class VisualElementController
    {
        private ButtonAction _action;

        public ButtonAction Action { set => _action = value; }

        public VisualElementController(VisualElement vl, ButtonAction action)
        {
            vl.RegisterCallback<ClickEvent>(OnClick);
            _action = action;
        }

        private void OnClick(ClickEvent ce)
        {
            _action?.Invoke();
        }
    }
}
