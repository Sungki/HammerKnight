using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInventory", menuName = "MyCustomObjects/PlayerInventoryObject", order = 1)]
public class InventoryObject : ScriptableObject
{
    public List<EquipmentItemObject> items = new List<EquipmentItemObject>();
    public EquipmentItemObject myArmor;
    public EquipmentItemObject myHammer;
}