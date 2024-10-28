using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBall : MonoBehaviour, IPoolable
{
    [SerializeField] private string _poolName;
    
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rigidbody2D.velocity = (Mathf.Approximately(transform.localScale.x, 1) ? Vector2.right : Vector2.left) * 2;
    }

    public string PoolName => _poolName;
    public GameObject ObjectPrefab => gameObject;
    public void ResetItem()
    {
        
    }
}
