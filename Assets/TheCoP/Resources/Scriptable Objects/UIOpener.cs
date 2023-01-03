using UnityEngine;

/// <summary>
/// Это компонент, должен весеть под инпутами.
/// </summary>
public class UIOpener : MonoBehaviour
{
    public GameObject UIManager;

    private UIManager _uIManager;

    public void Start()
    {
        _uIManager = UIManager.GetComponent<UIManager>();
    }

    /// <summary>
    /// Это ловит сооббщение от инпутов
    /// </summary>
    public void OnMenu()
    {
        _uIManager.GameMenuSwitch();
    }
}