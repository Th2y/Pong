using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private string playerName;

    [Header("Moviment")]
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float speed = 0.1f;

    [Header("Key setup")]
    [SerializeField] private KeyCode keyMoveUp = KeyCode.UpArrow;
    [SerializeField] private KeyCode keyMoveDown = KeyCode.DownArrow;

    private void Update()
    {
        if (Input.GetKey(keyMoveUp))
        {
            playerRB.MovePosition(transform.position + transform.up * speed);
        }
        else if (Input.GetKey(keyMoveDown))
        {
            playerRB.MovePosition(transform.position + transform.up * -speed);
        }
    }
}