using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item")]
public class ItemReference : ScriptableObject
{
    [Header("Item stats")]
    [SerializeField] private short _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _volume;
    [SerializeField] private float _weight;
    protected ItemType _itemType = ItemType.Item;


    public short Id => _id;
    public string Name => _name;
    public Sprite Icon => _icon;
    public float Volume => _volume;
    public float Weight => _weight;
    public ItemType ItemType => _itemType;
}
