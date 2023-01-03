using System.Collections.Generic;
using TheCoP.UI.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace TheCoP.UI.Main_Menu.Scripts
{
    public class MenuListController
    {
        private readonly VisualTreeAsset _elementTemplate;
        private readonly List<ButtonData> _buttons = new();

        private readonly ListView _menuList;
        private readonly Label _testLabel;

        public MenuListController(VisualElement root, VisualTreeAsset elementTemplate)
        {
            EnumerateElements();

            _elementTemplate = elementTemplate;

            _menuList = root.Q<ListView>("MineMenu");

            _testLabel = root.Q<Label>("TestLabel");

            FillCharacterList();

            _menuList.onItemsChosen += OnSelect;
        }

        private void EnumerateElements()
        {
            _buttons.Add(new ButtonData("Play", () => SceneManager.LoadScene(1, LoadSceneMode.Single)));
            _buttons.Add(new ButtonData("Load", () => Debug.Log("Load button pressed")));
            _buttons.Add(new ButtonData("Exit", () => { Application.Quit(); Debug.Log("Exit button pressed"); }));
        }

        private void FillCharacterList()
        {
            _menuList.makeItem = () =>
            {
                var newElement = _elementTemplate.Instantiate();

                newElement.userData = new ListViewElementController(newElement);

                return newElement;
            };

            _menuList.bindItem = (item, index) =>
            {
                (item.userData as ListViewElementController)?.SetElementData(_buttons[index]);
                if (index == 0)
                    item.Focus();
            };

            _menuList.itemsSource = _buttons;

        }

        private void OnSelect(IEnumerable<object> element)
        {
            var elementData = _menuList.selectedItem as ButtonData;
            if (elementData == null)
            {
                _testLabel.text = "";
                return;
            }

            _testLabel.text = elementData.ButtonText;

            elementData.Action?.Invoke();

        }

    }
}
