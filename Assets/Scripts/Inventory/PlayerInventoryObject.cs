using UnityEngine;

[System.Serializable]
public struct InventoryEntry
{
    public int num;
    public BasicItemObject item;
}

[CreateAssetMenu(fileName = "PlayerInventory", menuName = "MyCustomObjects/PlayerInventoryObject", order = 1)]
public class PlayerInventoryObject : ScriptableObject
{
    public InventoryEntry[] inventory;
}