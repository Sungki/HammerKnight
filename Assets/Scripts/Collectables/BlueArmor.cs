using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueArmor : CollectableObject
{
    public EquipmentItemObject blueArmor;
    void Start()
    {
        myColor = blueArmor.color;
        SetColor(myColor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().inventory.items.Add(blueArmor);
            collision.gameObject.GetComponent<PlayerController>().ArmorEquip(blueArmor);
            Destroy(this.gameObject);
        }
    }
}
