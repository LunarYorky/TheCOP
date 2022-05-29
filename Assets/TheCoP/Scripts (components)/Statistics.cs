using UnityEngine;
using UnityEngine.EventSystems;

public class Statistics : MonoBehaviour
{
    // Basic Stats
    private int _basicHealth;
    private int _basicAdaptability;
    private int _basicDexterity;
    private int _basicStrength;
    private int _id;
    private int _status;

    // Calculated stats
    [SerializeField] private float maxHealth;
    [SerializeField] private float resresistance;

    // resources
    [SerializeField] private float currentHealth;

    //gprops-------------------------------------------------------------------------------------

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

    public int Id
    {
        get { return _id; }
        private set { _id = value; }
    }

    public int Status
    {
        get { return _status; }
        private set { _status = value; }
    }

    public int ItemsCount
    {
        get
        {
            var itemsStorage = GetComponent<ItemsStorage>();
            return itemsStorage == null ? 0 : itemsStorage.ItemsCount;
        }
    }

    // LoGgika------------------------------------------------------------------------------------

    void Update()
    {
        if (currentHealth == 0)
            Destroy(gameObject);
    }

    public void CalculateStats()
    {
        ExecuteEvents.Execute<IStatsModifier>(gameObject, null, (x, y) => x.ModifyStatistics());
    }

    public void DealingDamage(float damage)
    {
        CurrentHealth -= damage * resresistance;
    }
}
