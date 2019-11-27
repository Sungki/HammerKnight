using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerContol : MonoBehaviour
{
    [HideInInspector] public bool isPressed = false;
    [HideInInspector] public bool isMaxJump = false;

    private PlayerController pc;
    private CheckGround cg;

    private void Awake()
    {
        pc = GetComponent<PlayerController>();
        cg = GetComponentInChildren<CheckGround>();
    }

    void Update()
    {
        pc.velocity = Vector3.zero;
        Keyboard();
    }

    private void FixedUpdate()
    {
        if (isPressed && !isMaxJump)
        {
            pc.jump.Action(this.gameObject);
        }
    }

    void Keyboard()
    {
        pc.velocity += new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        if (Input.GetButton("Jump") && cg.isGrounded)
        {
            isPressed = true;
            pc.SetState(PlayerController.State.Jump);
        }
        if (Input.GetButtonUp("Jump"))
        {
            isPressed = false;
            isMaxJump = false;
        }

        if (Input.GetButton("Attack"))
        {
            pc.SetState(PlayerController.State.Attack);
            pc.hammer.Action(this.gameObject);
        }
        if(Input.GetButtonUp("Attack")) pc.SetState(PlayerController.State.Idle);

    }
}
