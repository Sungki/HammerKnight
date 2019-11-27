using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGuy : EnemyController
{
    private void Start()
    {
        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.yellow);
    }

    public override IEnumerator Attack()
    {
        yield return null;
    }
}
