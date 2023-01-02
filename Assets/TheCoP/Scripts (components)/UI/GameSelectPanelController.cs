using System;
using System.Collections.Generic;
using TheCOP.Yorky.UI;
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

        private Stack<Menus> stack = new();

        private InventoryUIController _inventoryUIController;
        private StatisticsUIController _statisticsUIController;
        private UIDocument _uIDocument;

        public void Switch()
        {
            if (stack.Count == 0)
            {
                _uIDocument = GetComponent<UIDocument>();
                _inventoryUIController = GetComponent<InventoryUIController>();
                _statisticsUIController = GetComponent<StatisticsUIController>();

                gameObject.SetActive(true);
                overlay.SetActive(false);

                stack.Clear();
                stack.Push(Menus.SelectPanel);
                Open(Menus.SelectPanel);
            }
            else
            {
                Menus item;
                stack.Pop();
                if (stack.TryPeek(out item))
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
            var _root = _uIDocument.rootVisualElement;

            var _equipment = _root.Q<VisualElement>("Equipment");
            var _inventory = _root.Q<VisualElement>("Inventory");
            var _statistics = _root.Q<VisualElement>("Statistics");
            var _other = _root.Q<VisualElement>("Other");
            var _settings = _root.Q<VisualElement>("Settings");

            _equipment.userData = new VisualElementController(_equipment, () => Debug.Log("Equipment open"));
            _inventory.userData = new VisualElementController(_inventory, () =>
            {
                stack.Push(Menus.Invent);
                Open(Menus.Invent);
            });
            _statistics.userData = new VisualElementController(_statistics, () =>
            {
                stack.Push(Menus.Stats);
                Open(Menus.Stats);
            });
            _other.userData = new VisualElementController(_other, () => Debug.Log("Other open"));
            _settings.userData = new VisualElementController(_settings, () => Debug.Log("Settings open"));
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