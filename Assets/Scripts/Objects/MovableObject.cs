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
    protected int hp = 10;
    protected int defense = 1;
    protected int attack = 1;

    private void FixedUpdate()
    {
        transform.position += velocity * speed * Time.deltaTime;
    }
}
