using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowHammer: CollectableObject
{
    public EquipmentItemObject yellowHammer;

    void Start()
    {
        myColor = yellowHammer.color;
        SetColor(myColor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().inventory.items.Add(yellowHammer);
            collision.gameObject.GetComponent<PlayerController>().HammerEquip(yellowHammer);
            Destroy(this.gameObject);
        }
    }
}
