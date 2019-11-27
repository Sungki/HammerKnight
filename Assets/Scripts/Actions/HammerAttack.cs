using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HammerAttack : ActionBase
{
    public Rigidbody2D rb;
    public FixedJoint2D fj;
    public HingeJoint2D hj;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fj = GetComponent<FixedJoint2D>();
        hj = GetComponent<HingeJoint2D>();
    }

    public override void Action(GameObject obj)
    {
        rb.AddTorque(-100f);
    }
}
