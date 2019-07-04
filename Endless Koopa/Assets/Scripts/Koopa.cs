using UnityEngine;

public class Koopa : PhysicsObject
{
    public float jumpSpeed = 7f;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Jump()
    {
        Vector2 move = Vector2.zero;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpSpeed;
            animator.SetTrigger("koopaJump");
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y *= 0.5f;
                animator.SetTrigger("koopaJump");
            }
        }

        targetVelocity = move;
    }

    private void Walk(float direction)
    {
        bool flipSprite = spriteRenderer.flipX ? direction > 0f : direction < 0f;

        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        if (grounded)
        {
            if (direction != 0)
            {
                animator.SetTrigger("koopaWalk");
            }
            else
            {
                animator.SetTrigger("koopaIdle");
            }
        }
    }

    private void Die()
    {
        animator.SetTrigger("koopaDie");
    }

    protected override void ComputeVelocity()
    {
        if (Game.instance.gameOver)
        {
            Die();
        }
        else
        {
            Walk(Input.GetAxis("Horizontal"));

            Jump();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            Game.instance.Scored();

            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "Mario")
        {
            Game.instance.GameOver();
        }

        if (collision.tag == "Object")
        {
            Game.instance.Collision(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Object")
        {
            Game.instance.Collision(false);
        }
    }
}
