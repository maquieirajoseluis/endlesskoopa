using UnityEngine;

public class Ground : MonoBehaviour
{
    private BoxCollider2D grassBoxCollider2D;

    private float grassHorizontalLength;

    void Start()
    {
        grassBoxCollider2D = GetComponent<BoxCollider2D>();
        grassHorizontalLength = grassBoxCollider2D.size.x;
    }

    void Update()
    {
        if (transform.position.x < -grassHorizontalLength)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector2 grassOffset = new Vector2(grassHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + grassOffset;
    }
}
