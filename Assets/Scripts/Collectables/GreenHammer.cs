using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHammer : CollectableObject
{
    public EquipmentItemObject greenHammer;

    void Start()
    {
        myColor = greenHammer.color;
        SetColor(myColor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().inventory.items.Add(greenHammer);
            collision.gameObject.GetComponent<PlayerController>().HammerEquip(greenHammer);
            Destroy(this.gameObject);
        }
    }
}
