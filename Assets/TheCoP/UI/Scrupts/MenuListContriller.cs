using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuListContriller
{

    VisualTreeAsset _elementTemplate;

    ListView menuList;

    public MenuListContriller(VisualElement root, VisualTreeAsset elementTemplate)
    {
        EnumerateElements();

        _elementTemplate = elementTemplate;

        menuList = root.Q<ListView>("MineMenu");

        FillCharacterList();
    }

    List<ButtonData> buttons=new();

    void EnumerateElements()
    {
        buttons.Add(new ButtonData("Play"));
        buttons.Add(new ButtonData("qwe"));
    }

    void FillCharacterList()
    {
        menuList.makeItem = () =>
        {
            var newElement = _elementTemplate.Instantiate();

            var newController = new ListViewElementController();

            newElement.userData = newController;

            newController.SetVisualElement(newElement);

            return newElement;
        };

        menuList.bindItem = (item, index) =>
        {
            (item.userData as ListViewElementController).SetElementLabel(buttons[index].ButtonText);
        };

        menuList.itemsSource = buttons;
    }


}
