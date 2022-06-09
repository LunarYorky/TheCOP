using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject UIManager;

    private UIManager uiManager;

    public void Start()
    {
        uiManager = UIManager.GetComponent<UIManager>();
    }

    public void OnMenu()
    {
        uiManager.GameMenuSwitch();
    }
}
