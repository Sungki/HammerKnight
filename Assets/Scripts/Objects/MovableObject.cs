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
    [SerializeField] protected int hp = 10;
    [SerializeField] protected int attack = 1;
    [SerializeField] protected int defense = 1;

    private void FixedUpdate()
    {
        transform.position += velocity * speed * Time.deltaTime;
    }
}
