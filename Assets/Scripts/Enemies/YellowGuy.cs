using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGuy : EnemyController
{
    EnemyHammerAttack hammer;

    private void Start()
    {
        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.yellow);

        hammer = GetComponentInChildren<EnemyHammerAttack>();
    }

    public override IEnumerator Attack()
    {
        float timeSpan = 0.0f;
        float checkTime = 0.2f;

        do
        {
            yield return null;
            if (_isNewState) break;

            hammer.Action(this.gameObject);

            timeSpan += Time.deltaTime;
            if (timeSpan > checkTime)
            {
                timeSpan = 0;
                SetState(State.Idle);
            }

        } while (!_isNewState);

        hammer.rb.velocity = Vector2.zero;
        transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
