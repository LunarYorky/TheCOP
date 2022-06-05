using UnityEngine;
using UnityEngine.UIElements;

public class MineMenuUiController : MonoBehaviour
{
    [SerializeField]
    private VisualTreeAsset element;

    void OnEnable()
    {

        var uiDocument = GetComponent<UIDocument>();

        var listHandler = new MenuListController(uiDocument.rootVisualElement, element);

    }

}
