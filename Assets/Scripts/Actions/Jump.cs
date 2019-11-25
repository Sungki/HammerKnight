using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : ActionBase
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpLimiter = 50f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void Action(GameObject obj)
    {
        rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);

        if (rb.velocity.y > jumpLimiter)
        {
            obj.GetComponent<PlayerContol>().isMaxJump = true;
        }
    }
}
