using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Jump))]
[RequireComponent(typeof(HammerAttack))]
public class PlayerController : MovableObject, IPlayerFSM
{
    [HideInInspector] public Jump jump;
    [HideInInspector] public HammerAttack hammer;

    public State e;
    private bool _isNewState = false;
    private AnimatorStateInfo myAnimatorStateInfo;
    private float myAnimatorNormalizedTime = 0.0f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = GetComponent<Jump>();
        hammer = GetComponentInChildren<HammerAttack>();

        SetState(State.Idle);
        StartCoroutine(FSMMain());
    }

    private void Update()
    {
        myAnimatorNormalizedTime = myAnimatorStateInfo.normalizedTime;
    }

    public void SetState(State newState)
    {
        if (e != newState)
        {
            _isNewState = true;
            e = newState;
        }
    }

    IEnumerator FSMMain()
    {
        while (true)
        {
            _isNewState = false;
            yield return StartCoroutine(e.ToString());
        }
    }

    public IEnumerator Idle()
    {
        do
        {
            yield return null;
            if (_isNewState) break;
        } while (!_isNewState);
    }

    public IEnumerator Walk()
    {
        do
        {
            yield return null;
            if (_isNewState) break;
        } while (!_isNewState);
    }

    public IEnumerator Jump()
    {
        do
        {
            yield return null;
            if (_isNewState) break;
        } while (!_isNewState);
    }

    public IEnumerator Attack()
    {
        hammer.fj.enabled = false;
        hammer.hj.enabled = true;
        myAnimatorNormalizedTime = 0;

        do
        {
            yield return null;
            if (_isNewState) break;

            if (myAnimatorNormalizedTime >= 1)
            {
                SetState(State.Idle);
            }

        } while (!_isNewState);

        hammer.rb.velocity = Vector2.zero;
        hammer.hj.enabled = false;
        hammer.fj.enabled = true;
    }

    public IEnumerator Hurt()
    {
        float timeSpan = 0.0f;
        float checkTime = 0.5f;

        rb.constraints = 0;
        velocity = Vector3.zero;
        rb.AddForce(Vector2.left * 30f, ForceMode2D.Impulse);

        do
        {
            yield return null;
            if (_isNewState) break;

            timeSpan += Time.deltaTime;
            if (timeSpan > checkTime)
            {
                timeSpan = 0;
                SetState(State.Idle);
            }

        } while (!_isNewState);

        rb.velocity = Vector2.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}