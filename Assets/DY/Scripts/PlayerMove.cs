using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    InputReder reader;
    Rigidbody2D rb;
    Vector2 MoveDir;
    float MoveSpeed = 5f;
   public Action OnCheakGround;


    private void Awake()
    {
        reader = GetComponent<InputReder>();
        rb = GetComponent<Rigidbody2D>();
        reader.OnMove += Move;
        reader.OnJump += Jump;
    }

    private void Move(Vector2 dir)
    {
        MoveDir = dir;
        rb.velocity = new Vector2(MoveDir.x * MoveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        Debug.Log("A");
        rb.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
        OnCheakGround?.Invoke();

    }
}
