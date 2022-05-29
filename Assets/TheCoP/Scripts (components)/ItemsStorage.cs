using System;
using System.Collections.Generic;

using UnityEngine;

public class ItemsStorage : MonoBehaviour, IStatsModifier
{
    private List<Item> storedItems;

    public List<Item> StoredItems => storedItems;
    public int ItemsCount => storedItems.Count;

    public void ModifyStatistics()
    {
        var statBlock = GetComponent<Statistics>();
        if (statBlock == null)
            return;
    }

    public void SortItemsList()
    {
        storedItems.Sort((x, y) => String.Compare(x.Name, y.Name));
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
        foreach (var item in storedItems)
        {
            if (item.ItemEquals(newItem))
            {
                item.Number += number;
                calculateStats();
                return true;
            }
        }

        storedItems.Add(newItem);
        calculateStats();
        return true;
    }

    public bool DeleteItem(int location, short number = 1)
    {
        calculateStats();
        return true;
    }
}
