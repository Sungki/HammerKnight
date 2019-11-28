using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowArmor : CollectableObject
{
    public EquipmentItemObject yellowArmor;
    void Start()
    {
        myColor = Color.yellow;
        SetColor(myColor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().inventory.items.Add(yellowArmor);
            collision.gameObject.GetComponent<PlayerController>().ArmorEquip(yellowArmor);
            Destroy(this.gameObject);
        }
    }
}
