using System.Collections.Generic;
using TheCoP.UI.Scripts;
using UnityEngine;
using UnityEngine.UIElements;

namespace TheCoP.Scripts__components_.UI
{
    public class GameSelectPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject overlay;
        [SerializeField] private VisualTreeAsset selectPanelAsset;
        [SerializeField] private VisualTreeAsset inventoryAsset;
        [SerializeField] private VisualTreeAsset statisticsAsset;

        private enum Menus
        {
            SelectPanel,
            Invent,
            Stats
        }

        private readonly Stack<Menus> _menusStack = new();

        private InventoryUIController _inventoryUIController;
        private StatisticsUIController _statisticsUIController;
        private UIDocument _uIDocument;

        public void Switch()
        {
            if (_menusStack.Count == 0)
            {
                _uIDocument = GetComponent<UIDocument>();
                _inventoryUIController = GetComponent<InventoryUIController>();
                _statisticsUIController = GetComponent<StatisticsUIController>();

                gameObject.SetActive(true);
                overlay.SetActive(false);

                _menusStack.Clear();
                _menusStack.Push(Menus.SelectPanel);
                Open(Menus.SelectPanel);
            }
            else
            {
                Menus item;
                _menusStack.Pop();
                if (_menusStack.TryPeek(out item))
                {
                    Open(item);
                }
                else
                {
                    gameObject.SetActive(false);
                    overlay.SetActive(true);
                }
            }
        }

        private void DisableControllers()
        {
            _inventoryUIController.enabled = false;
            _statisticsUIController.enabled = false;
        }

        private void Open(Menus menu)
        {
            DisableControllers();

            if (menu == Menus.SelectPanel)
                OpenSelectPanel();
            else if (menu == Menus.Invent)
                OpenInventory();
            else if (menu == Menus.Stats) OpenStatistics();
        }

        private void OpenSelectPanel()
        {
            _uIDocument.visualTreeAsset = selectPanelAsset;
            var root = _uIDocument.rootVisualElement;

            var equipment = root.Q<VisualElement>("Equipment");
            var inventory = root.Q<VisualElement>("Inventory");
            var statistics = root.Q<VisualElement>("Statistics");
            var other = root.Q<VisualElement>("Other");
            var settings = root.Q<VisualElement>("Settings");

            equipment.userData = new VisualElementController(equipment, () => Debug.Log("Equipment open"));
            inventory.userData = new VisualElementController(inventory, () =>
            {
                _menusStack.Push(Menus.Invent);
                Open(Menus.Invent);
            });
            statistics.userData = new VisualElementController(statistics, () =>
            {
                _menusStack.Push(Menus.Stats);
                Open(Menus.Stats);
            });
            other.userData = new VisualElementController(other, () => Debug.Log("Other open"));
            settings.userData = new VisualElementController(settings, () => Debug.Log("Settings open"));
        }

        private void OpenInventory()
        {
            _uIDocument.visualTreeAsset = inventoryAsset;
            _inventoryUIController.enabled = true;
            _inventoryUIController.Browse(_uIDocument);
        }

        private void OpenStatistics()
        {
            _uIDocument.visualTreeAsset = statisticsAsset;
            _statisticsUIController.enabled = true;
            _statisticsUIController.Browse(_uIDocument);
        }
    }
}