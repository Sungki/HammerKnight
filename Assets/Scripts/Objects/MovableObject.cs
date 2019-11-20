using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public enum State
    {
        Idle,
        Walk,
        Jump,
        Dash,
        Attack,
        Hurt
    }

    [HideInInspector] public Vector3 velocity = Vector3.zero;
    protected float speed = 6f;

    private void FixedUpdate()
    {
        transform.position += velocity * speed * Time.deltaTime;

        if(velocity.x > 0) transform.localScale = new Vector3(2f, 2f, 2f);
        if (velocity.x < 0) transform.localScale = new Vector3(-2f, 2f, 2f);
    }
}
