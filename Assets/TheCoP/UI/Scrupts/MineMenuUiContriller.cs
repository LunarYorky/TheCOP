using UnityEngine;
using UnityEngine.UIElements;

public class MineMenuUiContriller : MonoBehaviour
{
    [SerializeField]
    private VisualTreeAsset element;

    void OnEnable()
    {

        var uiDocument = GetComponent<UIDocument>();

        var listHandler = new MenuListContriller(uiDocument.rootVisualElement, element);

    }
}
