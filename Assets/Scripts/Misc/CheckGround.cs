using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    [HideInInspector] public bool isGrounded = false;
    PlayerController pc;

    private void Start()
    {
        pc = transform.parent.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        if (pc.e != PlayerController.State.Attack)
            pc.SetState(PlayerController.State.Idle);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
