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

    private void Awake()
    {
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
    }

    public IEnumerator Hurt()
    {
        do
        {
            yield return null;
            if (_isNewState) break;
        } while (!_isNewState);
    }
}