using UnityEngine;
using UnityEngine.UIElements;

using TheCOP.Yorky.UI;


public class GameSelectPanelController : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset SelectPanelAsset;
    [SerializeField] private VisualTreeAsset inventoryAsset;

    private StorageBrowser storageBrowser;
    private UIDocument uIDocument;
    private VisualElement root;
    private VisualElement equipment;
    private VisualElement inventory;
    private VisualElement statistics;
    private VisualElement other;
    private VisualElement settings;

    public void OnEnable()
    {
        storageBrowser = GetComponent<StorageBrowser>();
        uIDocument = GetComponent<UIDocument>();
        uIDocument.visualTreeAsset = SelectPanelAsset;
        root = uIDocument.rootVisualElement;

        equipment = root.Q<VisualElement>("Equipment");
        inventory = root.Q<VisualElement>("Inventory");
        statistics = root.Q<VisualElement>("Statistics");
        other = root.Q<VisualElement>("Other");
        settings = root.Q<VisualElement>("Settings");

        InitGameMenu();
    }

    private void InitGameMenu()
    {
        equipment.userData = new VisualElementController(equipment, () => Debug.Log("Equipment open"));
        inventory.userData = new VisualElementController(inventory, OpenInventory);
        statistics.userData = new VisualElementController(statistics, () => Debug.Log("Statistics open"));
        other.userData = new VisualElementController(other, () => Debug.Log("Other open"));
        settings.userData = new VisualElementController(settings, () => Debug.Log("Settings open"));
    }

    private void OpenInventory()
    {
        //uIDocument.enabled = false;
        uIDocument.visualTreeAsset = inventoryAsset;
        //uIDocument.enabled = true;
        storageBrowser.Browse(uIDocument);

    }
}
