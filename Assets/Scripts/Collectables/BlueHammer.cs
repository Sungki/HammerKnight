using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHammer: CollectableObject
{
    public EquipmentItemObject blueHammer;

    void Start()
    {
        myColor = blueHammer.color;
        SetColor(myColor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().inventory.items.Add(blueHammer);
            collision.gameObject.GetComponent<PlayerController>().HammerEquip(blueHammer);
            Destroy(this.gameObject);
        }
    }
}
