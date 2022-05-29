using UnityEngine;

public class WeaponReference : ItemReference
{
    public WeaponReference()
    {
        _itemType = ItemType.Weapon;
    }

    [Header("Weapon stats")]
    [SerializeField] private WeaponClass _weaponClass;
    [SerializeField] private short _maxDurability;

    public WeaponClass WeaponClass { get => _weaponClass; private set => _weaponClass = value; }
    public short MaxDurability { get => _maxDurability; private set => _maxDurability = value; }

}
