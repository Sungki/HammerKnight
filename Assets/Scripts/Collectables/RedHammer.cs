using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHammer: CollectableObject
{
    public EquipmentItemObject redHammer;

    void Start()
    {
        myColor = redHammer.color;
        SetColor(myColor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().inventory.items.Add(redHammer);
            collision.gameObject.GetComponent<PlayerController>().HammerEquip(redHammer);
            Destroy(this.gameObject);
        }
    }
}
