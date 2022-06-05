using System;

using UnityEngine;
using UnityEngine.UIElements;

namespace TheCOP.Yorky.UI
{
    public class ListViewElementController
    {
        private VisualElement _vl;
        private Label elemetName;
        private ButtonAction buttonAction;

        public ListViewElementController(VisualElement vl)
        {
            _vl = vl;
            _vl.RegisterCallback<ClickEvent>(OnClick);
            elemetName = _vl.Q<Label>();

        }

        public void SetElemetData(ButtonData data)
        {
            elemetName.text = data.ButtonText;
            buttonAction = data.Action;
        }

        public void SetElemetData(string label, ButtonAction action)
        {
            elemetName.text = label;
            buttonAction = action;
        }

        private void OnClick(ClickEvent ev)
        {
            buttonAction?.Invoke();

        }
    }
}