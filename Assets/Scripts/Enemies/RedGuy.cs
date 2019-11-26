using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGuy : EnemyController
{
    private void Start()
    {
        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.red);
    }

    public override IEnumerator Attack()
    {
        yield return null;
    }
}
