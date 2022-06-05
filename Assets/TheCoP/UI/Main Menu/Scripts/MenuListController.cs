using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TheCOP.Yorky.UI;

public class MenuListController
{

    VisualTreeAsset _elementTemplate;

    ListView menuList;
    Label testLabel;

    public MenuListController(VisualElement root, VisualTreeAsset elementTemplate)
    {
        EnumerateElements();

        _elementTemplate = elementTemplate;

        menuList = root.Q<ListView>("MineMenu");

        testLabel = root.Q<Label>("TestLabel");

        FillCharacterList();

        menuList.onItemsChosen += OnSelect;
    }

    List<ButtonData> buttons = new();

    void EnumerateElements()
    {
        buttons.Add(new ButtonData("Play", () => SceneManager.LoadScene(1, LoadSceneMode.Single)));
        buttons.Add(new ButtonData("Load", () => Debug.Log("Load button pressed")));
        buttons.Add(new ButtonData("Exit", () => { Application.Quit(); Debug.Log("Exit button pressed"); }));
    }

    void FillCharacterList()
    {
        menuList.makeItem = () =>
        {
            var newElement = _elementTemplate.Instantiate();

            newElement.userData = new ListViewElementController(newElement);

            return newElement;
        };

        menuList.bindItem = (item, index) =>
        {
            (item.userData as ListViewElementController).SetElemetData(buttons[index]);
            if (index == 0)
                item.Focus();
        };

        menuList.itemsSource = buttons;

    }

    void OnSelect(IEnumerable<object> element)
    {
        var elementData = menuList.selectedItem as ButtonData;
        if (elementData == null)
        {
            testLabel.text = "";
            return;
        }

        testLabel.text = elementData.ButtonText;

        elementData.Action?.Invoke();

    }

}
