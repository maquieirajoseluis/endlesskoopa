using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float moveSpeed = 7f;

    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move(Input.GetAxis("Horizontal"));
    }

    private void Move(float direction)
    {
        Vector2 move = Vector2.zero;

        move.x = -direction * moveSpeed;

        rb2d.velocity = move;
    }
}
