using System.Collections.Generic;
using TheCoP.UI.Scripts;
using UnityEngine;
using UnityEngine.UIElements;

namespace TheCoP.Scripts__components_.UI
{
    public class InventoryUIController : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset element;
        [SerializeField] private GameObject source;
        private ItemsStorage _itemsStorage;
        private List<Item> _items;
        private ListView _list;
        private VisualElement _icon;
        private Label _itemInfoName;
        private Label _description;
        private Label _totalMass;
        private Label _totalVolume;

        public void Browse(UIDocument doc)
        {
            var root = doc.rootVisualElement;
            _list = root.Q<ListView>("ItemList");
            _icon = root.Q<VisualElement>("ItemInfoIcon");
            _itemInfoName = root.Q<Label>("ItemInfoName");
            _description = root.Q<Label>("Description");
            _totalMass = root.Q<Label>("TotalMass");
            _totalVolume = root.Q<Label>("TotalVolume");

            _itemsStorage = source.GetComponent<ItemsStorage>();
            _items = _itemsStorage.StoredItems;

            FillList();

            _totalMass.text = _itemsStorage.TotalMass.ToString();
            _totalVolume.text = _itemsStorage.TotalVolume.ToString();
        }

        private void FillList()
        {
            _list.itemsSource = _items;

            _list.makeItem = () =>
            {
                var newElement = element.Instantiate();
                newElement.userData = new ItemElementController(newElement);
                return newElement;
            };

            _list.bindItem = (item, index) =>
            {
                (item.userData as ItemElementController).SetItemData(_items[index], () => Debug.Log("Предмет " + _items[index].Name));
            };

            _list.onSelectionChange += OnSelect;
        }

        private void OnSelect(IEnumerable<object> selectedItems)
        {
            var selectedItem = _list.selectedItem as Item;
            if (selectedItem == null)
            {
                _icon.style.backgroundImage = null;
                _itemInfoName.text = "";
                _description.text = "";
                return;
            }

            _icon.style.backgroundImage = new StyleBackground(selectedItem.Icon);
            _itemInfoName.text = selectedItem.Name;
            _description.text = "Описание предмета";
        }
    }
}
