using System.Collections.Generic;

using UnityEngine;

public class Item
{
    private ItemReference _ref;
    private short _refId;
    private string _name;
    private Sprite _icon;
    private ItemType _itemType = ItemType.Item;
    private float _volume;
    private float _weight;
    private byte _equippedSlot;
    private EquipmentClass _equipmentClass;
    private EquipmentType _equipmentType;
    private short _maxDurability;
    private short _durability = 0;
    private short _state = 0;
    private short _level = 0;
    private short _number;
    private List<short> _enchants;
    private WeaponClass _weaponClass;

    public ItemReference Ref { get => _ref; private set => _ref = value; }
    public short RefId { get => _refId; private set => _refId = value; }
    public short Number { get => _number; set => _number = value; }
    public short Durability { get => _durability; private set => _durability = value; }
    public short State { get => _state; set => _state = value; }
    public short Level { get => _level; set => _level = value; }
    public List<short> Enchants { get => _enchants; set => _enchants = value; }
    public string Name { get => _name; private set => _name = value; }
    public Sprite Icon { get => _icon; private set => _icon = value; }
    public ItemType ItemType { get => _itemType; private set => _itemType = value; }
    public float Volume { get => _volume; private set => _volume = value; }
    public float Weight { get => _weight; private set => _weight = value; }
    public EquipmentClass EquipmentClass { get => _equipmentClass; private set => _equipmentClass = value; }
    public EquipmentType EquipmentType { get => _equipmentType; private set => _equipmentType = value; }
    public short MaxDurability { get => _maxDurability; private set => _maxDurability = value; }
    public byte EquippedSlot { get => _equippedSlot; set => _equippedSlot = value; }
    public WeaponClass WeaponClass { get => _weaponClass; private set => _weaponClass = value; }

    public Item(short refId, short number = 1)
    {
        _ref = ResourcesManager.Items[refId];
        _number = number;
        initStats();
    }

    private void initStats()
    {
        _number = 1;
        _refId = _ref.Id;
        _name = _ref.Name;
        _icon = _ref.Icon;
        _volume = _ref.Volume;
        _weight = _ref.Weight;
        _itemType = _ref.ItemType;

        if (_itemType != ItemType.Item)
        {
            if (_ref is EquipmentReference er)
            {
                _equipmentClass = er.EquipmentClass;
                _equipmentType = er.EquipmentType;
                _maxDurability = er.MaxDurability;
                _durability = _maxDurability;
            }
            else if (_ref is WeaponReference wr)
            {
                _weaponClass = wr.WeaponClass;
                _maxDurability = wr.MaxDurability;
                _durability = _maxDurability;
            }
            else if (false)
            {
            }
        }
    }
    
    /// <summary>
    /// Only supports sorted enchants
    /// </summary>
    public bool CheckStack(Item item)
    {
        if (_enchants == null ^ item._enchants == null)
            return false;

        if (_enchants != null && item._enchants != null)
        {
            if (_enchants.Count != item._enchants.Count)
                return false;

            for (int i = 0; i < _enchants.Count; i++)
            {
                if (_enchants[i] != item._enchants[i])
                    return false;
            }
        }

        return _equippedSlot == 0 &&
               item.EquippedSlot == 0 &&
               _refId == item._refId &&
               _durability == item._durability &&
               _state == item._state &&
               _level == item._level;
    }
}
