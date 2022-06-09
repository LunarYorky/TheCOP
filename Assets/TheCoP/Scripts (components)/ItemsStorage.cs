using System;
using System.Collections.Generic;
using TheCoP.Scripts__components_;
using UnityEngine;

public class ItemsStorage : MonoBehaviour, IStatsModifier
{
    [SerializeField] private short[] additems;

    private readonly List<Item> _storedItems = new();
    private int _totalMass;
    private int _totalVolume;

    public List<Item> StoredItems => _storedItems;
    public int ItemsCount => _storedItems.Count;

    public int TotalMass => _totalMass;
    public int TotalVolume => _totalVolume;

    public void Start()
    {
        foreach (var item in additems)
        {
            AddItem(item);
        }
    }

    public void ModifyStatistics()
    {
        var statBlock = GetComponent<Statistics>();
        if (statBlock == null)
            return;
    }

    public void SortItemsList()
    {
        _storedItems.Sort((x, y) => String.Compare(x.Name, y.Name));
    }

    private void calculateStats()
    {
        var statBlock = GetComponent<Statistics>();
        if (statBlock == null)
            return;

        statBlock.CalculateStats(); //recalculate stats
    }

    public bool AddItem(short id, short number = 1)
    {
        var newItem = new Item(id);
        foreach (var item in _storedItems)
        {
            if (item.CheckStack(newItem))
            {
                item.Number += number;
                calculateStats();
                return true;
            }
        }

        _storedItems.Add(newItem);
        calculateStats();
        return true;
    }

    public bool DeleteItem(int location, short number = 1)
    {
        calculateStats();
        return true;
    }
}
