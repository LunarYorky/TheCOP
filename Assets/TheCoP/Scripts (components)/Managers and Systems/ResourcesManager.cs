using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{

    private static Dictionary<int,ItemReference> items = new();

    public static Dictionary<int,ItemReference> Items
    {
        get { return items; }
        private set { items = value; }
    }

    void Start()
    {
        InitItemDictionary();

        foreach (var item in items)
        {
            Debug.Log("Предмет " + item.Value.Name + " загружен id: " + item.Key);
        }
    }

    private void InitItemDictionary()
    {
        items.Clear();

        object[] test = Resources.LoadAll("Scriptable Objects/Items/", typeof(ItemReference));

        foreach (object obj in test)
        {
            ItemReference item = (ItemReference)obj;
            if (items.ContainsKey(item.Id))
            {
                Debug.LogAssertion("Этот id: " + item.Id + " уже занят. Предмет вызвавший исключение: " + item.Name);
                continue;
            }

            items.Add(item.Id, item);

        }
    }
    public void CheckItemsIds()
    {
        var itemList = Resources.LoadAll<ItemReference>("");
        int[] ids = new int[itemList.Length];
        int i = 0;
        foreach (var item in itemList)
        {
            if (Array.Exists(ids, element => element == item.Id))
                Debug.LogAssertion(item.name + " !!!");
            ids[i] = item.Id;
            i++;
        }


    }
}
