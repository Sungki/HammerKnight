using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MovableObject, IPlayerFSM
{
    public State e;
    private bool _isNewState = false;
    private AnimatorStateInfo myAnimatorStateInfo;
    private float myAnimatorNormalizedTime = 0.0f;
    private float TimeLeft = 1.0f;
    private float nextTime = 0.0f;
    protected float movementAI = 0;

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

    void MovementAI()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;
            movementAI = Random.Range(1, 3);
        }

        if (movementAI == 1) velocity = Vector3.left;
        else if (movementAI == 2) velocity = Vector3.right;
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
            MovementAI();

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

    public IEnumerator Hurt()
    {
        do
        {
            yield return null;
            if (_isNewState) break;
        } while (!_isNewState);
    }

    public virtual IEnumerator Attack() { yield return null; }
}
