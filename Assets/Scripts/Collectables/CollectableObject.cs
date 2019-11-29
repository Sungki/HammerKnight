using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public Color myColor;

    protected void SetColor(Color color)
    {
        GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    private void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        this.transform.Rotate(Vector3.up * 5f);
    }

    private void OnDestroy()
    {
        int enemyCount = 0;
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            ToolBox.GetInstance().GetManager<LevelManager>().NextLevel();
        }
    }
}
