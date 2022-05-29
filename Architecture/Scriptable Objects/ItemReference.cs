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


    public short Id { get { return _id; } }
    public string Name { get { return _name; } }
    public Sprite Icon  { get { return _icon; } }
    public float Volume { get { return _volume; } }
    public float Weight { get { return _weight; } }
    public ItemType ItemType { get => _itemType; }
}
