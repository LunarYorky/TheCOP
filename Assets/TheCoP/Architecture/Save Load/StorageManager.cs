using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

using UnityEngine;

public class StorageManager
{
    private string directory;

    public StorageManager()
    {
        Getdirectory();
    }

    private void Getdirectory()
    {
        directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        directory = Directory.Exists(directory) ? directory : Application.persistentDataPath;
        directory = directory + "/TestRoomGame/saves";
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
    }

    public void SaveGame(byte number)
    {
        BinaryFormatter bf = new();
        FileStream file = File.Create(directory + "/gamesave" + number + ".save");
        bf.Serialize(file, CreateSaveData());
        file.Close();
    }

    private SaveData CreateSaveData()
    {
        var saveData = new SaveData();
        var player = GameObject.FindWithTag("Player");
        var objs = GameObject.FindGameObjectsWithTag("Entity");
        saveData.Positions = new float[(objs.Length * 2) + 2];
        saveData.IdStatusItemCount = new int[(objs.Length * 3) + 3];

        if (player == null)
        {
            //Чё? Респавн наверное... Или загрузка.
        }
        else
        {
            var stats = player.GetComponent<Statistics>();
            saveData.Positions[0] = player.transform.position.x;
            saveData.Positions[1] = player.transform.position.y;
            saveData.IdStatusItemCount[0] = stats.Id;
            saveData.IdStatusItemCount[1] = stats.Status;
            saveData.IdStatusItemCount[2] = stats.ItemsCount;
        }

        int _i = 2;
        int _ii = 3;
        int allItemsCount = 0;
        Statistics statistics;
        foreach (var item in objs)
        {
            saveData.Positions[_i] = item.transform.position.x;
            _i++;
            saveData.Positions[_i] = item.transform.position.y;
            _i++;
            statistics = item.GetComponent<Statistics>();
            saveData.IdStatusItemCount[_ii] = statistics.Id;
            _ii++;
            saveData.IdStatusItemCount[_ii] = statistics.Status;
            _ii++;
            saveData.IdStatusItemCount[_ii] = statistics.ItemsCount;
            allItemsCount += statistics.ItemsCount;
            _ii++;
        }

        saveData.Items = new short[allItemsCount][];
        //saveData.Equipped = new bool[allItemsCount];
        ItemsStorage storage;
        int _iii = 0;
        foreach (var obj in objs)
        {
            storage = obj.GetComponent<ItemsStorage>();
            if (storage == null)
                continue;

            foreach (var item in storage.StoredItems)
            {
                var length = item.Enchants != null ? item.Enchants.Count + 5 : 5;

                saveData.Items[_iii] = new short[length]; //Id, number of items, state, Durability, level, enchants
                saveData.Items[_iii][0] = item.RefId;
                saveData.Items[_iii][1] = item.Number;
                saveData.Items[_iii][2] = item.State;
                saveData.Items[_iii][3] = item.Durability;
                saveData.Items[_iii][4] = item.Level;
                for (int i = 5; i < length; i++)
                {
                    saveData.Items[_iii][i] = item.Enchants[i - 5];
                }

                saveData.EquippedSlot[_iii] = item.EquippedSlot;
                _iii++;
            }
        }

        return saveData;
    }

    public SaveData LoadSaveData(byte number) //переделать реф
    {
        if (!File.Exists(directory + "/gamesave" + number + ".save"))
        {
            //Miss Load Data
        }

        BinaryFormatter bf = new BinaryFormatter();
        Debug.Log(directory + "/gamesave" + number + ".save");
        FileStream file = File.Open(directory + "/gamesave" + number + ".save", FileMode.Open);
        SaveData save = (SaveData)bf.Deserialize(file);
        file.Close();
        return save; //переделать
    }

    public void DeleteSaveData(byte number)
    {
        File.Delete(directory + "/gamesave" + number + ".save");
    }

    public void CheckSaveFiles()
    {
        var pattern = "^gamesave\\d\\.save$";
        var files = Directory.EnumerateFiles(directory);
        foreach (string path in files)
        {
            if (Regex.IsMatch(Path.GetFileName(path), pattern))
            {
                Debug.Log(path);
                Debug.Log(Path.GetFileNameWithoutExtension(path)[8]);
            }
        }
    }
}
