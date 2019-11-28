using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentItem", menuName = "MyCustomObjects/EquipmentItemObject", order = 1)]
public class EquipmentItemObject : BasicItemObject
{
    public int attack;
    public int defense;

    EquipmentItemObject()
    {
        this.type = EItemType.Equipment;
    }
}