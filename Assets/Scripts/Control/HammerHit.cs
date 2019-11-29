using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().SetState(EnemyController.State.Hurt);
            float damage = transform.parent.GetComponentInParent<PlayerController>().attack * (100 / (100 + collision.gameObject.GetComponent<EnemyController>().defense));
            collision.gameObject.GetComponent<EnemyController>().hp -= damage;
        }
    }
}
