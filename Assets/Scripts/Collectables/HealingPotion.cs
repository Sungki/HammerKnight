using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : CollectableObject
{
    public ConsumableItemObject healingPotion;

    void Start()
    {
        myColor = healingPotion.color;
        SetColor(myColor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ToolBox.GetInstance().GetManager<StatManager>().playerHP = 10;
            ToolBox.GetInstance().GetManager<GameManager>().ShowHUD();
            Destroy(this.gameObject);
        }
    }
}
