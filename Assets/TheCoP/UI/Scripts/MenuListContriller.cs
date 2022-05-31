using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuListContriller
{

    VisualTreeAsset _elementTemplate;

    ListView menuList;
    Label testLabel;

    public MenuListContriller(VisualElement root, VisualTreeAsset elementTemplate)
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
        buttons.Add(new ButtonData("Play"));
        buttons.Add(new ButtonData("Load"));
        buttons.Add(new ButtonData("Exit"));
    }

    void FillCharacterList()
    {
        menuList.makeItem = () =>
        {
            var newElement = _elementTemplate.Instantiate();

            var newController = new ListViewElementController();

            newElement.userData = newController;

            newElement.userData = newController;

            newController.SetVisualElemet(newElement);

            return newElement;
        };

        menuList.bindItem = (item, index) =>
        {
            (item.userData as ListViewElementController).SetElemetData(buttons[index]);
        };

        menuList.itemsSource = buttons;
        menuList.SetSelection(0);

    }

    void OnSelect(IEnumerable<object> element)
    {
        var selectedElement = menuList.selectedItem as ButtonData;
        if (selectedElement == null)
        {
            testLabel.text = "";
            return;
        }

        testLabel.text = selectedElement.ButtonText;

        if (selectedElement.ButtonText == "Exit")
        {
            Application.Quit();
        }
        else if (selectedElement.ButtonText == "Play")
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        else if (selectedElement.ButtonText == "Load")
        {

        }

    }

}
