using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGuy : EnemyController
{
    private void Start()
    {
        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.blue);
    }

    public override IEnumerator Attack()
    {
        yield return null;
    }
}
