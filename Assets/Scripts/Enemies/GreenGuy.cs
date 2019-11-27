using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGuy : EnemyController
{
    private void Start()
    {
        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.green);
    }

    public override IEnumerator Attack()
    {
        yield return null;
    }
}
