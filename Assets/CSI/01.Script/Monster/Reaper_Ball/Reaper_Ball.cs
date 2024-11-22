using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper_Ball : MonoBehaviour, IPoolable
{
    [SerializeField] private string _poolName;
    public EnermyDataSO enermyData;

    private Rigidbody2D rigidbody2D;
    private Animator _animator;
    public float speed = 2;
    
    private bool _isDead = false;

    private float _curGravityScale;


    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start(){
        _curGravityScale = rigidbody2D.gravityScale;
    }


    public string PoolName => _poolName;
    public GameObject ObjectPrefab => gameObject;

    public void ResetItem()
    {
        _animator.Play("Move");
    }

    private void FixedUpdate(){
        if(_isDead == false)
            rigidbody2D.velocity = transform.right.normalized * -speed;
    }

    public void Push()
    { 
        PoolManager.Instance.Push(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.GetComponent<Player>().Damage(enermyData, enermyData.AttackPower);
            _animator.Play("Die");
            _isDead = true;
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.gravityScale = 0;
        }
        else if (other.transform.CompareTag("Ground"))
        {
            _animator.Play("Die");
            _isDead = true;
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.gravityScale = 0;
        }
    }

    private void OnDisable(){
        _isDead = false;
        rigidbody2D.gravityScale = _curGravityScale;
    }
}