using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject UIManager;

    private UIManager uIManager;

    public void Start()
    {
        uIManager = UIManager.GetComponent<UIManager>();
    }

    public void OnMenu()
    {
        uIManager.GameMenuSwitch();
    }
}
