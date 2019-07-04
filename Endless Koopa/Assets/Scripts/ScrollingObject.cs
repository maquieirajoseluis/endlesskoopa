using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Game.instance.gameOver)
        {
            Move(0);
        }
        else
        {
            Move(Input.GetAxis("Horizontal"));
        }
    }

    private void Move(float direction)
    {
        Vector2 move = Vector2.zero;

        move.x = direction * Game.instance.scrollSpeed;

        rb2d.velocity = move;
    }
}
