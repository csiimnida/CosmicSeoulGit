using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rigid;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    public float Speeed;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Math.Abs(Input.GetAxis("Horizontal")) != 0)
        {
            //에니메이션 실행
            if (Input.GetAxis("Horizontal") < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;

            }
            _animator.SetFloat("Horizontal",Math.Abs(Input.GetAxis("Horizontal")));
            transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * Speeed, 0, 0);
        }
        else
        {
            rigid.velocity = Vector3.zero;
        }
    }
}
