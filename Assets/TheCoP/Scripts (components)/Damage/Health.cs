using TheCoP.Scripts__components_;
using UnityEngine;

[RequireComponent(typeof(Statistics))]
public class Health : MonoBehaviour
{
    private float currentHealth;
    private float resresistance;

    public float Resresistance
    {
        get { return resresistance; }
        set { resresistance = value; }
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
        private set { currentHealth = value < 0f ? 0f : value; }
    }

    public void DealingDamage(float damage)
    {
        currentHealth = damage * resresistance;
    }

    void Update()
    {
        if (currentHealth == 0)
            Destroy(gameObject);
    }
}
