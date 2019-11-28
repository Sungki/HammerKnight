using UnityEngine;

public enum EStat
{
    Health,
    Defense,
    Attack
}

[CreateAssetMenu(fileName = "ConsumableItem", menuName = "MyCustomObjects/ConsumableItemObject", order = 1)]
public class ConsumableItemObject : BasicItemObject
{

    public EStat stat;
    public int value;


    ConsumableItemObject()
    {
        this.type = EItemType.Consumable;
    }

    public void Consume()
    {
        switch (this.stat)
        {
            case EStat.Health:
                break;
            case EStat.Defense:
                break;
            case EStat.Attack:
                break;
        }
    }
}