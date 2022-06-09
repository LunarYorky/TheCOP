using TheCoP.UI.Game__menu.Stats;
using UnityEngine;
using UnityEngine.UIElements;
using TheCOP.Yorky.UI;


public class GameSelectPanelController : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset selectPanelAsset;
    [SerializeField] private VisualTreeAsset inventoryAsset;
    [SerializeField] private VisualTreeAsset statsAsset;

    private StorageBrowser _storageBrowser;
    private StatsBrowser _statsBrowser;
    private UIDocument _uiDocument;
    private VisualElement _root;
    private VisualElement _equipment;
    private VisualElement _inventory;
    private VisualElement _statistics;
    private VisualElement _other;
    private VisualElement _settings;

    public void OnEnable()
    {
        _storageBrowser = GetComponent<StorageBrowser>();
        _statsBrowser = GetComponent<StatsBrowser>();
        _uiDocument = GetComponent<UIDocument>();
        _uiDocument.visualTreeAsset = selectPanelAsset;
        _root = _uiDocument.rootVisualElement;

        _equipment = _root.Q<VisualElement>("Equipment");
        _inventory = _root.Q<VisualElement>("Inventory");
        _statistics = _root.Q<VisualElement>("Statistics");
        _other = _root.Q<VisualElement>("Other");
        _settings = _root.Q<VisualElement>("Settings");

        InitGameMenu();
    }

    private void InitGameMenu()
    {
        _equipment.userData = new VisualElementController(_equipment, () => Debug.Log("Equipment open"));
        _inventory.userData = new VisualElementController(_inventory, OpenInventory);
        _statistics.userData = new VisualElementController(_statistics, OpenStats);
        _other.userData = new VisualElementController(_other, () => Debug.Log("Other open"));
        _settings.userData = new VisualElementController(_settings, () => Debug.Log("Settings open"));
    }

    private void OpenInventory()
    {
        _uiDocument.visualTreeAsset = inventoryAsset;
        _storageBrowser.Browse(_uiDocument);
    }

    private void OpenStats()
    {
        _uiDocument.visualTreeAsset = statsAsset;
        _statsBrowser.Browse(_uiDocument);
    }
}
