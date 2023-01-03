using UnityEngine;
using UnityEngine.UIElements;

namespace TheCoP.UI.Main_Menu.Scripts
{
    public class MainMenuUiController : MonoBehaviour
    {
        [SerializeField]
        private VisualTreeAsset element;

        private void OnEnable()
        {

            var uiDocument = GetComponent<UIDocument>();

            var listHandler = new MenuListController(uiDocument.rootVisualElement, element);

        }

    }
}
