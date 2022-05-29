using UnityEngine;

[CreateAssetMenu(fileName = "New Item Enchan", menuName = "ScriptableObjects/Item Enchant")]
public class ItemEnchant : ScriptableObject
{
    [SerializeField] private short _id;
    [SerializeField] private string _name;
}
