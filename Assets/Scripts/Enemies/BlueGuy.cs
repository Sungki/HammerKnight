using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGuy : EnemyController
{
    private void Start()
    {
        speed = 2f;

        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.blue);
    }

    public override IEnumerator Attack()
    {
        float timeSpan = 0.0f;
        float checkTime = 0.5f;
        rb.AddForce(velocity * 5f, ForceMode2D.Impulse);
        transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 90);

        do
        {
            yield return null;
            if (_isNewState) break;

            transform.Rotate(Vector3.right * 15f);

            timeSpan += Time.deltaTime;
            if (timeSpan > checkTime)
            {
                timeSpan = 0;
                SetState(State.Idle);
            }

        } while (!_isNewState);

        transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
