using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public enum State
    {
        Idle,
        Walk,
        Jump,
        Attack,
        Hurt
    }

    [HideInInspector] public Vector3 velocity = Vector3.zero;
    protected float speed = 5f;
    public float hp = 10;
    public float attack = 1;
    public float defense = 1;

    private void FixedUpdate()
    {
        transform.position += velocity * speed * Time.deltaTime;
    }
}
