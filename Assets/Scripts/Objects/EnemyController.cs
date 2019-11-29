using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MovableObject, IPlayerFSM
{
    public State e;
    protected bool _isNewState = false;
    protected Vector3 target = Vector3.zero;

    protected GameObject player;
    protected Rigidbody2D rb;

    public GameObject[] items;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        SetState(State.Idle);
        StartCoroutine(FSMMain());
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

            if (player && (Vector2.Distance(player.transform.position, transform.position) < 6f))
                SetState(State.Walk);

        } while (!_isNewState);
    }

    public IEnumerator Walk()
    {
        do
        {
            yield return null;
            if (_isNewState) break;

            velocity = player.transform.position - transform.position;
            velocity.y = 0f;
            velocity.z = 0f;

            velocity = velocity.normalized;

            if (Vector2.Distance(player.transform.position, transform.position) > 6f)
            {
                velocity = Vector3.zero;
                SetState(State.Idle);
            }

            if (Vector2.Distance(player.transform.position, transform.position) < 3f)
            {
                target = player.transform.position;
                SetState(State.Attack);
            }

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
        float timeSpan = 0.0f;
        float checkTime = 0.5f;

        rb.constraints = 0;
        velocity = Vector3.zero;

        if(hp<=0)
        {
            rb.AddForce(Vector2.right * 40f, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
        }

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

        if (hp <= 0)
        {
            int random = Random.Range(0, 4);
            Instantiate(items[random], new Vector3(transform.position.x, 0, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }

        rb.velocity = Vector2.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public virtual IEnumerator Attack() { yield return null; }
}
