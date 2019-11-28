using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[System.Serializable]
public struct InventoryEntry
{
    public int num;
    public BasicItemObject item;
}*/

[CreateAssetMenu(fileName = "PlayerInventory", menuName = "MyCustomObjects/PlayerInventoryObject", order = 1)]
public class InventoryObject : ScriptableObject
{
    public List<BasicItemObject> items = new List<BasicItemObject>();
}