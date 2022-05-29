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

    public EquipmentClass EquipmentClass => _equipmentClass;
    public EquipmentType EquipmentType => _equipmentType;
    public short MaxDurability => _maxDurability;

    // Тут должны быть резисты
    // Тут должны быть эффекты
}
