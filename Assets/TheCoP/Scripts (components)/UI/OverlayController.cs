using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;

namespace TheCoP.Scripts__components_.UI
{
    public class OverlayController : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private Statistics _statistics;
        private UIDocument _uiDocument;
        private VisualElement _root;
        private ProgressBar _healthBar;
        private ProgressBar _staminaBar;

        private void OnEnable()
        {
            _statistics = player.GetComponent<Statistics>();
            _uiDocument = GetComponent<UIDocument>();
            _root = _uiDocument.rootVisualElement;

            _healthBar = _root.Q<ProgressBar>("HealthBar");
            _staminaBar = _root.Q<ProgressBar>("StaminaBar");
        }

        private void Update()
        {
            _healthBar.highValue = _statistics.MaxHealth;
            _staminaBar.highValue = _statistics.MaxStamina;
            _healthBar.value = _statistics.CurrentHealth;
            _staminaBar.value = _statistics.CurrentStamina;
            _healthBar.title = _statistics.MaxHealth.ToString(CultureInfo.InvariantCulture);
            _staminaBar.title = _statistics.MaxStamina.ToString(CultureInfo.CurrentCulture);
        }
    }
}