using UnityEngine;

public enum EItemType
{
    Equipment,
    Consumable,
    Special
}

[CreateAssetMenu(fileName = "BasicItem", menuName = "MyCustomObjects/BasicItemObject", order = 1)]
public class BasicItemObject : ScriptableObject
{
    public EItemType type;
    public string itemName;
}