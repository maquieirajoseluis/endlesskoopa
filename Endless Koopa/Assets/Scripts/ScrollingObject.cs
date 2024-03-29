﻿using UnityEngine;

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
        else if (Game.instance.objectCollision)
        {
            if (Input.GetAxis("Horizontal") >= 0)
            {
                Move(0);
            }
            else
            {
                Move(Input.GetAxis("Horizontal"));
            }
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

        if (move.x != 0)
        {
            Game.instance.absoluteX += Mathf.Abs(move.x);
        }

        rb2d.velocity = move;
    }
}
