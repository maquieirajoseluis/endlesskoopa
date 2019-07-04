using UnityEngine;

public class Mario : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Animator animator;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Walk(float direction)
    {
        if (direction != 0)
        {
            animator.SetTrigger("marioWalk");
        }
        else
        {
            animator.SetTrigger("marioIdle");
        }
    }

    private void FixedUpdate()
    {
        Walk(Input.GetAxis("Horizontal"));
    }
}
