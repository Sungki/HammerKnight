using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    private float distance = 0.8f;
    private Vector3 originalPosition;
    public Color myColor;

    private void Start()
    {
        this.originalPosition = this.transform.position;
    }

    protected void SetColor(Color color)
    {
        GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    private void Update()
    {
        MoveUpDown();
        Rotate();
    }

    void MoveUpDown()
    {
        this.transform.position = this.originalPosition + this.transform.up * this.distance * Mathf.Sin(Time.time);
    }

    void Rotate()
    {
        this.transform.Rotate(Vector3.up * 5f);
    }
}
