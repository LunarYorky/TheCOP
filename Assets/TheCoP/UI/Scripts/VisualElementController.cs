using UnityEngine.UIElements;

namespace TheCOP.Yorky.UI
{
    public class VisualElementController
    {
        private VoidAction _action;

        public VoidAction Action { set => _action = value; }

        public VisualElementController(VisualElement vl, VoidAction action)
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
