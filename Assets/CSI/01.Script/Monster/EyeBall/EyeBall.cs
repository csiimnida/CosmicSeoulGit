using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBall : MonoBehaviour, IPoolable
{
    [SerializeField] private string _poolName;
    public EnermyDataSO enermyData;
    
    private Rigidbody2D rigidbody2D;
    public bool _isSeeRight;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {

    }

    public string PoolName => _poolName;
    public GameObject ObjectPrefab => gameObject;
    public void ResetItem()
    {

        

    }

    public void Rotate()
    {
        rigidbody2D.velocity = ((Mathf.Approximately(transform.eulerAngles.y, 180)) ? Vector2.left : Vector2.right) * 2;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (other.GetComponent<Player>().currentState == PlayerStateType.Roll) return;
            other.GetComponent<Player>().Damage(this);
            PoolManager.Instance.Push(this);
        }
    }
}
