using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyGuy : EnemyController
{
    private void Start()
    {
        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.grey);
    }

    public override IEnumerator Attack()
    {
        yield return null;
    }
}
