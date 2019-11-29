using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedArmor : CollectableObject
{
    public EquipmentItemObject redArmor;
    void Start()
    {
        myColor = redArmor.color;
        SetColor(myColor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().inventory.items.Add(redArmor);
            collision.gameObject.GetComponent<PlayerController>().ArmorEquip(redArmor);
            Destroy(this.gameObject);
        }
    }
}
