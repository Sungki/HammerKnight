using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovableObject, IPlayerFSM
{
    public State e;
    private bool _isNewState = false;
    private AnimatorStateInfo myAnimatorStateInfo;
    private float myAnimatorNormalizedTime = 0.0f;

    private void Awake()
    {
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

    public IEnumerator Dash()
    {
        float timeSpan = 0.0f;
        float checkTime = 0.3f;

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