using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

namespace TheCOP.Yorky.UI
{
    public class StorageBrowser : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset element;
        [SerializeField] private GameObject sourse;
        private ItemsStorage itemsStorage;
        private List<Item> items;
        private ListView list;
        private VisualElement Icon;
        private Label itemInfoName;
        private Label description;
        private Label totalMass;
        private Label totalVolume;

        public void Browse(UIDocument doc)
        {
            var root = doc.rootVisualElement;
            list = root.Q<ListView>("ItemList");
            Icon = root.Q<VisualElement>("ItemInfoIcon");
            itemInfoName = root.Q<Label>("ItemInfoName");
            description = root.Q<Label>("Description");
            totalMass = root.Q<Label>("TotalMass");
            totalVolume = root.Q<Label>("TotalVolume");

            itemsStorage = sourse.GetComponent<ItemsStorage>();
            items = itemsStorage.StoredItems;

            FillList();

            totalMass.text = itemsStorage.TotalMass.ToString();
            totalVolume.text = itemsStorage.TotalVolume.ToString();
        }

        private void FillList()
        {
            list.itemsSource = items;

            list.makeItem = () =>
            {
                var newElement = element.Instantiate();
                newElement.userData = new ItemElementController(newElement);
                return newElement;
            };

            list.bindItem = (item, index) =>
            {
                (item.userData as ItemElementController).SetItemData(items[index], () => Debug.Log("Предмет " + items[index].Name));
            };

            list.onSelectionChange += OnSelect;
        }

        private void OnSelect(IEnumerable<object> selectedItems)
        {
            var selectedItem = list.selectedItem as Item;
            if (selectedItem == null)
            {
                Icon.style.backgroundImage = null;
                itemInfoName.text = "";
                description.text = "";
                return;
            }

            Icon.style.backgroundImage = new StyleBackground(selectedItem.Icon);
            itemInfoName.text = selectedItem.Name;
            description.text = "Описание предмета";
        }
    }
}
