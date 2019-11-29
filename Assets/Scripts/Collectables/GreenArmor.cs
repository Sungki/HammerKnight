using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArmor : CollectableObject
{
    public EquipmentItemObject greenArmor;

    void Start()
    {
        myColor = greenArmor.color;
        SetColor(myColor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().inventory.items.Add(greenArmor);
            collision.gameObject.GetComponent<PlayerController>().ArmorEquip(greenArmor);
            Destroy(this.gameObject);
        }
    }
}
