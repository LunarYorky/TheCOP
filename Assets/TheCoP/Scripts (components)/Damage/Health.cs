using UnityEngine;

namespace TheCoP.Scripts__components_.Damage
{
    [RequireComponent(typeof(Statistics))]
    public class Health : MonoBehaviour
    {
        private float _currentHealth;
        private float _invertedResistance;

        public float InvertedResistance
        {
            get { return _invertedResistance; }
            set { _invertedResistance = value; }
        }

        public float CurrentHealth
        {
            get { return _currentHealth; }
            private set { _currentHealth = value < 0f ? 0f : value; }
        }

        public void DealingDamage(float damage)
        {
            _currentHealth -= damage * _invertedResistance;
        }

        void Update()
        {
            if (_currentHealth == 0)
                Destroy(gameObject);
        }
    }
}
