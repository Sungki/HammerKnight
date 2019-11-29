using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : CollectableObject
{
    void Start()
    {
        SetColor(Color.yellow);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ToolBox.GetInstance().GetManager<StatManager>().AddCoin();
            ToolBox.GetInstance().GetManager<GameManager>().ShowHUD();

            Destroy(this.gameObject);
        }
    }
}
