using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().SetState(PlayerController.State.Hurt);
            float damage = transform.GetComponent<EnemyController>().attack * (100 / (100 + collision.gameObject.GetComponent<PlayerController>().defense));
            ToolBox.GetInstance().GetManager<StatManager>().ReduceHP(damage);
            ToolBox.GetInstance().GetManager<GameManager>().ShowHUD();
        }
    }
}
