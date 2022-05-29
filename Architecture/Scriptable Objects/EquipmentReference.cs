using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "ScriptableObjects/Equipment")]
public class EquipmentReference : ItemReference
{
    public EquipmentReference()
    {
        _itemType = ItemType.Equipment;
    }

    [Header("Equipment stats")]
    [SerializeField] private EquipmentClass _equipmentClass;
    [SerializeField] private EquipmentType _equipmentType;
    [SerializeField] private short _maxDurability;
    // Тут должны быть резисты
    // Тут должны быть эффекты

    public EquipmentClass EquipmentClass { get { return _equipmentClass; } }
    public EquipmentType EquipmentType { get { return _equipmentType; } }
    public short MaxDurability { get { return _maxDurability; } }

    // Тут должны быть резисты
    // Тут должны быть эффекты

}
