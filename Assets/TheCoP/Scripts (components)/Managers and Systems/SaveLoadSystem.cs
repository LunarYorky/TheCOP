using TheCoP.Architecture.Data_types;
using TheCoP.Architecture.Save_Load;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    private StorageManager storageManager = new();

    public void SaveGame()
    {
        storageManager.SaveGame(1);
    }

    public void LoadGame()
    {
        SaveData saveData = storageManager.LoadSaveData(1);
        var enemys = GameObject.FindGameObjectsWithTag("Entity");
        foreach (var item in enemys)
        {
            Destroy(item);
        }

        player.transform.position = new Vector3(saveData.Positions[0], saveData.Positions[1]);

        for (int i = 2; i < saveData.Positions.Length; i += 2)
        {
            var pos = new Vector3(saveData.Positions[i], saveData.Positions[i + 1]);
            Instantiate(enemy, pos, new Quaternion());
        }
    }

    public void DeleteSave()
    {
        storageManager.DeleteSaveData(1);
    }

    public void OnApplicationQuit() // OnApplicationFocus
    {
    }
}
