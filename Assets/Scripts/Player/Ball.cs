using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Points points;
    [SerializeField] private Vector3 speed = new Vector3(1, 1, 0);
    [SerializeField] private float incrementSpeed = 0.01f;
    [SerializeField] private float maxSpeed = 0.1f;
    [SerializeField] private int playerCollisionsToIncrement = 2;
    private int playerCollisions = 0;

    void Update()
    {
        transform.Translate(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(speed.x < maxSpeed && speed.x > 0)
            {
                playerCollisions++;
                if (playerCollisions == playerCollisionsToIncrement)
                {
                    speed.x = - (speed.x + incrementSpeed);
                    if(speed.y > 0)
                    {
                        speed.y += incrementSpeed;
                    }
                    else
                    {
                        speed.y -= incrementSpeed;
                    }
                    playerCollisions = 0;
                }
                else
                {
                    speed.x = -speed.x;
                }
            }
            else
            {
                speed.x = -speed.x;
            }
        }
        else if (collision.gameObject.CompareTag("LimitUpOrDown"))
        {
            speed.y = -speed.y;
        }
        else if(collision.gameObject.CompareTag("LimitRight"))
        {
            points.IncrementPointsPlayerL();
        }
        else if (collision.gameObject.CompareTag("LimitLeft"))
        {
            points.IncrementPointsPlayerR();
        }
    }
}
